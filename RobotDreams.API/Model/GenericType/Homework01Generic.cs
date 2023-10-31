using System.Diagnostics.CodeAnalysis;

namespace RobotDreams.API.Model.GenericType
{
    public class Homework01Generic<T>
    {
        public T Result { get; set; }
        public string Message {get; set;}
    }
}
