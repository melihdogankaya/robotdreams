namespace RobotDreams.API.Model.Genel
{
    public class TekmiCiftmi : Ifelse
    {
       public string CiftSayibul(int a) 
        {
            if (a %2 == 0)
            {
                S1 = a;
                Sonuc = "Bu sayi Çifttir.";
                return Sonuc;
            }
            else
            {
                S1 = a;
                Sonuc = "Bu sayi Tektir.";
                return Sonuc;
            }
        }
    }
}
