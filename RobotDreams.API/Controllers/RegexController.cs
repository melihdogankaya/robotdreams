using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Helper;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegexController : ControllerBase
    {
        [HttpGet]
        [Route("isValidEmail")]
        public IActionResult IsValidEmail([FromQuery] string email)
        {
            return Ok(RegExUtilities.IsValidEmail(email));
        }
    }
}
