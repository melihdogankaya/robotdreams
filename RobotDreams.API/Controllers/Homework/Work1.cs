using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model.Homework;

namespace RobotDreams.API.Controllers.Homework
{
    [Route("api/[controller]")]
    [ApiController]
    public class Work1 : ControllerBase
    {
        [HttpGet]
        [Route("Work1")]
        public IActionResult Work(double number1, double number2)
        {
            Model.Homework.GenericClass work1 = new()
            {
                Number1 = number1,
                Number2 = number2
            };
            string result;

            try
            {
                result = JsonConvert.SerializeObject(work1.Divide().ToString
                    ());
                return Ok(result);
            }
            catch (Exception ex)
            {
                result = JsonConvert.SerializeObject("Hata : " + ex.ToString() + " Bir sayıyı 0'a bölemezsiniz. Bölünecek Sayı : " + number1.ToString());
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("Work2")]
        public IActionResult Work2(int x)
        {
            try
            {
                int divide = 12 / x;
                return Ok(divide);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }
    }
}
