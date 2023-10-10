using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.GenericType;

namespace RobotDreams.API.Controllers
{
    public class ExceptionController : Controller
    {
        [HttpGet]
        [Route("Exception")]
        public IActionResult IndexOutofRangerException()
        {

            try
            {
                var arr = new int[3];

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Exception2")]
        public IActionResult NullreferenceException()
        {

            try
            {
                object o = null;
                var b = o.ToString();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Exception3")]
        public IActionResult InvalidOperationException()
        {

            try
            {
                Generic<int> values = new();
                //values.Add(1);
               // values.Remove(1)
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }

        [HttpGet]
        [Route("Exception")]
        public IActionResult Exception()
        {

            try
            {
                var a = "aaaa";
                var c = Convert.ToInt32(a);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = $"Message: {ex.Message}, StackTrace: {ex.StackTrace}";
                return BadRequest();

            }
        }
    }
}