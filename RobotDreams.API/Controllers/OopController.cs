using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OopController : ControllerBase
    {
        [HttpGet]
        [Route("oop1")]
        public IActionResult Oop1()
        {
            Shoe _shoe = new()
            {
               
            };

            string serializedShoe = JsonConvert.SerializeObject(_shoe);

            return Ok(serializedShoe);
        }

        [HttpGet]
        [Route("oop5")]
        public IActionResult Oop2()
        {
            Car _car = new();

            string carSerialized = JsonConvert.SerializeObject(_car);

            return Ok(carSerialized);
        }

        [HttpGet]
        [Route("oop4")]
        public IActionResult Oop3(int enginePower)
        {
            Ferrari ferrariObject = new();
            ferrariObject.EnginePowerCc = enginePower;
            ferrariObject.Model = "F50";

            ferrariObject.Hatchback = ferrariObject.IsHatchback(ferrariObject.Brand);

            string ferrariSerialized = JsonConvert.SerializeObject(ferrariObject);

            return Ok(ferrariSerialized);
        }

        [HttpGet]
        [Route("polymorphism")]
        public IActionResult Polymorphism()
        {
            Basket _basket = new();

            var _bakiye = new Product();
            _bakiye.Balance = 150000;
         

            Bread _bread = new("Uno", 35, "Tam Buğday", 500, _bakiye.Balance);
            MobilePhone _mobilePhone = new("iPhone", 50000, "Apple", _bakiye.Balance);
            Delicatessen _icecekler = new("AyıBogan","Sarap",1000,"Turkiye",15000,_bakiye.Balance);

            _basket.Add(_bread);
            _basket.Add(_mobilePhone);
            _basket.Add(_icecekler);


            _basket._TotalPrice = _basket.TotalPrice();

            string basketSerialized = JsonConvert.SerializeObject(_basket);

            return Ok(basketSerialized);
        }

        
    }
}
