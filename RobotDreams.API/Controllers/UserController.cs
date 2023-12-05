using Azure;
using Dapper;
using Elasticsearch.Net.Specification.WatcherApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RobotDreams.API.Context;
using RobotDreams.API.Context.Domain;
using RobotDreams.API.Helper;
using RobotDreams.API.Model.DLinqAttribute;
using RobotDreams.API.Model.EntityFrameworkExample;
using RobotDreams.API.Model.Interface;
using RobotDreams.API.Model.SqlClient;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly RobotDreamsDbContext dbContext;
        private readonly ICacheService cacheService;
        private readonly SqlConnection sqlConnection;

        private readonly IMemoryCache memCache;

        public UserController(IConfiguration configuration, RobotDreamsDbContext dbContext, ICacheService cacheService, IMemoryCache memCache)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.cacheService = cacheService;
            this.memCache = memCache;
            sqlConnection = new SqlConnection(configuration["ConnectionStrings:DefaultConnection"]);
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserModel model)
        {
            if (model == null)
            {
                return BadRequest("Model cannot be null");
            }

            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Email and Password cannot be empty.");
            }

            if (!RegExUtilities.IsValidEmail(model.Email))
            {
                return BadRequest("Email address format doesn't correct.");
            }

            if (!RegExUtilities.IsPhoneNumberCorrect(model.PhoneNumber))
            {
                return BadRequest("PhoneNumber format doesn't correct.");
            }

            dbContext.Users.Add(new Context.Domain.User { Name = model.Name, Surname = model.Surname, Email = model.Email, Password = Crypto.EncryptPassword(model.Password), Id = Guid.NewGuid(), PhoneNumber = model.PhoneNumber });
            var result = dbContext.SaveChanges();

            if (result <= 0)
            {
                return BadRequest("User cannot be created.");
            }
            else
            {
                return Ok("User is created.");
            }

        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromBody] LoginUserModel model)
        {
            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
            {
                return BadRequest("Email and Password cannot be empty.");
            }

            var response = new UserModel();

            var findUser = dbContext.Users.FirstOrDefault(p => p.Email == model.Email && p.Password == Crypto.EncryptPassword(model.Password));

            if (findUser == null)
            {
                return NotFound();
            }

            var cacheForUserToken = cacheService.GetValueAsync($"robotdreams.user.token.{findUser.Id}").Result;

            if (!string.IsNullOrEmpty(cacheForUserToken))
            {
                response.Token = cacheForUserToken;
                response.Authenticate = true;
                return Ok(JsonConvert.SerializeObject(response));
            }

            var userRoles = dbContext.UserRoles.Where(p => p.UserId == findUser.Id).Include(c => c.User).AsEnumerable();

            var expirationInMinutes = TimeSpan.FromMinutes(20);
            var expireMinute = DateTime.Now.AddMinutes(expirationInMinutes.Minutes);

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, configuration["JwtSecurityToken:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, EpochTime.GetIntDate(DateTime.Now).ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Exp, EpochTime.GetIntDate(expireMinute).ToString(), ClaimValueTypes.Integer64),
                new Claim(JwtRegisteredClaimNames.Iss, configuration["JwtSecurityToken:Issuer"]),
                new Claim(JwtRegisteredClaimNames.Aud, configuration["JwtSecurityToken:Audience"]),
                new Claim("Name", findUser.Name),
                new Claim("Surname", findUser.Surname),
                new Claim("Email", findUser.Email),
                new Claim("UserId", findUser.Id.ToString())
            };

            //if (userRoles.Any())
            //{
            //    foreach (var role in userRoles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, role.Role));
            //    }
            //}

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityToken:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        issuer: configuration["JwtSecurityToken:Issuer"],
                        audience: configuration["JwtSecurityToken:Audience"],
                        claims: claims,
                        expires: expireMinute,
                        signingCredentials: signIn);

            var tokenHandler = new JwtSecurityTokenHandler();

            response.TokenExpireDate = expireMinute;
            response.Authenticate = true;
            response.Token = tokenHandler.WriteToken(token);

            cacheService.SetValueAsync($"robotdreams.user.token.{findUser.Id}", response.Token);

            return Ok(JsonConvert.SerializeObject(response));
        }

        [Authorize]
        [HttpGet]
        [Route("getUserRoles")]
        public async Task<IActionResult> GetUserRoles([FromQuery] Guid? userId)
        {
            if (userId == null)
            {
                return BadRequest("UserId cannot be null");
            }

            //var cacheForUserRole = await cacheService.GetValueAsync($"robotdreams.user.roles.{userId}");

            var cacheForUserRole = memCache.TryGetValue($"robotdreams.user.roles.{userId}", out string? userRoles);

            if (cacheForUserRole && !string.IsNullOrEmpty(userRoles))
            {
                return Ok(JsonConvert.DeserializeObject<IEnumerable<UserRoles>>(userRoles));
            }

            var userRolesFromDb = dbContext.UserRoles.Where(p => p.UserId == userId).Include(p => p.User).AsEnumerable();

            if (userRolesFromDb == null)
            {
                return BadRequest("User hasn't got any roles.");
            }

            //await cacheService.SetValueAsync($"robotdreams.user.roles.{userId}", JsonConvert.SerializeObject(userRoles));


            return Ok(JsonConvert.SerializeObject(userRolesFromDb));
        }

        [Authorize]
        [HttpPost]
        [Route("setMemCache")]
        public void SetCache([FromQuery] Guid userId, [FromBody] IEnumerable<UserRoles> userRoles)
        {
            memCache.Set($"robotdreams.user.roles.{userId}", JsonConvert.SerializeObject(userRoles), DateTime.Now.AddSeconds(35));
        }

        [HttpPost]
        [Route("createUserAddress")]
        public IActionResult CreateUserAddress([FromQuery] Guid? userId, [FromBody] CreateUserAddressModel model)
        {
            if (string.IsNullOrEmpty(model.AddressName)
                || string.IsNullOrEmpty(model.Address)
                || string.IsNullOrEmpty(model.PhoneNumber)
                || string.IsNullOrEmpty(model.City)
                || string.IsNullOrEmpty(model.District)
                || string.IsNullOrEmpty(model.Creator) || userId == null || userId == Guid.Empty)
                return BadRequest("Bazı bilgiler boş olamaz.");

            UserAddress userAddress = new()
            {
                Email = model.Email,
                AddressName = model.AddressName,
                Address = model.Address,
                UserId = userId.Value,
                City = model.City,
                District = model.District,
                Creator = model.Creator,
                PhoneNumber = model.PhoneNumber,
                Name = model.Name,
                Surname = model.Surname,
                PostCode = model.PostCode
            };

            var result = dbContext.UserAddresses.Add(userAddress);
            dbContext.SaveChanges();

            return Ok(result.State == EntityState.Unchanged ? "Başarılı." : "Başarısız");
        }

        [Authorize]
        [HttpGet]
        [Route("getUserAddress")]
        public IActionResult GetUserAddresses()
        {
            //OrderBy LINQ
            //var result = from userAddresses in dbContext.UserAddresses
            //             where userAddresses.UserId == userId
            //             orderby userAddresses.Created descending
            //             select userAddresses;
            //

            //Inner Join LINQ
            //var result = from user in dbContext.Users
            //             join userRole in dbContext.UserRoles on user.Id equals userRole.UserId
            //             select new
            //             {
            //                 user.Id,
            //                 user.Name,
            //                 user.Surname,
            //                 user.Email,
            //                 userRole.Role
            //             };

            //Left Join LINQ
            //var result = from user in dbContext.Users
            //             join userRole in dbContext.UserRoles on user.Id equals userRole.UserId into t
            //             from nt in t.DefaultIfEmpty()
            //             //from userRole in dbContext.UserRoles.Where(p => p.UserId == userId).DefaultIfEmpty()                    
            //             select new
            //             {
            //                 user.Id,
            //                 user.Name,
            //                 user.Surname,
            //                 user.Email,
            //                 nt.Role
            //             };

            //OrderBy Strong Typed
            //var result = dbContext.UserAddresses.Where(p => p.UserId == userId).OrderByDescending(p => p.Created);

            //Left Join Strong Typed
            //var result = dbContext.UserRoles.Include(p => p.User).Select(p => new { p.Id, p.User.Name, p.User.Surname, p.User.Email, p.Role });

            var requestHeaders = Request.Headers;
            var authorization = requestHeaders.Authorization;
            var token = authorization.First().Replace("Bearer ", "");
            
            var handler = new JwtSecurityTokenHandler();
            var decodeToken = handler.ReadJwtToken(token);

            var findUserId = decodeToken.Claims.First(claim => claim.Type == "UserId").Value;

            var isUserIdCorrect = Guid.TryParse(findUserId, out Guid userId);

            if (!isUserIdCorrect)
                return BadRequest("UserId geçerli değil.");

            var cacheForUserAdresses = cacheService.GetValueAsync($"robotdreams.user.addresses.{userId}").Result;

            if (!string.IsNullOrEmpty(cacheForUserAdresses))
            {
                return Ok(JsonConvert.DeserializeObject<List<UserAddress>>(cacheForUserAdresses));
            }

            var result = dbContext.UserAddresses.Where(p => p.UserId == userId).Include(p => p.User).ToList();

            cacheService.SetValueAsync($"robotdreams.user.addresses.{userId}", JsonConvert.SerializeObject(result));

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("getUserWithSqlClient")]
        public IActionResult GetUserWithSqlClient()
        {
            try
            {
                var resultModel = new List<SqlClientUserModel>();
                var sqlText = @"SELECT [Id],[Name],[Surname],[Email],[PhoneNumber] FROM [dbo].[Users]";
                var sqlCommand = new SqlCommand(sqlText, sqlConnection);
                sqlConnection.Open();

                var result = sqlCommand.ExecuteReader();
                while (result.Read())
                {
                    resultModel.Add(new SqlClientUserModel
                    {
                        Id = Guid.Parse(result[0].ToString()),
                        Name = result[1].ToString(),
                        Surname = result[2].ToString(),
                        Email = result[3].ToString(),
                        PhoneNumber = result[4].ToString(),
                    });
                }

                return Ok(JsonConvert.SerializeObject(resultModel));
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPatch]
        [Route("userPassword")]
        public IActionResult UpdateUserPassword([FromBody] UpdateUserModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Email veya Parola boş olamaz.");

            var sqlText = @$"UPDATE [dbo].[Users] SET [Password] = '{model.Password}' WHERE Email = '{model.Email}'";
            var sqlCommand = new SqlCommand(sqlText, sqlConnection);
            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                return Ok("Kullanıcı şifresi güncellendi.");
            }
            else
            {
                return BadRequest("Kullanıcı şifresi güncellenemedi.");
            }
        }

        [HttpPatch]
        [Route("userPasswordStoredProcedure")]
        public IActionResult UpdateUserPasswordStoredProcedure([FromBody] UpdateUserModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Email veya Parola boş olamaz.");

            var sqlText = @$"EXEC [dbo].[sp_update_user_password_by_email] @Email = '{model.Email}', @Password = '{model.Password}'";
            var sqlCommand = new SqlCommand(sqlText, sqlConnection);
            sqlConnection.Open();

            var result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                return Ok("Kullanıcı şifresi güncellendi.");
            }
            else
            {
                return BadRequest("Kullanıcı şifresi güncellenemedi.");
            }
        }

        [HttpGet]
        [Route("getUserWithDapper")]
        public IActionResult GetUserWithDapper()
        {
            var sqlText = @"SELECT [Id],[Name],[Surname],[Email],[PhoneNumber] FROM [dbo].[Users]";

            sqlConnection.Open();
            var users = sqlConnection.Query<SqlClientUserModel>(sqlText);

            return Ok(JsonConvert.SerializeObject(users));
        }

        [HttpPatch]
        [Route("userPasswordStoredProcedureDapper")]
        public IActionResult UpdateUserPasswordStoredProcedureDapper([FromBody] UpdateUserModel model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
                return BadRequest("Email veya Parola boş olamaz.");

            DynamicParameters parameters = new();
            parameters.Add("Email", model.Email, DbType.String);
            parameters.Add("Password", model.Password, DbType.String);

            sqlConnection.Open();

            var result = sqlConnection.Execute("sp_update_user_password_by_email", parameters, null, null, CommandType.StoredProcedure);

            if (result > 0)
            {
                return Ok("Kullanıcı şifresi güncellendi.");
            }
            else
            {
                return BadRequest("Kullanıcı şifresi güncellenemedi.");
            }
        }
    }
}
