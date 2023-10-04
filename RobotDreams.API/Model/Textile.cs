namespace RobotDreams.API.Model
{
    public class Textile : Product
    {
        public string FabricType { get; set; }
        public int Size { get; set; }
        public string Manufacturer { get; set; }
       // public double VatRate {  get; set; }

        public Textile(string name, double price,double vatrate, string fabricType, int size)
        {
            Name = name;
            Price = price;
            VatRate = vatrate;
            FabricType = fabricType;
            Size = size;
            

        }
    }
}
