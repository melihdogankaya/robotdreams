using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.Interface;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        [HttpGet]
        [Route("example1")]
        public IActionResult InterfaceExample()
        {
            Player player = new() { Name = "Lucifer", Age = 30, Weapon = new M51()};
            return Ok(player.TakeAim());
        }
    }
}
