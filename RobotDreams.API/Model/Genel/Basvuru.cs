namespace RobotDreams.API.Model.Genel
{
    public class Basvuru
    {
        public double Boy { get; set; }
        public double Kilo { get; set; }
        public string Sonuc { get; set; }

        public string BasvuruYap(double boy, double kilo)
        {
            if (boy >= 165 && kilo > 60 && kilo < 80)
            {
                Boy = boy;
                Kilo = kilo;
                Sonuc = "İş başvurunuz Onaylanmıştır";
                return Sonuc;
            }
            else
            {
                Boy = boy;
                Kilo = kilo;
                Sonuc = "İş başvurunuz Kriterlere uymamaktadır.";
                return Sonuc;
            }
        }
    }
}
