namespace RobotDreams.API.Model.Passenger
{
    public class Payment : Ticket
    {
        public List<Ticket> Ticket = new();

        public double _ToplamPayment {  get; set; }

        public double ToplamOdeme()
        {
            double Toplamodeme = 0;

            foreach(Ticket siradan_degisken_Adi in Ticket)
            {
                Toplamodeme += siradan_degisken_Adi.TicketPrice();
            }

            return Toplamodeme;
        }

        public void Ekle(Ticket siradan_degisken_Adi)
        {
            Ticket.Add(siradan_degisken_Adi);
        }

    }
}
