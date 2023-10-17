using RobotDreams.API.Attributes;

namespace RobotDreams.API.Model.DLinqAttribute
{
    [Class("User", "Base")]
    public class User
    {
        [Property("Id", true)]
        public Guid Id { get; set; }
    }
}
