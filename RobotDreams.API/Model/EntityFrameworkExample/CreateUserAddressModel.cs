namespace RobotDreams.API.Model.EntityFrameworkExample
{
    public class CreateUserAddressModel
    {
        public string AddressName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? PostCode { get; set; }
        public string Creator { get; set; }
    }
}
