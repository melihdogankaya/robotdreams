using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoopController : ControllerBase
    {

        [HttpGet]
        [Route("For")]
        public IActionResult Loop_For_1()
        {
            List<int> number = new();
            for (int i = 0; i < 100; i++)
            {
                number.Add(i);
            }
            return Ok(JsonConvert.SerializeObject(number));
        }
        [HttpGet]
        [Route("For_2")]
        public IActionResult Loop_for_2()
        {
            List<int> tekSayilar = new();
            for (int i = 0; i <= 100; i++)
            {
                if (i % 2 == 1)
                    tekSayilar.Add(i);
            }
            return Ok(JsonConvert.SerializeObject(tekSayilar));
        }
        [HttpGet]
        [Route("While")]
        public IActionResult Loop_While_1()
        {
            List<int> number = new();
            int i = 0;
            while (i <100 )
            {
                number.Add(i);
                i++;
            }
            return Ok(JsonConvert.SerializeObject(number));

        }
        [HttpGet]
        [Route("Foreach")]
        public IActionResult Loop_Foreach()
        {

            List<int> number = new();
            List<int> number2 = new();
            for (int i = 0; i < 10; i++)
            {
                number.Add(i);
            }
            
            foreach (var i in number)
            {
                if(i%2 == 0)
                number2.Add(i);
            }
            
            return Ok(number2);

        }

        [HttpGet]
        [Route("Do-While")]
        public IActionResult DoWhile()
        {

            List <int> numbers =new();
            int i = 3;
            do
            {
                numbers.Add(i);
                i++;


            } while (i<=2);



            return Ok(numbers);
        }
        


    }
}
