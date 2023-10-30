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
            string s1 = "Mehmet";
            string s2 = "Asker";
            string space = " ";
            //s1 += space + s2;
            //string c = string.Concat(s1,space,s2);
            string c2 = $"{s1}{space}{s2}";
            return Ok(c2);
        }

        [HttpGet]
        [Route("Split")]
        public IActionResult Split([FromBody] string names)
        {// Bunu Ayraç olarak kullanıyoruz mesala Mehmet@lsklda.com;layane@layane.com gibi ; sonrasını ayr
            string[] splittedValue = names.Split(",");

            return Ok(splittedValue);
        }

        [HttpGet]
        [Route("replace")]
        public IActionResult Replace([FromBody] string name)
        {//                                     Degiştir => "Bunu","buna" çevir
            string reblaceValue = name.Replace("Mehmet", "Ahmet").Replace("\"", "/").Replace("1,655,00", "1.655.00");

            return Ok(reblaceValue);
        }

        [HttpGet]
        [Route("substring")]
        public IActionResult Substring([FromBody] string name)
        {//                                    1 dan basla 5 e kadar ilerle ve arasındakileri al
            string substring = name.Substring(1,5);

            return Ok(substring);
        }


    }
}
