namespace RobotDreams.API.Model
{
    public class Textile : Product
    {
        public string FabricType { get; set; }
        public int Size { get; set; }
        public string Manufacturer { get; set; }

        public Textile(string name, double price, string fabricType, int size)
        {
            Name = name;
            Price = price;
            FabricType = fabricType;
            Size = size;
        }
    }
}
