namespace RobotDreams.API.Model.Genel
{
    public class ParolaSorgu
    {   
        public string Username {  get; set; }
        public string Password { get; set; }
        public string Sonuc {  get; set; }


        public string Girisyap(string username, string password)
        {
            Username = "Asker";
            Password = "15645";

            if (username == "Asker" && password == "15645")
            {
                Sonuc = "Kullanıcı Girişi Başarılı";
                return Sonuc;
            }
            else
            {
                if (username == "Asker" && password != "15645")
                {
                    Sonuc = "Parola Hatalı";
                    return Sonuc;
                }
                else if(username !="Asker" &&  password == "15645")
                {
                    Sonuc = "Username Hatalı";
                    return Sonuc;
                }
                else
                {
                    Sonuc = "Parola ve Username Hatalı";
                    return Sonuc;
                }


                
            }


           
        }
    }
}
