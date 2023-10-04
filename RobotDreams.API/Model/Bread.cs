namespace RobotDreams.API.Model
{
    public class Bread : Product
    {
        public string Type { get; set; }
        public int BasisWeight { get; set; }
      //  public double VatRate {  get; set; }

        public Bread(string name, double price,double vatrate, string type, int basisWeight) 
        { 
            Name = name;
            Price = price;
            VatRate = vatrate;
            Type = type;
            BasisWeight = basisWeight;
          
        }
    }
}
