namespace RobotDreams.API.Model
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double VatRate {  get; set; }
        public virtual double AddKdv()
        {
            return Price * (1+100/ VatRate);
        }


        public Product(string name, double price, double vatrate)
        {
            Name = name;
            Price = price;
            VatRate = vatrate;
        }
    }
}
