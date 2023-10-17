namespace RobotDreams.API.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassAttribute : Attribute
    {
        private string _tableName;
        private string _schemaName;

        public string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }
        public string SchemaName
        {
            get { return _schemaName; }
            set { _schemaName = value; }
        }

        public ClassAttribute(string tableName, string schemaName)
        {
            TableName = tableName;
            SchemaName = schemaName;
        }

        public ClassAttribute(string tableName) : this(tableName, "dbo")
        {

        }

        //public Table2Attribute()
        //{

        //}
    }
}
