
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model2.Model;

namespace RobotDreams.API.Model2.NewFolder
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiesController : ControllerBase
    {
        [HttpGet]
        [Route("polymorphism")]
        public IActionResult polymorphism2() // birinci sinif ogrencileri icin sadece dil sinav ortalamasi, ikinci sinif ogrencileri icinse hem dil hemde matematik ortalamasini alip, okul ortalamasi hesaplayan controller. 
        {
            Avarage _avarage = new();

            FirstClassStudent _FirstClassStudent = new("Onur", "Demir", 101, 45, 87);
            SecondClassStudent _SecondClassStudent = new("Ayse", "Aslan", 245, 80, 90, 60, 70);
                    
            _avarage.Add(_FirstClassStudent);
            _avarage.Add(_SecondClassStudent);

            _avarage._Avarage = _avarage.SchoolAvarage();

            string AvarageSerialized = JsonConvert.SerializeObject(_avarage);

            return Ok(AvarageSerialized);



        }

    }
}
