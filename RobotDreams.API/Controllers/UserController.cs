using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Context;
using RobotDreams.API.Context.Domain;
using RobotDreams.API.Model.EntityFrameworkExample;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly RobotDreamsDbContext dbContext;

        public UserController(RobotDreamsDbContext dbContext)
        {
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

            response.TokenExpireDate = DateTime.Now;
            response.Authenticate = true;
            response.Token = string.Empty;
            
            return Ok(JsonConvert.SerializeObject(response));
        }
    }
}
