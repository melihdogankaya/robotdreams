using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model.Abstract;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractController : ControllerBase
    {
        [HttpGet]
        [Route("example1")]
        public IActionResult Abstract1()
        {
            Guitar guitar = new() { Name = "ESP", Description = "Amerika üretimi" };
            Drum drum = new() { Name = "Tama", Description = "Japon üretimi" };
            Piano piano = new() { Name = "Kawai", Description = "Japon üretimi" };

            Musician guitarist = new() { Name = "James", Surname = "Hetfield", Instrument = guitar, HowToPlay = guitar.Play() };
            Musician drummer = new() { Name = "Lars", Surname = "Ulrich", Instrument = drum, HowToPlay = drum.Play() };
            Musician pianist = new() { Name = "Lang", Surname = "Lang", Instrument = piano, HowToPlay = piano.Play() };

            string serializedGuitarist = JsonConvert.SerializeObject(guitarist);
            string serializedDrummer = JsonConvert.SerializeObject(drummer);
            string serializedPianist = JsonConvert.SerializeObject(pianist);

            string result = serializedDrummer + serializedPianist + serializedGuitarist;

            return Ok(result);
        }
    }
}
