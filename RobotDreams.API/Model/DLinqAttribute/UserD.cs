using System.ComponentModel.DataAnnotations.Schema;

namespace RobotDreams.API.Model.DLinqAttribute
{
    [Table("User", Schema ="dbo")]
    public class UserD
    {
        public Guid Id { get; set; }
    }
}
