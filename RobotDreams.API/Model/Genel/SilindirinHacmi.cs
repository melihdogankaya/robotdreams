namespace RobotDreams.API.Model.Genel
{
    public class SilindirinHacmi : GenelTekrar
    {
        public double Yaricap { get; set; }

        public double YaricapHesapla(double yaricap, double yuksek )
        {
            double pi = Math.PI;
            Sonuc = pi * Math.Pow(yaricap,2) * yuksek;
            return Sonuc;
        }
    }
}
