namespace RobotDreams.API.Model
{
    public class Staff
    {
        protected double CalculateSalary(int workingHours, double pricePerHour)
        {
            return workingHours * pricePerHour;
        }
    }
}
