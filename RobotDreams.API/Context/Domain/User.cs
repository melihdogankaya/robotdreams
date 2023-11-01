namespace RobotDreams.API.Context.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string surname { get; set; }

        public string Email { get; set; }   
        public string Password { get; set; }
    }
}
