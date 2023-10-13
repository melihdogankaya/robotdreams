namespace RobotDreams.API.Model.Genel
{
    public class Ortalama
    {
        public double Final { get; set; }
        public double Vize { get; set; }
        public double OrtaHesapla { get; set; }

        public double OrtalamaBul(double f, double v)
        {
            OrtaHesapla = f * 0.4 + v * 0.6;

            return OrtaHesapla;
        }


    }
}
