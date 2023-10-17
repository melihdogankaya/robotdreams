namespace RobotDreams.API.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyAttribute : Attribute
    {
        private string _propertyName;
        private bool _identity;
        private bool _nullable;

        public bool Nullable
        {
            get { return _nullable; }
            set { _nullable = value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        public bool Identity
        {
            get { return _identity; }
            set { _identity = value; }
        }

        public PropertyAttribute(string propertyName, bool isIdentity, bool isNullable)
        {
            PropertyName = propertyName;
            Identity = isIdentity;
            Nullable = isNullable;
        }

        public PropertyAttribute(string propertyName, bool isIdentity) : this(propertyName, isIdentity, true) { }

        public PropertyAttribute(string propertyName) : this(propertyName, false) { }

    }
}
