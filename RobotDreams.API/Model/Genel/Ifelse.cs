namespace RobotDreams.API.Model.Genel
{
    public class Ifelse
    {
        public int S1 { get; set; }
        public int S2 { get; set; }
        public int S3 { get; set; }
        public string Sonuc {  get; set; }

        public string Kenar4(int a,int b,int c)
        {
            S1 = a;
            S2 = b;
            S3 = c;

            if(S1 == S2 && S1 == S3 && S2 == S3)
            {
                Sonuc = "Üçgen İkizkenardır";
                return Sonuc;
            }
            else
            {
                Sonuc = "Üçken İkizkenar değildir.";
                return Sonuc;
            }                        
        }




    }
}
