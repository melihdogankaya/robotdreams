using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using System.IO.Compression;

namespace RobotDreams.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemIo : ControllerBase
    {
        [HttpGet]
        [Route("filepathinfo")]
        public IActionResult Example1()
        {
            var stringList = new List<string>();
            Directory.SetCurrentDirectory(@"C:\");
            string path = Path.GetFullPath(@"D:\Metallica");
            string path2 = Path.GetFullPath(@"D:Metallica");
            stringList.Add(path);
            stringList.Add(path2);
            return Ok(JsonConvert.SerializeObject(stringList));
        }

        [HttpGet]
        [Route("samefiledifferentway")]
        public IActionResult Example2()
        {
            var stringList = new List<string>();
            string[] filenames =
            {
                @"c:\temp\test-file.txt",
                @"\\127.0.0.1\c$\temp\test-file.txt",
                @"\\LOCALHOST\c$\temp\test-file.txt",
                @"\\.\c:\temp\test-file.txt",
                @"\\?\c:\temp\test-file.txt",
                @"\\.\UNC\LOCALHOST\c$\temp\test-file.txt",
            };

            foreach (var filename in filenames)
            {
                FileInfo fi = new(filename);
                stringList.Add($"file {fi.Name}: {fi.Length:N0} bytes");
            }

            return Ok(JsonConvert.SerializeObject(stringList));
        }

        [HttpGet]
        [Route("directorycreateandmoveto")]
        public IActionResult Example3()
        {
            try
            {
                Directory.SetCurrentDirectory(@"D:\");
                Directory.CreateDirectory("TeStDiRecToRY");

                var fi = new FileInfo(@"c:\temp\test-file.txt");
                fi.MoveTo(@"D:\TeStDiRecToRY\test-file2.txt");
                return Ok();
            }
            catch (Exception)
            {
                return Forbid();
            }


        }

        [HttpGet]
        [Route("directorycopy")]
        public IActionResult Example4()
        {
            try
            {
                Directory.SetCurrentDirectory(@"C:\");
                var dir = new DirectoryInfo(@"C:\temp");
                if (!dir.Exists)
                    return BadRequest("Böyle bir dizin yok.");

                DirectoryInfo[] dirs = dir.GetDirectories();
                Directory.CreateDirectory("directoryCopy");

                foreach (var d in dir.GetFiles())
                {
                    string targetFilePath = Path.Combine("directoryCopy", d.Name);
                    d.CopyTo(targetFilePath);
                }

                return Ok();
            }
            catch (Exception)
            {
                return Forbid();
            }
        }

        [HttpGet]
        [Route("writetexttofile")]
        public IActionResult Example5()
        {
            try
            {
                Directory.SetCurrentDirectory(@"C:\");

                string text = $"First Line: {Guid.NewGuid()}";
                var dir = new DirectoryInfo(@"C:\temp");

                System.IO.File.WriteAllText(Path.Combine(dir.Name, "WriteFile.txt"), text);
                string[] lines = { "New Line 1", "New Line 2" };

                System.IO.File.AppendAllLines(Path.Combine(dir.Name, "WriteFile.txt"), lines);

                return Ok();
            }
            catch (Exception)
            {
                return Forbid();
            }
        }

        [HttpGet]
        [Route("readtextfile")]
        public IActionResult Example6()
        {
            try
            {
                Directory.SetCurrentDirectory(@"C:\temp");

                using var sr = new StreamReader("WriteFile.txt");
                var result = sr.ReadToEnd();

                return Ok(result);
            }
            catch (Exception)
            {
                return Forbid();
            }
        }

        [HttpGet]
        [Route("compressdirectory")]
        public IActionResult Example7()
        {
            try
            {
                Directory.SetCurrentDirectory(@"C:\");
                string startPath = @".\temp";
                string zipPath = @".\temp.zip";

                ZipFile.CreateFromDirectory(startPath, zipPath);

                return Ok();
            }
            catch (Exception)
            {
                return Forbid();
            }
        }

        [HttpGet]
        [Route("decompressdirectory")]
        public IActionResult Example8()
        {
            try
            {
                Directory.SetCurrentDirectory(@"C:\");
                string zipPath = @".\temp.zip";
                string extractPath = @".\extract";

                ZipFile.ExtractToDirectory(zipPath, extractPath);

                return Ok();
            }
            catch (Exception)
            {
                return Forbid();
            }
        }

        [HttpPost]
        [Route("uploadfile")]
        public IActionResult Example9(IFormFile file)
        {
            if(file.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using var stream = System.IO.File.Create(filePath);

                file.CopyTo(stream);
            }

            return Ok();
        }
    }
}
