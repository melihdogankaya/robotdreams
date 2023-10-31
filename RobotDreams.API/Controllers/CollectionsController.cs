using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {

        [HttpGet]
        [Route("Collections1")]
        public IActionResult Example1 ()
        {
            List <decimal> list = new();
            list.Add (1);
            list.Add(2);
            
            return Ok(list.Count());
        }

        [HttpGet]
        [Route("Collections2-Queue")]
        public IActionResult Example2 ()
        {
            var q= new Queue<decimal>();    
            q.Enqueue (1);
            q.Enqueue (2);
            q.Enqueue (3);

            q.Dequeue ();

            return Ok(JsonConvert.SerializeObject(q));
        }
        [HttpGet]
        [Route("Dictionary")]
        public IActionResult Example3 ()
        {
            var dict = new Dictionary<string, decimal> ();
            dict.Add("Onur Demir", 3.14m);
            dict.Add("Ayhan Akgunduz", 42);

            return Ok(JsonConvert.SerializeObject(dict));
        }

    }
}