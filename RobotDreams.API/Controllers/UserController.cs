using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RobotDreams.API.Context;
using RobotDreams.API.Context.Domain;
using RobotDreams.API.Model.EntityFrameworkExample;
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

        public UserController(IConfiguration configuration, RobotDreamsDbContext dbContext)
        {
            this.configuration = configuration;
            this.dbContext = dbContext;
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

            dbContext.Users.Add(new User { Name = model.Name, Surname = model.Surname, Email = model.Email, Password = model.Password, Id = Guid.NewGuid()});
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
    }
}
