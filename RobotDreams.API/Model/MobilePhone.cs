namespace RobotDreams.API.Model
{
    public class MobilePhone : Product
    {
        public string Specifications { get; set; }
        public string Brand { get; set; }

        public MobilePhone(string name, double price, string brand) 
        { 
            Name = name;
            Price = price;
            Brand = brand;
        }
    }
}
