namespace RobotDreams.API.Model.Studies.Poly
{
    public class FirstClassStudent : Student
    {

        public FirstClassStudent(string firstName, string lastName, int iD, int languageFirstExam, int languageSecondExam)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = iD;
            LanguageFirstExam = languageFirstExam;
            LanguageLastExam = languageSecondExam;

        }
    }

}
