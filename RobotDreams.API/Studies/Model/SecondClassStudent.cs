namespace RobotDreams.API.Model2.Model
{
    public class SecondClassStudent : Student
    {
        public SecondClassStudent(string firstName, string lastName, int id, int _LanguageFirstExam, int _LanguageLastExam, int _MathFirstExam, int _MathLastExam)
        {
            FirstName = firstName;
            LastName = lastName;
            IDNumber = id;
            LanguageFirstExam = _LanguageFirstExam;
            LanguageLastExam = _LanguageLastExam;
            MathFirstExam = _MathFirstExam;
            MathLastExam = _MathLastExam;
        }
        public int MathFirstExam { get; set; }
        public int MathLastExam { get; set; }

        public override decimal CalculateAverage()
        {
            decimal avarage = (LanguageFirstExam + LanguageLastExam + MathFirstExam + MathLastExam) / 4;
            return avarage;
        }

    }
}
