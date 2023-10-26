using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Controllers
{
<<<<<<< HEAD
    [Route("api/[controller]")]
    [ApiController]
    public class ConditionController : ControllerBase
    {
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("if")]
        public IActionResult ConditionExample(string name)
        {
            string result;

            if (name.StartsWith("m"))
            {
                result = "İsminiz m harfi ile başlıyor.";
=======
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
>>>>>>> mehmetasker
            }
            else if (name.StartsWith("M"))
            {
                result = "İsminiz M harfi ile başlıyor.";
            }
<<<<<<< HEAD
            else if (name.StartsWith("Ö"))
            {
                result = "İsminiz Ö harfi ile başlıyor.";
            }
=======
>>>>>>> mehmetasker
            else
            {
                result = "İsminiz m harfi ile başlamıyor.";
            }
<<<<<<< HEAD

=======
>>>>>>> mehmetasker
            return Ok(result);
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("switchcase")]
        public IActionResult ConditionExample2(string teamCode)
=======
        [Route("switch")]

        public IActionResult Conditionexample2(string teamCode)
>>>>>>> mehmetasker
        {
            //switch (switch_on)
            //{
            //    case kontrol1:
            //         işlemler1;
            //         break;
            //    default:
            //    break;
            //}

            //switch (teamCode)
            //{
            //    case "bjk":
            //        result = "Beşiktaş";
            //        break;
            //    case "fb":
            //        result = "Fenerbahçe";
            //        break;
            //    case "gs":
            //        result = "Galatasaray";
            //        break;
            //    case "ts":
            //        result = "Trabzonspor";
            //        break;
            //    default:
            //        result = "Hiçbir değer geçerli değil.";
            //        break;
            //}

            string result = teamCode switch
            {
                "bjk" => "Beşiktaş",
                "fb" => "Fenerbahçe",
                "gs" => "Galatasaray",
<<<<<<< HEAD
                "ts" => "Trabzonspor",
                _ => "Hiçbir değer geçerli değil."
            };

=======
                "ts" => "Trabzon",
                _ => "Hiçbir deger geçerli degil",
            };
>>>>>>> mehmetasker
            return Ok(result);
        }
    }
}
