namespace RobotDreams.API.Model
{
    public class Basket : Product
    {
        public List<Product> Products = new();

        public double _TotalPrice { get; set; }

        public double TotalPrice()
        {
            double totalPrice = 0;

            foreach (Product product in Products)
            {
                totalPrice += product.AddKdv();
                Balance = product.Balance - totalPrice;
            }
            
            return totalPrice;
        }

        public void Add(Product product)
        {
            Products.Add(product);
        }
    }
}
