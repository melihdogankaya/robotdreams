using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.GenericType;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Homework01Controller : ControllerBase
    {
        [HttpGet]
        [Route("Exceptions")]
        public IActionResult GenericTypeAndExceptions(string input1, string? input2=null)
        {
            Homework01Generic<int> homework01Generic = new Homework01Generic<int>();

            try
            {
                string test = input2.GetType().Name;
                int number1 = Convert.ToInt32(input1);
                int number2 = Convert.ToInt32(input2);
                

                homework01Generic.Result = number1 * number2;
                homework01Generic.Message = "Input 1 multiply by Input 2 = ";

                return Ok(homework01Generic.Message + homework01Generic.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetType().Name);
            }



        }
    }
}
