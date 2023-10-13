using RobotDreams.API.Model;

namespace RobotDreams.API.Model
{
    public class Delicatessen: Product 
    {
        public string Type { get; set; }
        public int HacimMl { get; set; }
        public string Brand { get; set; }

        public override double AddKdv()
        {
            return Price * 1.25;
        }

        public Delicatessen(string name,string type, int hacimML, string brand, double price, double balance)
        {
            Name = name;
            Price = price;
            Balance = balance;
            Type = type;
            HacimMl = hacimML;
            Brand = brand;
        }
    }
}
