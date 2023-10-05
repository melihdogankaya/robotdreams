namespace RobotDreams.API.Model.Passenger
{
    public class Plane : Ticket
    {
        public byte KoltukNo { get; set; }
        public byte KabinNo { get; set; }

        public override double TicketPrice()
        {
            return Price;
        }

        public Plane(int id, string name, string surname, double prize, byte koltukNo, byte kabinNo )
        {
            Id = id;
            Name = name;
            Surname = surname;
            Price = prize;
            KoltukNo = koltukNo;
            KabinNo = kabinNo;
        }



    }
}
