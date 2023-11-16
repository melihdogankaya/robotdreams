using Elasticsearch.Net.Specification.WatcherApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        private readonly IMemoryCache memCache;

        public UserController(IConfiguration configuration, RobotDreamsDbContext dbContext, ICacheService cacheService, IMemoryCache memCache)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
            this.cacheService = cacheService;
            this.memCache = memCache;
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateUser([FromBody] CreateUserModel model)
        {
            if (model == null)
            {
                return BadRequest("Model cannot be null");
            }

            if(string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Password))
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

            dbContext.Users.Add(new Context.Domain.User { Name = model.Name, Surname = model.Surname, Email = model.Email, Password = model.Password, Id = Guid.NewGuid(), PhoneNumber = model.PhoneNumber});
            var result = dbContext.SaveChanges();

            if(result <= 0)
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

            var findUser = dbContext.Users.FirstOrDefault(p => p.Email == model.Email && p.Password == model.Password);

            if(findUser == null) 
            {
                return NotFound();
            }

            var userRoles = dbContext.UserRoles.Where(p => p.UserId == findUser.Id).Include(c => c.User).AsEnumerable();

            var expirationInMinutes = TimeSpan.FromMinutes(10);
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
            
            return Ok(JsonConvert.SerializeObject(response));
        }

        [Authorize]
        [HttpGet]
        [Route("getUserRoles")]
        public async Task<IActionResult> GetUserRoles([FromQuery] Guid? userId)
        {
            if(userId == null)
            {
                return BadRequest("UserId cannot be null");
            }

            //var cacheForUserRole = await cacheService.GetValueAsync($"robotdreams.user.roles.{userId}");

            var cacheForUserRole = memCache.TryGetValue($"robotdreams.user.roles.{userId}", out string? userRoles);

            if(cacheForUserRole && !string.IsNullOrEmpty(userRoles))
            {
                return Ok(JsonConvert.DeserializeObject<IEnumerable<UserRoles>>(userRoles));
            }

            var userRolesFromDb = dbContext.UserRoles.Where(p => p.UserId == userId).Include(p => p.User).AsEnumerable();

            if(userRolesFromDb == null)
            {
                return BadRequest("User hasn't got any roles.");
            }

            //await cacheService.SetValueAsync($"robotdreams.user.roles.{userId}", JsonConvert.SerializeObject(userRoles));


            return Ok(JsonConvert.SerializeObject(userRolesFromDb));
        }

        [Authorize]
        [HttpPost]
        [Route("setMemCache")]
        public void SetCache([FromQuery]Guid userId, [FromBody]IEnumerable<UserRoles> userRoles)
        {
            memCache.Set($"robotdreams.user.roles.{userId}", JsonConvert.SerializeObject(userRoles), DateTime.Now.AddSeconds(35));
        }
    }
}
