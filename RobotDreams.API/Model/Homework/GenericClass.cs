using Microsoft.AspNetCore.Http.HttpResults;
using RobotDreams.API.Controllers.Homework;

namespace RobotDreams.API.Model.Homework
{
    public class GenericClass
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        public double Divide()
        {
            return Number1 / Number2;
        }
    }
}
