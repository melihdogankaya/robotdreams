namespace RobotDreams.API.Model
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual double AddKdv()
        {
            return Price * 1.18;
        }



        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
