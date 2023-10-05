namespace RobotDreams.API.Model.Passenger
{
    public class Bus : Ticket
    {
        public byte KoltukNo { get; set; }
        public byte BagajNo { get; set;}

        public override double TicketPrice()
        {
            return Price;
        }

        public Bus(int id, string name, string surname, double price, byte koltuk, byte bagaj) 
        {
            Id = id;
            Name = name;
            Surname = surname;
            Price = price;
            KoltukNo = koltuk; 
            BagajNo = bagaj;
        }
    }
}
