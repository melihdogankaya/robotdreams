using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model;
using RobotDreams.API.Model.Studies;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    public class GenericController : ControllerBase
    {
        [HttpGet]
        [Route("Generic Example 1")]
        public IActionResult GenericExample1()
        {

            GenericClass<int> genericClass = new()
            {
                Field = 1
            };


            return Ok(genericClass.Field.GetType().FullName);
        }
        [HttpGet]
        [Route("Generic Example 2")]
        public IActionResult GenericExample2()
        {
            GenericClass<Car> genericClass = new()
            {
                Field = new Car { Brand = "BMW", Color = "Blue", EnginePowerCc = 184, Hatchback = true }
            };

            return Ok(JsonConvert.SerializeObject(genericClass));
        }
        [HttpGet]
        [Route("Generic Example 3")]
        public IActionResult GenericExample3()
        {
            GenericClass<Car> genericClass = new()
            {
                Field = new Car() { Brand = "BMW", Model = "F30", Color = "Blue", EnginePowerCc = 184, Hatchback = false },
                Code = 300,
                Message = "Successful"

            };
            return Ok(JsonConvert.SerializeObject(genericClass));
        }
        [HttpGet]
        [Route("Generic Example 4")]
        public IActionResult GenericExample4()
        {
            var car = new Car() { Brand = "Mercedes", Color = "Black", Model = "E series" };

            GenericClass<Car> genericClass = new();

            if (String.IsNullOrEmpty(car.Model))
            {
                genericClass.Code = 200;
                genericClass.Message = " Car model is mandatory!";
                return Ok(JsonConvert.SerializeObject(genericClass));
            }
            else
            {
                genericClass.Field = car;
                genericClass.Code = 400;
                genericClass.Message = "Successful";
                return Ok(JsonConvert.SerializeObject(genericClass));
            }

        }
        [HttpGet]
        [Route("Generic Example 5")]
        public IActionResult GenericExample5()
        {
            var list = new List<Car>
            {
                new Car() { Brand = "BMW", Color = "Black" },
                new Car() { Brand = "Mercedes", Color = "White" }
            };



            return Ok(JsonConvert.SerializeObject(list));
        }

    }
}








