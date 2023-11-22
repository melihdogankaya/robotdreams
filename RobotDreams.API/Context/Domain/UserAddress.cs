using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotDreams.API.Context.Domain
{
    public class UserAddress
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public string AddressName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? PostCode { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Creator { get; set; }
        public DateTime? Modified { get; set; }
        public string? Modifier { get; set; }
    }
}
