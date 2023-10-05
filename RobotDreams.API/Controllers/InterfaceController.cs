using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.Interface;

namespace RobotDreams.API.Controllers
{
    public class InterfaceController : Controller
    {
        [HttpGet]
        [Route("Example1")]
        public IActionResult InterfaceExample()
        {
            Player player = new() { Name = "BattalGazi", Age = 30, LifeBar = 100, Weapon = new M51() };
            return Ok(player.TakeAim());
        }
    }
}
