namespace RobotDreams.API.Model.Studies
{
    public class Avarage
    {
        public decimal _Avarage { get; set; }
        public List<Student> Students = new();
        public void Add(Student student)
        {
            Students.Add(student);
        }
        public decimal SchoolAvarage()
        {
            decimal _SchoolAvarage = 0;
            foreach (Student student in Students)
            {
                _SchoolAvarage += student.CalculateAverage();
            }
            return _SchoolAvarage /= Students.Count;
        }
    }
}
