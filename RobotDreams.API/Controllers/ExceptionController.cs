using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    public class ExceptionController : Controller
    {
        private ILogger<ExceptionController> _logger;

=======
using RobotDreams.API.Model;
using RobotDreams.API.Model.GenericType;

namespace RobotDreams.API.Controllers
{
    
    public class ExceptionController : Controller
    {
        private ILogger<ExceptionController> _logger;
>>>>>>> mehmetasker
        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }
<<<<<<< HEAD

        [HttpGet]
        [Route("exception1")]
        public IActionResult IndexOutOfRangeException()
=======
        [HttpGet]
        [Route("Exception")]
        public IActionResult IndexOutofRangerException()
>>>>>>> mehmetasker
        {
            try
            {
                var arr = new int[3];
<<<<<<< HEAD
                var c = arr[arr.Length + 1];
=======
                var c = arr[arr.Length + 2];
>>>>>>> mehmetasker
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("exception2")]
        public IActionResult NullReferenceException()
        {
            try
            {
                object o = null;
                var b = o.ToString();
=======
        [Route("Exception2")]
        public IActionResult NullReferenceException()
        {

            try
            {
                object o = null;
                o.ToString();
>>>>>>> mehmetasker
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("exception3")]
        public IActionResult InvalidOperationException()
        {
            try
            {
                List<int> values = new();
=======
        [Route("Exception3")]
        public IActionResult InvalidOperationException()
        {

            try
            {
                List<int> value = new();

>>>>>>> mehmetasker
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("exception4")]
        public IActionResult Exception()
        {
            try
            {
                var a = "aaaaa";
=======
        [Route("Exception4")]
        public IActionResult  Exception4()
        {

            try
            {
                var a = "aaaaaa";
>>>>>>> mehmetasker
                var c = Convert.ToInt32(a);
                return Ok();
            }
            catch (Exception ex)
            {
<<<<<<< HEAD
                var message = $"Message: {ex.Message} , StackTrace: {ex.StackTrace}";
=======
                var message = $"Message: {ex.Message}, StackTrace: {ex.StackTrace}";
>>>>>>> mehmetasker
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("exception5")]
        public IActionResult Exception5()
        {
            try
            {
                var a = "aaaaa";
                var c = Convert.ToInt32(a);
                return Ok();
            }
            catch (Exception ex) when (ex.Message.Contains("input"))
            {
                var message = $"Message: {ex.Message} , StackTrace: {ex.StackTrace}";
=======
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
>>>>>>> mehmetasker
                _logger.LogError(message);
                return BadRequest(message);
            }
        }
    }
<<<<<<< HEAD
}

=======
}
>>>>>>> mehmetasker
