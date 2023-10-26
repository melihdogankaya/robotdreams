using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            List<string> result = new List<string>();
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
                string cultureName;
                if (string.IsNullOrEmpty(cultureInfo.NativeName))
                {
                    cultureName = cultureInfo.Name;
                }
                else
                {
                    cultureName = cultureInfo.Name;
                }
                result.Add($"in {cultureName}, {now.ToString(cultureInfo)}");
            }
            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("Date to string 2")]
        public IActionResult Example2()
        {
            List<string> result = new();
            var date = new DateTime(2000, 03, 19, 18, 3,12);
            string[] standardFnts = { "d", "D", "f", "F", "g", "G", "m", "o" };
            foreach (var item in standardFnts)
            {
                result.Add($"{item} : {date.ToString(item)}");  
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("Parse DateTime")]
        public IActionResult ParseDateTime()
        {

            var stringDate = "13/10/2023 19:27";
           var result = DateTime.TryParse(stringDate, out DateTime date);
           
            if(result)
            {
               date = date.AddDays(4);
            }
            
            return Ok(date);
        }
    }

}
