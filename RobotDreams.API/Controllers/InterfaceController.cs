using Microsoft.AspNetCore.Mvc;

using RobotDreams.API.Model;

using RobotDreams.API.Model.Interface;

namespace RobotDreams.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        [HttpGet]
        [Route("example1")]
        public IActionResult InterfaceExample1()
        {
            Player player = new() { Name = "Lucifer", Age = 30, Weapon = new M51() };

            return Ok(player);
        }

        
            [HttpGet]
            [Route("Example2")]
            public IActionResult InterfaceExample()
            {
                Player player = new() { Name = "BattalGazi", Age = 30, LifeBar = 100, Weapon = new M51() };

                return Ok(player.TakeAim());
            }
        
    }
}
