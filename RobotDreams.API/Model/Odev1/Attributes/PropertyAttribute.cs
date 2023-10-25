using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RobotDreams.API.Model.Odev1.Attributes
{
    [AttributeUsage(AttributeTargets.Property)] //Bu sadece Class içeisinde kullanılan bir özelliktir. 
    public class PropertyAttribute : System.Attribute
    {
        private string _propertyName;
        private bool _nullable;
        private bool _identity;

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

        public PropertyAttribute(string ozellikAdi, bool isNullable, bool isIdentity)
        {
            PropertyName = ozellikAdi;
            Nullable = isNullable;
            Identity = isIdentity;
        }

        public PropertyAttribute(string propertyName, bool isNullable) : this(propertyName, isNullable, true) { }

        public PropertyAttribute(string propertyName) : this(propertyName, false) { }

    }
}
