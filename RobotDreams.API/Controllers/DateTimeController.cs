using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;

namespace RobotDreams.API.Controllers
{
    public class DateTimeController : Controller
    {
        [HttpGet]
        [Route("datetostring")]
        public IActionResult Example1()
        {
            List<string> result = new List<string>();
            CultureInfo[] cultere = new CultureInfo[] { CultureInfo.InvariantCulture,
                                                        new CultureInfo("en-US"),
                                                        new CultureInfo("fr-Fr"),
                                                        new CultureInfo("de-DE"),
                                                        new CultureInfo("es-ES"),
                                                        new CultureInfo("ja-JP")
            };

            var now = DateTime.Now;

            foreach (var cultureInfo in cultere)
            {
                string cultureName;
                if (string.IsNullOrEmpty(cultureInfo.Name))
                {
                    cultureName = cultureInfo.NativeName;
                }
                else
                {
                    cultureName = cultureInfo.Name;
                }

                result.Add($"In {cultureName}, {now.ToString(cultureInfo)}");

            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("datetostringFormatlama2")]
        public IActionResult FormatlamaExample2()
        {
            List<string> result = new List<string>();
            var date = DateTime.Now; //new DateTime(1988, 6, 15, 18, 35, 56);

            string[] standartFrmt = { "d", "D", "f", "F", "g", "G", "m", "o", "R", "s", "t", "T", "u", "U", "y" };

            foreach (var item in standartFrmt)
            {
                result.Add($"{item}: {date.ToString(item)}");
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("datetostringCustomFormat3")]
        public IActionResult FormatlamaExample3()
        {
            List<string> result = new List<string>();
            var date = DateTime.Now; //new DateTime(1988, 6, 15, 18, 35, 56);

            string[] customFormats = { "h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f" };

            foreach (var item in customFormats)
            {
                result.Add($"{item}: {date.ToString(item)}");
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("datetostring4")]
        public IActionResult FormatlamaExample4()
        {
            var date = DateTime.Now; //new DateTime(1988, 6, 15, 18, 35, 56);

            return Ok(date.ToString("G"));
        }

        [HttpGet]
        [Route("datetimeExample5")]
        public IActionResult Example5()
        {
            var stringDate = "15/10/23 19:27";

            var isDatetimeCorrect = DateTime.TryParse(stringDate, out DateTime result);

            if (isDatetimeCorrect)
            {
                result.AddDays(3);
            }

            return Ok(result.ToString("G"));
        }

        [HttpGet]
        [Route("datetimeExample6")]
        public IActionResult GecenZamanExample6()
        {
            var date = new DateTime(1988, 01, 18, 06, 15, 0);
            var date2 = DateTime.Now;
            TimeSpan diff1 = date2.Subtract(date);

            var result = $"Ben dogalı bu kadar zaman geçmiş: {diff1.TotalHours}";

            return Ok(result);
        }

        [HttpGet]
        [Route("datetimeUTC7")]
        public IActionResult Example7()
        {
            var dateUtc = DateTime.UtcNow;
            var date = DateTime.Now;

            TimeSpan diff = date.Subtract(dateUtc);

            return Ok(diff.TotalHours);
        }

        [HttpGet]
        [Route("datetimeunixpoch")] // Linux ile ilgili herhangi bir işlem için Bunu yazyoruz.
        public IActionResult Example8()
        {
            long unixTimeStampInTicks = (DateTime.UtcNow - DateTime.UnixEpoch).Ticks;

            return Ok((double)unixTimeStampInTicks / TimeSpan.TicksPerSecond);
        }
    }
}
