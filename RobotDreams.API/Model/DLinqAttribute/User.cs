using RobotDreams.API.Attributes;

namespace RobotDreams.API.Model.DLinqAttribute
{
    [Class("User", "Base")]
    public class User
    {
        [Property(nameof(Id), true)]
        public Guid Id { get; set; }
    }
}
