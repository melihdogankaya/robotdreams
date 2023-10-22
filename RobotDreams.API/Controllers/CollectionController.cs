using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        [HttpGet]
        [Route("collectionlist")]
        public IActionResult Example1()
        {
            List<int> intList = new();
            intList.Add(1);
            return Ok();
        }

        [HttpGet]
        [Route("collectionqueue")]
        public IActionResult Example2()
        {
            var q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);

            //q.Dequeue();
            q.Peek();

            return Ok(JsonConvert.SerializeObject(q));
        }

        [HttpGet]
        [Route("collectiondictionary")]
        public IActionResult Example3()
        {
            var dict = new Dictionary<string, object>();

            dict.Add("parameter1", "Melih");
            dict.Add("parameter2", 1);
            dict.Add("isActive", true);

            var parameter2 = dict.FirstOrDefault(p => p.Key == "parameter2").Value;

            return Ok(parameter2);
        }

        [HttpGet]
        [Route("collection")]
        public IActionResult Example4()
        {

            return Ok();
        }
    }
}