using Microsoft.AspNetCore.Mvc;

namespace RobotDreams.API.Controllers
{
    public class AbstractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
