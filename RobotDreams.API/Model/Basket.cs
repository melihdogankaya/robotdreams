namespace RobotDreams.API.Model
{
    public class Basket
    {
        private List<Product> products = new();

        public double TotalPrice()
        {
            double totalPrice = 0;

            foreach (Product product in products)
            {
                totalPrice += product.AddKdv();
            }
            
            return totalPrice;
        }

        public void Add(Product product)
        {
            products.Add(product);
        }
    }
}
