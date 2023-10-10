using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.GenericType;

namespace RobotDreams.API.Controllers
{
    public class GenericController : Controller
    {
        [HttpGet]
        [Route("GenericType1")]
        public IActionResult GenericTypeExample()
        {
            Generic<string> g = new()
            {
                Field = "A String"
            };

            return Ok(g.Field.GetType().FullName);
        }
    }
}



















