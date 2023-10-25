namespace RobotDreams.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CarAttribute : Attribute
    {
        private string _carName;
        private string _carmodel;

        public string TabloName
        {
            get { return _carName; }
            set { _carName = value; }
        }

        public string CarColor
        {
            get { return _carmodel; }
            set { _carmodel = value; }
        }

        public CarAttribute(string carname, string carmodel)
        {
            _carName = carname;
            _carmodel = carmodel;
        }

        public CarAttribute(string carname) : this(carname, "F50")
        {

        }
    }
}
