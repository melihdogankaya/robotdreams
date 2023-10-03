namespace RobotDreams.API.Model
{
    public class Customer: Product
    {
        public string Name_Surname { get; set; }
        public double Bonus_Balance { get; set;}

        
        public virtual double AddBonus()
        {
            return Bonus_Balance = Bonus_Balance + (Balance * 0.15);
        }


        public Customer(string adsoyad, double balance)
        {

            Name_Surname = adsoyad;
            Balance = balance;

        }

    }
} 
