﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model.Studies.Poly;
using RobotDreams.API.Model.Studies.Abst;


namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiesController : ControllerBase
    {
        [HttpGet]
        [Route("Polymorphism")]
        public IActionResult Polymorphism() // birinci sinif ogrencileri icin sadece dil sinav ortalamasi, ikinci sinif ogrencileri icinse hem dil hemde matematik ortalamasini alip, okul ortalamasi hesaplayan controller(sacma sapan bisey). 
        {
            Avarage _avarage = new();
            FirstClassStudent _FirstClassStudent = new("Onur", "Demir", 101, 45, 87);
            SecondClassStudent _SecondClassStudent = new("Ayse", "Aslan", 245, 80, 90, 60, 70);
            _avarage.Add(_FirstClassStudent);
            _avarage.Add(_SecondClassStudent);
            _avarage._Avarage = _avarage.SchoolAvarage();
            string _avarageSerialized = JsonConvert.SerializeObject(_avarage);
            return Ok(_avarageSerialized);
        }

        [HttpGet]
        [Route("Abstract Class")]
        public IActionResult AbstractClass() //  Muhendisler ve mimarlar beraber bir proje yapmaktadir.
        {
            Architect architecturalDrawing = new Architect() { System = "Facade", Description = "Cephe cizimleri" };
            MechanicalEngineer mechanicalDrawing = new MechanicalEngineer() { System = "HVAC", Description = "Isitma, Sogutma ve Havalandirma cizimleri" };
            ElectricalEngineer electricalDrawing = new ElectricalEngineer() { System = "Electrical Systems", Description = "Zayif akim sistemleri" };
           
            Engineers MechEngineer = new Engineers() { Name = "Onur", Surname = "Demir", HowToDraw = mechanicalDrawing.Draw() };
            Engineers ElecEngineer = new() { Name = "Gozde", Surname = "Cetin", HowToDraw =electricalDrawing.Draw() };
            Engineers Architect = new() { Name = "Metin" , Surname = "Cakmak" , HowToDraw= architecturalDrawing.Draw() };




            return Ok();
        }
    }
}
