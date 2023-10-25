namespace RobotDreams.API.Model.Odev1.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class DealerAttribute : System.Attribute 
    {
        private string dealer;
        private string sales;
        private bool inspect;

        public DealerAttribute(string dealer, string sales, bool inspect)
        {
            this.dealer = dealer;
            this.sales = sales;
            this.inspect = inspect;
        }

        public virtual string Name
        {
            get { return dealer; }
        }

        public virtual string Sales
        {
            get { return sales; }
        }

        public virtual bool Inspect
        {
            get { return inspect; }
            set { inspect = value; }
        }
    }
}
