namespace RobotDreams.API.Model2.Model
{
    public class FirstClassStudent : Student
    {

        public FirstClassStudent(string firstName, string lastName, int id, int languageFirstExam, int languageSecondExam)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = id;
            LanguageFirstExam = languageFirstExam;
            LanguageLastExam = languageSecondExam;

        }
    }

}
