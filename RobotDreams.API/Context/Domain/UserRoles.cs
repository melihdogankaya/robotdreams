using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RobotDreams.API.Context.Domain
{
    public class UserRoles
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }
        public string? Role { get; set; }
    }
}
