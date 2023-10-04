namespace RobotDreams.API.Model
{
    public class MobilePhone : Product
    {
        public string Specifications { get; set; }
        public string Brand { get; set; }
       // public double VatRate {  get; set; }
        public MobilePhone(string name, double price,double vatrate, string brand) 
        { 
            Name = name;
            Price = price;
            VatRate = vatrate;
            Brand = brand;
           
        }
    }
}
