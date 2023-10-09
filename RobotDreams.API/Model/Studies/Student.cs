namespace RobotDreams.API.Model.Studies
{
    public class Student
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int IDNumber { get; set; }


        public int LanguageFirstExam { get; set; }
        public int LanguageLastExam { get; set; }

        public virtual decimal CalculateAverage()
        {
            decimal avarage = (LanguageFirstExam + LanguageLastExam) / 2;
            return avarage;

        }



    }
}
