using System.Security.Cryptography.X509Certificates;

namespace RobotDreams.API.Model.Genel
{
    public class SwitchCase
    {
        public string Plaka_Kodu { get; set; }
        public string Ekrana_Yaz { get; set; }
        public string Sonuc { get; set; }

        public string SwitchTEst(string a)
        {
            Plaka_Kodu = a;
            switch (a)
            {
                case "37":
                    return Ekrana_Yaz = "37: Kastamonu";
                    break;
                case "34":
                    return Ekrana_Yaz = "34: İstanbul";
                    break;
                case "06":
                    return Ekrana_Yaz = "06: Ankara";
                    break;
                case "31":
                    return Ekrana_Yaz = "31: Hatay";
                    break;
                case "01":
                    return Ekrana_Yaz = "01: Adana";
                    break;
                default:
                    return Ekrana_Yaz = "Girilen Plaka Kodu Geçersizdir.";
                    break;
            }
        }

        
    }
}
