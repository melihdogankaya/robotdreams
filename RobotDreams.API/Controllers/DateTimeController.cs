using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using System;

using System.Globalization;

namespace RobotDreams.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeController : ControllerBase
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
            [Route("datetostring2")]
            public IActionResult Example2()
            {
                List<string> result = new();

                var date = DateTime.Now; //new DateTime(2008, 6, 15, 19, 18, 05);
                string[] standardFmts = { "d", "D", "f", "F", "g", "G", "m", "o", "R", "s", "t", "T", "u", "U", "y" };

                foreach (var item in standardFmts)
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
            public IActionResult Example4()
            {
                var date = DateTime.Now; //new DateTime(2008, 6, 15, 19, 18, 05);
                return Ok(date.ToString("D"));
            }


            public IActionResult FormatlamaExample4()
            {
                var date = DateTime.Now; //new DateTime(1988, 6, 15, 18, 35, 56);

                return Ok(date.ToString("G"));
            }

            [HttpGet]
            [Route("datetimeexample1")]
            public IActionResult Example5()
            {
                var a = string.Empty;
                //DateTime.Parse(stringDate);
                var stringDate = "15/10/23 19:27";
                var isDatetimeCorrect = DateTime.TryParse(stringDate, out DateTime result);

                if (isDatetimeCorrect)
                {
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


                return Ok(result.ToString());

            }






            [HttpGet]
            [Route("datetimeUTC7")]
            public IActionResult Example7()
            {
                var dateUtc = DateTime.UtcNow;
                var date = DateTime.Now;

                TimeSpan diff = date.Subtract(dateUtc);
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





            [HttpGet]
            [Route("datetimeunixpoch")] // Linux ile ilgili herhangi bir işlem için Bunu yazyoruz.
            public IActionResult Example88()
            {
                long unixTimeStampInTicks = (DateTime.UtcNow - DateTime.UnixEpoch).Ticks;

                return Ok((double)unixTimeStampInTicks / TimeSpan.TicksPerSecond);
            }

        
    }
}
