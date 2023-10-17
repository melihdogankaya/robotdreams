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
            catch (System.IndexOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Exception2")]
        public IActionResult NullReferenceException()
        {
            object o = null;
            try
            {

                var b = o.ToString();
                return Ok();
            }
            catch (System.NullReferenceException ex)
            {
                return BadRequest("Null referans hatası oluştu: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("Exception3")]
        public IActionResult InvalidOperationException()
        {

            try
            {
                List<int> value = new();
                value.Remove(0);
                return Ok();
            }
            catch (System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Exception4")]
        public IActionResult Exception4()
        {

            try
            {
                var a = "aaaaa";
                var c = Convert.ToInt32(a);
                return Ok();
            }
            catch (Exception ex)
            {
                var message = $"Message: {ex.Message} , StackTrace: {ex.StackTrace}";
                _logger.LogError(message);
                return BadRequest(message);
            }
        }

        [HttpGet]
        [Route("Exception5")]
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
                _logger.LogError(message);
                return BadRequest(message);
            }
        }
    }
}