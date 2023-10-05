using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Controllers
{
    public class ConditionController : Controller
    {
        [HttpGet]
        [Route("ifelse")]

        public IActionResult Conditionexample(string name)
        {
            string result = string.Empty;
            if (name.StartsWith("m"))
            {
                result = "İsminiz M harfi ile başlıyorsunuz.";
            }
            else if (name.StartsWith("M"))
            {
                result = "İsminiz M harfi ile başlıyor.";
            }
            else
            {
                result = "İsminiz m harfi ile başlamıyor.";
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("switch")]

        public IActionResult Conditionexample2(string teamCode)
        {
            //switch (switch_on)
            //{
            //   case kontrol1:
            //          işlemler1;
            //          break;
            //     default
            //     break;     
            //}

            string result = teamCode switch
            {
                "bjk" => "Beşiktaş",
                "fb" => "Fenerbahçe",
                "gs" => "Galatasaray",
                "ts" => "Trabzon",
                _ => "Hiçbir deger geçerli degil",
            };
            return Ok(result);
        }
    }
}
