using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
<<<<<<< HEAD
using System;
=======
>>>>>>> mehmetasker
using System.Globalization;

namespace RobotDreams.API.Controllers
{
<<<<<<< HEAD
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
    {
        [HttpGet]
        [Route("datetostring1")]
        public IActionResult Example1()
        {
            List<string> result = new();

            CultureInfo[] culture = new CultureInfo[] {CultureInfo.InvariantCulture,
                                                       new CultureInfo("en-US"),
                                                       new CultureInfo("fr-fr"),
                                                       new CultureInfo("de-de"),
                                                       new CultureInfo("es-ES"),
                                                       new CultureInfo("ja-JP")
            };

            var now = new DateTime(2009,5,1,9,0,0);

            foreach (var cultureInfo in culture)
=======
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
>>>>>>> mehmetasker
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
<<<<<<< HEAD
=======

>>>>>>> mehmetasker
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("datetostring2")]
        public IActionResult Example2()
        {
            List<string> result = new();

            var date = DateTime.Now; //new DateTime(2008, 6, 15, 19, 18, 05);
            string[] standardFmts = { "d", "D", "f", "F", "g", "G", "m", "o", "R", "s", "t", "T", "u", "U", "y"};

            foreach (var item in standardFmts)
=======
        [Route("datetostringFormatlama2")]
        public IActionResult FormatlamaExample2()
        {
            List<string> result = new List<string>();
            var date = DateTime.Now; //new DateTime(1988, 6, 15, 18, 35, 56);

            string[] standartFrmt = { "d", "D", "f", "F", "g", "G", "m", "o", "R", "s", "t", "T", "u", "U", "y" };

            foreach (var item in standartFrmt)
>>>>>>> mehmetasker
            {
                result.Add($"{item}: {date.ToString(item)}");
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("datetostring3")]
        public IActionResult Example3()
        {
            List<string> result = new();

            var date = DateTime.Now; //new DateTime(2008, 6, 15, 19, 18, 05);
=======
        [Route("datetostringCustomFormat3")]
        public IActionResult FormatlamaExample3()
        {
            List<string> result = new List<string>();
            var date = DateTime.Now; //new DateTime(1988, 6, 15, 18, 35, 56);

>>>>>>> mehmetasker
            string[] customFormats = { "h:mm:ss.ff t", "d MMM yyyy", "HH:mm:ss.f" };

            foreach (var item in customFormats)
            {
                result.Add($"{item}: {date.ToString(item)}");
            }

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpGet]
        [Route("datetostring4")]
<<<<<<< HEAD
        public IActionResult Example4()
        {
            var date = DateTime.Now; //new DateTime(2008, 6, 15, 19, 18, 05);
            return Ok(date.ToString("D"));
        }

        [HttpGet]
        [Route("datetimeexample1")]
        public IActionResult Example5()
        {
            var a = string.Empty;
            var stringDate = "45/10/2023 19:27";

            //DateTime.Parse(stringDate);
=======
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

>>>>>>> mehmetasker
            var isDatetimeCorrect = DateTime.TryParse(stringDate, out DateTime result);

            if (isDatetimeCorrect)
            {
<<<<<<< HEAD
                a = result.AddDays(1).ToString("G");
            }

            return Ok(a);
        }

        [HttpGet]
        [Route("datetimesubtract")]
        public IActionResult Example6()
        {
            var date = new DateTime(1993, 9, 21, 18, 40, 0);
            var date2 = new DateTime(2023, 10, 13, 19, 40, 0);
            TimeSpan diff1 = date2.Subtract(date);

            var result = $"Ben doğalı şu kadar saat geçmiş: {diff1.TotalDays}";
=======
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
>>>>>>> mehmetasker

            return Ok(result);
        }

        [HttpGet]
<<<<<<< HEAD
        [Route("datetimeutc")]
=======
        [Route("datetimeUTC7")]
>>>>>>> mehmetasker
        public IActionResult Example7()
        {
            var dateUtc = DateTime.UtcNow;
            var date = DateTime.Now;

            TimeSpan diff = date.Subtract(dateUtc);
<<<<<<< HEAD
            var result = $"Fark: {diff.TotalHours}";

            return Ok(result);
        }

        [HttpGet]
        [Route("datetimeunixepoch")]
        public IActionResult Example8()
        {
            long unixTimeStampInTicks = (DateTime.UtcNow - DateTime.UnixEpoch).Ticks;
            return Ok((double)unixTimeStampInTicks / TimeSpan.TicksPerSecond);
        }

        //public void TryParses()
        //{
        //    //int.TryParse();
        //    //long.TryParse();
        //    //byte.TryParse();
        //    //DateTime.TryParse();
        //}
=======

            return Ok(diff.TotalHours);
        }

        [HttpGet]
        [Route("datetimeunixpoch")] // Linux ile ilgili herhangi bir işlem için Bunu yazyoruz.
        public IActionResult Example8()
        {
            long unixTimeStampInTicks = (DateTime.UtcNow - DateTime.UnixEpoch).Ticks;

            return Ok((double)unixTimeStampInTicks / TimeSpan.TicksPerSecond);
        }
>>>>>>> mehmetasker
    }
}
