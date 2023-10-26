using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringController : ControllerBase
    {
        [HttpGet]
        [Route("concanate")]
        public IActionResult Concanate()
        {
            string s1 = "Melih";
            string s2 = "Doğankaya";
            string space = " ";
            //s1 += space + s2;
            //string c = string.Concat(s1,space,s2);
            string c2 = $"{s1}{space}{s2}";
            return Ok(c2);
        }

        [HttpGet]
        [Route("split")]
        public IActionResult Split([FromQuery] string names)
        {
            //emaillist = "melih@melih.com;merbay@merbay.com;mehmetasker@google.com"
            string[] splittedValues = names.Split(",");
            return Ok(splittedValues);
        }

        [HttpGet]
        [Route("replace")]
        public IActionResult Replace([FromQuery] string names)
        {
            string replacedValues = names.Replace("Melih", "Mehmet").Replace("/","\\").Replace("1,645,00","1.645.00");
            return Ok(replacedValues);
        }

        [HttpGet]
        [Route("substringjoin")]
        public IActionResult SubstringJoin()
        {
            //string substring = names.Substring(1,5);
            var join = string.Join(",", new string[] { "Melih", "Mehmet", "Şeyma" });
            return Ok(join);
        }
    }
}
