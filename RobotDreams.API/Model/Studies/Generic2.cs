namespace RobotDreams.API.Model.Studies
{
    public class Generic2<T1, T2, T3> where T1 :struct where T2 : IEquatable<T1> where T3 : struct
    {
        public T1 Name;
        public T2 MyProperty { get; set; }
        public T3 Method(T3 param) 
        {

            return new T3();
        }
    }

}
