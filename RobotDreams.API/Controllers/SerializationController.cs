using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Context.Domain;
using RobotDreams.API.Model.Serialization;
using System.Data;
using System.Text.Json;
using System.Xml.Serialization;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerializationController : ControllerBase
    {
        [HttpGet]
        [Route("getfromjsonmicrosoft")]
        public async Task<IActionResult> Example1()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            SerializeUser? user = await client.GetFromJsonAsync<SerializeUser>("users/1");

            return Ok(user?.Username);
        }

        [HttpGet]
        [Route("getfromjsonnewtonsoft")]
        public async Task<IActionResult> Example2()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            var response = await client.GetAsync("users/1");
            var s = await response.Content.ReadAsStringAsync();

            SerializeUser? user = Newtonsoft.Json.JsonConvert.DeserializeObject<SerializeUser>(s);

            return Ok(user?.Username);
        }

        [HttpGet]
        [Route("postasjsonmicrosoft")]
        public async Task<IActionResult> Example3()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            SerializeUser? user = await client.GetFromJsonAsync<SerializeUser>("users/1");

            if (user != null)
                user.Username = "mdogankaya";

            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);

            return Ok(user?.Username);
        }

        [HttpGet]
        [Route("getasyncmicrosoft")]
        public async Task<IActionResult> Example4()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            SerializeUser? user = null;
            int counter = 30;

            for (int i = 1; i <= counter; i++)
            {
                var response = await client.GetAsync($"users/{i}");
                if (!response.IsSuccessStatusCode)
                {
                    counter = i;
                    break;
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    user = JsonSerializer.Deserialize<SerializeUser>(content);
                }
            }

            return Ok($"{counter}.kullanıcı yok.");
        }

        [HttpGet]
        [Route("getfromjsonmicrosoft2")]
        public async Task<IActionResult> Example5()
        {
            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
            };

            List<SerializeUser?> user = new();

            var response = await client.GetFromJsonAsync<List<SerializeUser?>>($"users");
            var lastUser = response.LastOrDefault();

            return Ok($"{lastUser?.Id + 1}. kullanıcı yok.");
        }

        [HttpGet]
        [Route("serializedatasetxml")]
        public IActionResult Example6()
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));
            DataSet ds = new DataSet("myDataSet");
            DataTable dt = new DataTable("table1");
            DataColumn c = new DataColumn("thing");

            dt.Columns.Add(c);
            ds.Tables.Add(dt);

            DataRow r;

            for (int i = 0; i < 10; i++)
            {
                r = dt.NewRow();
                r[0] = "Thing " + i;
                dt.Rows.Add(r);
            }

            TextWriter writer = new StreamWriter(Guid.NewGuid().ToString() + ".xml");
            ser.Serialize(writer,ds);
            writer.Close();

            return Ok();
        }

        [HttpGet]
        [Route("serializedatasetxml2")]
        public IActionResult Example7()
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<User>));

            var o = new List<User>
            {
                new User { Id = Guid.NewGuid(), Email = "mdogankaya@gmail.com", Name = "Melih" }
            };

            TextWriter writer = new StreamWriter(Guid.NewGuid().ToString() + ".xml");
            ser.Serialize(writer, o);
            writer.Close();

            return Ok();
        }
    }
}
