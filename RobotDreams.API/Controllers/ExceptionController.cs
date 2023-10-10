using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    public class ExceptionController : Controller
    {
        private ILogger<ExceptionController> _logger;

        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("exception1")]
        public IActionResult IndexOutOfRangeException()
        {
            try
            {
                var arr = new int[3];
                var c = arr[arr.Length + 1];
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("exception2")]
        public IActionResult NullReferenceException()
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
        [Route("exception3")]
        public IActionResult InvalidOperationException()
        {
            try
            {
                List<int> values = new();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("exception4")]
        public IActionResult Exception()
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
                _logger.LogError(message);
                return BadRequest(message);
            }
        }
    }
}

