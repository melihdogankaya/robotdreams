namespace RobotDreams.API.Model.Odev1
{
    public class GenericEx<T> 
    {
        public T Typeslar {  get; set; }
        
        public string CarBrand { get; set; }

        public string OtoMarkalari(string name)
        {
            switch (name.ToUpper())//GElen veriyi Buyuk karakter yap
            {
                case "OPEL":
                    List<string> list = new();
                    list.Add("Corsa");
                    list.Add("Astra");
                    list.Add("Vectra");
                    list.Add("Mokka");
                    CarBrand = string.Join(",", list);// Virgül ile ayır CARBRAND içine ekle
                    return CarBrand;
                    

                case "RENAULT": 
                    List<string> list1 = new();
                    list1.Add("Megane");
                    list1.Add("Clio");
                    list1.Add("Captur");
                    list1.Add("Austral");
                    list1.Add("ZOE");
                    CarBrand = string.Join(",", list1);
                    return CarBrand;

                case "FERRARİ":
                    List<string> list2 = new();
                    list2.Add("California 30");
                    list2.Add("F 430 Scuderia");
                    list2.Add("F 430 F1");
                    list2.Add("LaFerrari");
                    CarBrand = string.Join(", ", list2);
                    return CarBrand;

                default:
                    throw new Exception("Otomobil Markası kayıtlı degil. Mesajını Admine ilet ve Yeni marka Ekle.");
                    


            }
        }   
    }
}
