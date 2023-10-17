using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using Microsoft.VisualBasic;
>>>>>>> mehmetasker
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
<<<<<<< HEAD
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
=======
    public class CollectionController : Controller
    {
        [HttpGet]
        [Route("Collectionlist")]
        public IActionResult Examle1()
        {
            List<int> intList = new();
            intList.Add(1);

            IEnumerable<int> intList2; // DAtabase'ten VEri çekilecegi zamn IEnumerable ile işlemden direk kullanmak için yardım eder

            return Ok(intList);
        }

        [HttpGet]
        [Route("Collectionqueue")]
        public IActionResult Examle2()
>>>>>>> mehmetasker
        {
            var q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
<<<<<<< HEAD

            //q.Dequeue();
            q.Peek();
=======
            q.Enqueue(4);
            q.Enqueue(8); // Enqueue En sona Ekler

            q.Dequeue();// Dequeue en Eski elamanı Siler
            q.Dequeue();
            q.Dequeue();
>>>>>>> mehmetasker

            return Ok(JsonConvert.SerializeObject(q));
        }

        [HttpGet]
<<<<<<< HEAD
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
=======
        [Route("Collectiondictionnary")]
        public IActionResult Examle3()
        {
            var dict = new Dictionary<string, object>();

            dict.Add("parametre1", "Mehmet");
            dict.Add("parametre", 1);
            dict.Add("isActive", true);

            var parametre2 = dict.FirstOrDefault(p => p.Key == "parametre2").Value;
            // FirstOrDefault koleksiyonlar üzerinde filtreleme işlemleri yaparken veya bir öğeyi bulma işlemleri için Kullanabiliriz
            return Ok(parametre2);
        }

        [HttpGet]
        [Route("Collection")]
        public IActionResult Examle4()
        {
            
            return Ok();
        }




>>>>>>> mehmetasker
    }
}
