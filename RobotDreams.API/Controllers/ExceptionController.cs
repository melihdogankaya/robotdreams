using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model;
using RobotDreams.API.Model.GenericType;

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
        [Route("Exception")]
        public IActionResult IndexOutofRangerException()
        {
            try
            {
                var arr = new int[3];
                var c = arr[arr.Length + 1];
                var d = arr[arr.Length + 2];
                return Ok();
            }
            catch (System.IndexOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
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
 
                return Ok(b);
            }
            catch (System.NullReferenceException ex)
            {
                return BadRequest("Null referans hatası oluştu: " + ex.Message);
            }
        }

        [HttpGet]
        [Route("exception3")]
        public IActionResult InvalidOperationException()
        {
            try
            {
                List<int> values = new();
                values.Remove(0);

                return Ok();
            }
            catch (System.InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("exception4")]
        public IActionResult Exception44()
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

        [HttpGet]
        [Route("nullexception")]
        public IActionResult NullException2()
        {
            try
            {
                //DateTime? d = null;
                //byte? b = null;
                //long? l = null;
                //int? o = null;

                //List<int> v = null;

                //v.Add(1);

                int? input2 = null;
                input2.ToString();
                //var c = input2.ToString();
                return Ok();
            }
            catch (Exception ex)
            {
                string exMessage = $"Exception: {ex.Message} StackTrace: {ex.StackTrace}";
                return BadRequest(exMessage);
            }         
        }
    }
}
