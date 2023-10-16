using RobotDreams.API.Model.Studies.Poly;

namespace RobotDreams.API.Model.Studies.Homeworks
{
    public class Student 
    {

        public Student(string nameSurname, int iD, int examResult1, int examResult2)
        {
            NameSurname = nameSurname;
            ID = iD;
            ExamResult1 = examResult1;
            ExamResult2 = examResult2;
        }
        public string NameSurname { get; set; }
        public int ID {  get; set; }
        public decimal ExamResult1 { get; set; }
        public decimal ExamResult2 { get; set; }
        public decimal Avarage(int examResult1, int examResult2)  
        {            
            return (examResult1 + examResult2) / 2;          
        }

    }
}
