using Microsoft.AspNetCore.Mvc;
using RobotDreams.API.Model.Genel;
using Newtonsoft.Json;

namespace RobotDreams.API.Controllers.NewFolder
{
    public class AgainController : Controller
    {
        [HttpGet]
        [Route("Geneltekrar")]
        public IActionResult geneltekrar(string a, string b)
        {
            GenelTekrar _bilgileriAl = new();
            Kup _hacimhesap = new();
            SilindirinHacmi _silindirinHacmi = new();
            Ortalama _OrtalamaBul = new();
            Ifelse _ucgen = new();
            TekmiCiftmi _sayiGir = new();
            Basvuru _talep = new();
            ParolaSorgu _parolaSorgu = new();
            SwitchCase _testCase = new();

            //_bilgileriAl.Alan_Hesapla(yuk, tab);
            // _hacimhesap.HacimHesapla(tab);
            // _silindirinHacmi.YaricapHesapla(tab, yuk);
            //_OrtalamaBul.OrtalamaBul(tab, yuk);
            //_ucgen.Kenar4(tab, yuk, ab);
            //_sayiGir.CiftSayibul(tab);
            //_talep.BasvuruYap(a, b);
            //_parolaSorgu.Girisyap(a, b);
            _testCase.SwitchTEst(a);


            //string result = JsonConvert.SerializeObject(_bilgileriAl);
            //string result = JsonConvert.SerializeObject(_hacimhesap);
            //string result = JsonConvert.SerializeObject(_silindirinHacmi);
            string result = JsonConvert.SerializeObject(_testCase);


            return Ok(result);
        }
    }
}
