namespace RobotDreams.API.Model.Studies
{
    public class SecondClassStudent : Student
    {
        public SecondClassStudent(string firstName, string lastName, int iD, int languageFirstExam, int languageLastExam, int mathFirstExam, int mathLastExam)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = iD;
            LanguageFirstExam = languageFirstExam;
            LanguageLastExam = languageLastExam;
            MathFirstExam = mathFirstExam;
            MathLastExam = mathLastExam;
        }
        public int MathFirstExam { get; set; }
        public int MathLastExam { get; set; }

        public override decimal CalculateAverage()
        {            
            return (LanguageFirstExam + LanguageLastExam + MathFirstExam + MathLastExam) / 4;
        }

    }
}
