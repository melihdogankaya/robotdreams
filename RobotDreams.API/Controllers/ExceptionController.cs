using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model;
using RobotDreams.API.Model.GenericType;

namespace RobotDreams.API.Controllers
{
    
    public class ExceptionController : Controller
    {
        private ILogger<ExceptionController> _logger;
        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("Exception")]
        public IActionResult IndexOutofRangerException()
        {
            try
            {
                var arr = new int[3];
                var c = arr[arr.Length + 2];
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Exception2")]
        public IActionResult NullReferenceException()
        {

            try
            {
                object o = null;
                o.ToString();
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
                List<int> value = new();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("Exception4")]
        public IActionResult  Exception4()
        {

            try
            {
                var a = "aaaaaa";
                var c = Convert.ToInt32(a);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = $"Message: {ex.Message}, StackTrace: {ex.StackTrace}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet]
        [Route("Exception5")]
        public IActionResult Exception5()
        {

            Car car = new Car();

            try
            {
                
                car.IsHatchback("Ferrari");
                return Ok();
            }
            catch (Exception ex)
            {
                var message = $"Message: {ex.Message}, StackTrace: {ex.StackTrace}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }
    }
}