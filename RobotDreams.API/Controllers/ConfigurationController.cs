using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RobotDreams.API.Model.Settings;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly ConfigurationSettings? configurationSettings;

        public ConfigurationController(IConfiguration configuration)
        {
            this.configuration = configuration;
            configurationSettings = configuration.GetRequiredSection("Settings").Get<ConfigurationSettings>();
        }

        [HttpGet]
        [Route("configurationstrongtype")]
        public IActionResult Example1()
        {         
            return Ok(JsonConvert.SerializeObject(configurationSettings));
        }
    }
}
