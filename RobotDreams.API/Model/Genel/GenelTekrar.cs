namespace RobotDreams.API.Model.Genel
{
    public class GenelTekrar
    {
        public int OgrenciNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public double Taban_Uzunluk {  get; set; }
        public double Yukseklik {  get; set; }
        public double Sonuc {  get; set; }

        public double Alan_Hesapla(double taban,double yukseklik) 
        {
            
            Taban_Uzunluk = taban;
            Yukseklik = yukseklik;
            Sonuc = Taban_Uzunluk * Yukseklik / 2; ;

            return Sonuc;
        }
    }
}
