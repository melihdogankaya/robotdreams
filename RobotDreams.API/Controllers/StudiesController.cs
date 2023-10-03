﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model2;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudiesController : ControllerBase
    {
        [HttpGet]
        [Route("polymorphism")]
        public IActionResult polymorphism2()
        {
            Avarage avarage = new();

            FirstClassStudent _FirstClassStudent = new("Onur", "Demir", 101, 45, 87);
            SecondClassStudent _SecondClassStudent = new("Ayse", "Aslan", 245, 80, 90, 60, 70);

            avarage.Add(_FirstClassStudent);
            avarage.Add(_SecondClassStudent);

            avarage._Avarage = avarage.SchoolAvarage();


            string AvarageSerialized = JsonConvert.SerializeObject(avarage);

            return Ok(AvarageSerialized);



        }

    }
}
