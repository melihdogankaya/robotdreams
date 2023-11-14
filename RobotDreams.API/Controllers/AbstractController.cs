using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using RobotDreams.API.Helper;
using RobotDreams.API.Model.Abstract;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbstractController : ControllerBase
    {
        private readonly LanguageService _languageService;

        public AbstractController(LanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet]
        [Route("example1")]
        public IActionResult Abstract1(string culture)
        {
            Guitar guitar = new() { Name = "ESP", Description = _languageService.GetKey("American.Product") };
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
