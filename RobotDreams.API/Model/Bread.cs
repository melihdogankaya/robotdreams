namespace RobotDreams.API.Model
{
    public class Bread : Product
    {
        public string Type { get; set; }
        public int BasisWeight { get; set; }

        public Bread(string name, double price, string type, int basisWeight) 
        { 
            Name = name;
            Price = price;
            Type = type;
            BasisWeight = basisWeight;
        }
    }
}
