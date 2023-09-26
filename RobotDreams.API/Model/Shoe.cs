namespace RobotDreams.API.Model
{
    public class Shoe
    {
        public string Material;
        public byte Number;
        public string Color;
        public bool IsLace;

        private string Brand;
        //"Brand" özelliğinin değerini yalnızca okumak için kullanılacak bir metod:
        public string ReadBrand()
        {
            return Brand;
        }

        //"Brand" özelliğine yalnızca değer atamak için kullanılacak bir metod:
        public void WriteBrand(string brand)
        {
            Brand = brand;
        }

        private string type;
        //"Tipi" özelliğini encapsulate edilmes.
        public string Type
        {
            get { return type; }
            set { type = "Sport"; }
        }
    }
}
