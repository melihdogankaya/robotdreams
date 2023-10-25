namespace RobotDreams.API.Model.Odev1.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AracAttribute: System.Attribute
    {
        private string _arabaName;
        private string _semaName;

        public string AracName
        {
            get { return _arabaName; }
            set { _arabaName = value; }
        }

        public string SemaName
        {
            get { return _semaName; }
            set { _semaName = value; }
        }

        public AracAttribute(string aracname, string semaName)
        {
            AracName = aracname;
            SemaName = semaName;
        }

        public AracAttribute(string aracname) : this(aracname, "dbo")
        {

        }
    }
}
