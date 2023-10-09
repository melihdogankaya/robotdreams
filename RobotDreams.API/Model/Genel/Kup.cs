namespace RobotDreams.API.Model.Genel
{
    public class Kup : GenelTekrar
    {
        public double Kenar_Uzunlugu { get; set; }
        public double Hacim { get; set; }

        public double HacimHesapla(double kenar)
        {
            Kenar_Uzunlugu = kenar;
            Hacim = Math.Pow(Kenar_Uzunlugu, 3);
            return Hacim;
        }
    }
}
