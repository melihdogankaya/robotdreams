using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        [HttpGet]
        [Route("Date to string")]
        public IActionResult Example1()
        {
            CultureInfo[] culture = new CultureInfo[] 
            {
                CultureInfo.InvariantCulture, 
                new CultureInfo("en-US"),
                new CultureInfo("fr-fr"),
                new CultureInfo("de-de"),
                new CultureInfo("es-ES"),
                new CultureInfo("ja-JP")
            };

            DateTime now = DateTime.Now;
            foreach (var cultureInfo in culture) 
            {


            }

            return Ok();
        }
    }
}
