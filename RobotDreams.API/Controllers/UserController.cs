using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Context;
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
        public IActionResult CreatUser([FromBody] CreateUserModel model)
        {
            if (model == null)
            {
                return BadRequest("Burası boş Modeli doldur.");
            }

            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.UserName))
            {
                return BadRequest("Email ve Username kontrol et");
            }

            dbContext.Users.Add(new Context.Domain.User { Name = model.Name, Surname = model.Surname, Email = model.Email, Password = model.Password, Id = Guid.NewGuid() });
            var result = dbContext.SaveChanges();

            if(result <= 0)
            {
                return BadRequest("User Oluşmadı.");
            }
            else
            {
                return Ok("User hesabı oluştu.");
            }

        }
    }
}
