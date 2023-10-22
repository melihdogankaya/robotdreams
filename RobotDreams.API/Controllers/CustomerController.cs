using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model.Passenger;
using System.Security.Cryptography.X509Certificates;

namespace RobotDreams.API.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("Yolcular")]
        public IActionResult musteriler()
        {
            Payment _odemeAl = new Payment();

            Bus _otobus = new(1234, "Mehmet", "Asker", 15000, 35, 25);

            Plane _ucak = new(4567, "Layane", "Asker", 30000, 25, 75);

            _odemeAl.Ekle(_otobus);
            _odemeAl.Ekle(_ucak);

            _odemeAl._ToplamPayment = _odemeAl.ToplamOdeme();

            string odemeyi_al = JsonConvert.SerializeObject(_odemeAl);



            return Ok(odemeyi_al);
        }
    }
}
