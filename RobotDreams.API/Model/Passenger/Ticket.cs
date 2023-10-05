namespace RobotDreams.API.Model.Passenger
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public double Price { get; set; }

        public virtual double TicketPrice()
        {
            return Price;
        }

        public Ticket()
        {

        }

        public Ticket(int id, string name, string surname, double price)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Price = price;
        }


    }
}
