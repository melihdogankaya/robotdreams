namespace RobotDreams.API.Model
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double Balance { get; set; }


        public virtual double AddKdv()
        {
            
            return Price * 1.18;
        }


        public Product()
        {

        }

        public Product(string name, double price, double balance)
        {
            Name = name;
            Price = price;
            Balance = balance;
        }
    }
}
