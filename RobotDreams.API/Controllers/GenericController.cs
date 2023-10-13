using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
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
=======
using RobotDreams.API.Model;
using RobotDreams.API.Model.GenericType;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers
{
    public class GenericController : Controller
    {
        [HttpGet]
        [Route("GenericType1")]
>>>>>>> mehmetasker
        public IActionResult GenericTypeExample()
        {
            Generic<string> g = new()
            {
                Field = "A String"
            };
<<<<<<< HEAD
=======

>>>>>>> mehmetasker
            return Ok(g.Field.GetType().FullName);
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("genericType2")]
=======
        [Route("GenericType2")]
>>>>>>> mehmetasker
        public IActionResult GenericTypeExample2()
        {
            Generic<int> g = new()
            {
                Field = 1
            };
<<<<<<< HEAD
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
=======

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
>>>>>>> mehmetasker
                g.Code = 400;
                g.Message = "Brand is mandatory";
            }
            else
<<<<<<< HEAD
            {
=======
            {//Yukarıda sorun yok ise Dışarıya içerdekileri yolla
>>>>>>> mehmetasker
                g.Code = 200;
                g.Message = "Successful";
                g.Field = c;
            }

            return Ok(JsonConvert.SerializeObject(g));
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("genericType4")]
=======
        [Route("GenericType4")]
>>>>>>> mehmetasker
        public IActionResult GenericTypeExample4()
        {
            Generic2<string, int> g2 = new();
            g2.Key = "Success";
            g2.Value = 200;
            return Ok(JsonConvert.SerializeObject(g2));
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("genericType5")]
        public IActionResult GenericTypeExample5()
        {
            var list = new List<Car>
            {
                new Car { Brand = "Ferrari", Model = "Enzo", Color = "Kırmızı" },
                new Car { Brand = "Ferrari", Model = "F50", Color = "Sarı" }
            };
=======
        [Route("GenericType5")]
        public IActionResult GenericTypeExample5()
        {
            var list = new List<Car>(); //List bir Generic Type tır
            list.Add(new Car { Brand = "Ferrari", Model = "Enzo", Color = "Kırmızı" });
            list.Add(new Car {Brand = "Fiat", Model="picap", Color="Mavi", EnginePowerCc = 2500, Hatchback= true });
>>>>>>> mehmetasker
            return Ok(JsonConvert.SerializeObject(list));
        }
    }
}

<<<<<<< HEAD
=======


















>>>>>>> mehmetasker
