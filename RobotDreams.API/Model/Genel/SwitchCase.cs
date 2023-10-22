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
            return a switch
            {
                "37" => Ekrana_Yaz = "37: Kastamonu",
                "34" => Ekrana_Yaz = "34: İstanbul",
                "06" => Ekrana_Yaz = "06: Ankara",
                "31" => Ekrana_Yaz = "31: Hatay",
                "01" => Ekrana_Yaz = "01: Adana",
                _ => Ekrana_Yaz = "Girilen Plaka Kodu Geçersizdir.",
            };
        }

        
    }
}
