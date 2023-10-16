using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Model.Studies.Homeworks
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        [HttpGet]
        [Route("Generic Homework")]
        public IActionResult StudentAvarage()
        {
            GenericAvarageClass<Student> student = new()
            {
                
            };
            
            return Ok();

        }
    }
}
