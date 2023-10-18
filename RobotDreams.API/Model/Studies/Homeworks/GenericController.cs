using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model.Studies.Poly;

namespace RobotDreams.API.Model.Studies.Homeworks
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController : ControllerBase
    {
        [HttpGet]
        [Route("Generic Homework")]
        public IActionResult StudentAvarage(string nameSurname, int iD, int examResult1, int examResult2)
        {

            try
            {
                Student student = new()
                {
                    NameSurname = nameSurname,
                    ID =iD,
                    ExamResult1 =examResult1,
                    ExamResult2 = examResult2
                };
                GenericAvarageClass<Student> student1 = new()
                {
                    Field = student,
                    StudentAvarage = student.AvarageCalculation()
                };
                if (student.AvarageCalculation() >= 70)
                {
                    student1.Code = 400;
                    student1.Message = "Successful - You can continue to play Computer Games! ";
                }
                else
                {
                    student1.Code = 200;
                    student1.Message = "Failed - Go study harder before you play! ";
                }

                return Ok(JsonConvert.SerializeObject(student1));

            }
            catch (Exception ex)
            {
                return Ok("NameSurname is mandatory");
            }

            
        }
    }
}

