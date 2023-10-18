namespace RobotDreams.API.Model.Studies.Homeworks
{
    public class Student 
    {

        public string NameSurname { get; set; }
        public int ID {  get; set; }
        public decimal ExamResult1;
        public decimal ExamResult2;      
        public decimal AvarageCalculation()
        {
            return (ExamResult1 + ExamResult2) / 2;
        }

    }
}
