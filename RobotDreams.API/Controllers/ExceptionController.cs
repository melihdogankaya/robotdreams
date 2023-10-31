using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionController : ControllerBase
    {

        [HttpGet]
        [Route("Exception ")]
        public IActionResult NullException1()
        {
            try
            {
                object o = null;
                o.ToString();
            }
            catch (Exception ex)
            {
                string msg = $"Hata Turu : {ex.Message}";
                return BadRequest(msg);
            }



            return Ok();
        }
    }
}
