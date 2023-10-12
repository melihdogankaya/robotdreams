using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model;
using RobotDreams.API.Model.GenericType;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
    public class GenericController : Controller
    {
        [HttpGet]
        [Route("GenericType1")]
        public IActionResult GenericTypeExample()
        {
            Generic<string> g = new()
            {
                Field = "A String"
            };

            return Ok(g.Field.GetType().FullName);
        }

        [HttpGet]
        [Route("GenericType2")]
        public IActionResult GenericTypeExample2()
        {
            Generic<int> g = new()
            {
                Field = 1
            };

            //return Ok(g.Field); Eger bunu yaparsan Otomatik olarak Degeri dondurecek
            return Ok(g.Field.GetType().FullName);
        }

        [HttpGet]
        [Route("GenericType3")]
        public IActionResult GenericTypeExample3()
        {
            Car c = new Car()
            {
                Color = "Red",
                Brand = "Ferrari"
            };           

            var g = new Generic<Car>();
            //{//
            //    Field = new Car { Brand =  "Renault" },//Car Clasını Api Olarak Dışarıya donuyoruz
            //    Code = 200,
            //    Message = "Successful"
            //};

            if (string.IsNullOrEmpty(c.Brand))
            {//Burada Yaşanan Olayda Eger Generic c.Brand'ı Boş ise Dışarıya içerdekileri yolla
                g.Code = 400;
                g.Message = "Brand is mandatory";
            }
            else
            {//Yukarıda sorun yok ise Dışarıya içerdekileri yolla
                g.Code = 200;
                g.Message = "Successful";
                g.Field = c;
            }

            return Ok(JsonConvert.SerializeObject(g));
        }

        [HttpGet]
        [Route("GenericType4")]
        public IActionResult GenericTypeExample4()
        {
            Generic2<string, int> g2 = new();
            g2.Key = "Success";
            g2.Value = 200;
            return Ok(JsonConvert.SerializeObject(g2));
        }

        [HttpGet]
        [Route("GenericType5")]
        public IActionResult GenericTypeExample5()
        {
            Generic3<int[]> g3 = new();
            var list = g3.Data.Where(x => x == null).ToList();
            return Ok(JsonConvert.SerializeObject(g3));
        }

        [HttpGet]
        [Route("GenericType6")]
        public IActionResult GenericTypeExample6()
        {
            Model.GenericType.List<Car> a = new();

            return Ok();
        }


    }
}



















