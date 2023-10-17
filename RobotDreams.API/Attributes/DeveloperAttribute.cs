namespace RobotDreams.API.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DeveloperAttribute : Attribute
    {
        private string name;
        private string level;
        private bool reviewed;

        public DeveloperAttribute(string name, string level, bool reviewed)
        {
            this.name = name;
            this.level = level;
            this.reviewed = reviewed;
        }

        public virtual string Name
        {
            get { return name; }
        }

        public virtual string Level
        {
            get { return level; }
        }

        public virtual bool Reviwed
        {
            get { return reviewed; }
            set { reviewed = value; }
        }
    }
}
