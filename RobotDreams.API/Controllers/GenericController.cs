using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model;
using RobotDreams.API.Model.GenericType;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    public class GenericController : Controller
    {
        [HttpGet]
        [Route("genericType1")]
        public IActionResult GenericTypeExample()
        {
            Generic<string> g = new()
            {
                Field = "A String"
            };
            return Ok(g.Field.GetType().FullName);
        }

        [HttpGet]
        [Route("genericType2")]
        public IActionResult GenericTypeExample2()
        {
            Generic<int> g = new()
            {
                Field = 1
            };
            return Ok(g.Field);
        }

        [HttpGet]
        [Route("genericType3")]
        public IActionResult GenericTypeExample3()
        {
            var c = new Car
            {
                Color = "Black",
                Brand = "Fiat"
            };

            var g = new Generic<Car>();

            if (string.IsNullOrEmpty(c.Brand))
            {
                g.Code = 400;
                g.Message = "Brand is mandatory";
            }
            else
            {
                g.Code = 200;
                g.Message = "Successful";
                g.Field = c;
            }

            return Ok(JsonConvert.SerializeObject(g));
        }

        [HttpGet]
        [Route("genericType4")]
        public IActionResult GenericTypeExample4()
        {
            Generic2<string, int> g2 = new();
            g2.Key = "Success";
            g2.Value = 200;
            return Ok(JsonConvert.SerializeObject(g2));
        }

        [HttpGet]
        [Route("genericType5")]
        public IActionResult GenericTypeExample5()
        {
            var list = new List<Car>
            {
                new Car { Brand = "Ferrari", Model = "Enzo", Color = "Kırmızı" },
                new Car { Brand = "Ferrari", Model = "F50", Color = "Sarı" }
            };
            return Ok(JsonConvert.SerializeObject(list));
        }
    }
}

