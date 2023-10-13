using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
=======
using RobotDreams.API.Model;
>>>>>>> mehmetasker
using RobotDreams.API.Model.Interface;

namespace RobotDreams.API.Controllers
{
<<<<<<< HEAD
    [Route("api/[controller]")]
    [ApiController]
    public class InterfaceController : ControllerBase
    {
        [HttpGet]
        [Route("example1")]
        public IActionResult InterfaceExample()
        {
            Player player = new() { Name = "Lucifer", Age = 30, Weapon = new M51()};
=======
    public class InterfaceController : Controller
    {
        [HttpGet]
        [Route("Example1")]
        public IActionResult InterfaceExample()
        {
            Player player = new() { Name = "BattalGazi", Age = 30, LifeBar = 100, Weapon = new M51() };
>>>>>>> mehmetasker
            return Ok(player.TakeAim());
        }
    }
}
