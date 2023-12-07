using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Attributes;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Developer("Melih", "5", true)]
    public class AttributeController : ControllerBase
    {
        [HttpGet]
        [Route("getAttributeValues")]
        public IActionResult Example1()
        {
            return Ok(GetAttribute(typeof(AttributeController)));
        }

        private string GetAttribute(Type t)
        {
            DeveloperAttribute myAttr = (DeveloperAttribute)(Attribute.GetCustomAttribute(t, typeof(DeveloperAttribute)));
            return $"Name: {myAttr.Name} -> Level: {myAttr.Level} -> Reviewed: {myAttr.Reviwed}";
        }
    }
}
