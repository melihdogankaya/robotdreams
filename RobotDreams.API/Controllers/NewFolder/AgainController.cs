using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.Genel;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers.NewFolder
{
    public class AgainController : Controller
    {
        [HttpGet]
        [Route("Geneltekrar")]
        public IActionResult geneltekrar(int tab, int yuk, int ab)
        {
            GenelTekrar _bilgileriAl = new();
            Kup _hacimhesap = new();
            SilindirinHacmi _silindirinHacmi = new();
            Ortalama _OrtalamaBul = new();
            Ifelse _ucgen = new();

            //_bilgileriAl.Alan_Hesapla(yuk, tab);
            // _hacimhesap.HacimHesapla(tab);
            // _silindirinHacmi.YaricapHesapla(tab, yuk);
            //_OrtalamaBul.OrtalamaBul(tab, yuk);
            _ucgen.Kenar4(tab, yuk, ab);

            //string result = JsonConvert.SerializeObject(_bilgileriAl);
            //string result = JsonConvert.SerializeObject(_hacimhesap);
            //string result = JsonConvert.SerializeObject(_silindirinHacmi);
            string result = JsonConvert.SerializeObject(_ucgen);


            return Ok(result);
        }
    }
}
