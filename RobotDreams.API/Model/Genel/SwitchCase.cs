using System.Security.Cryptography.X509Certificates;

namespace RobotDreams.API.Model.Genel
{
    public class SwitchCase
    {
        public string EkranaYaz { get; set; }

        public string SwitchTEst(string a)
        {
            switch (a)
            {
                case "37":
                    return EkranaYaz = "37: Kastamonu";
                    break;

                case "34":
                    return EkranaYaz = "34: İstanbul";
                    break;

                case "06":
                    return EkranaYaz = "06: Ankara";
                    break;

                case "31":
                    return EkranaYaz = "31: Hatay";
                    break;
                case "01":
                    return EkranaYaz = "01: Adana";
                    break;
                default:
                    throw new Exception("Girilen Plaka Kodu Geçersizdir.");
                    break;
            }
        }

        
    }
}
