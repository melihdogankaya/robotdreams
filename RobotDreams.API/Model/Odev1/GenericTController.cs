using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using RobotDreams.API.Model.Odev1.Attributes;

namespace RobotDreams.API.Model.Odev1
{
    public class GenericTController : Controller
    {
        [HttpGet]
        [Route("ExceptionOdev")]
        public IActionResult ExceptionOdev(string brand)
        {
            try
            {
                GenericEx<string> _marka = new();
                               

                string aracModels = _marka.OtoMarkalari(brand);

                return Ok(aracModels);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace);
            }
        }

    }
}
