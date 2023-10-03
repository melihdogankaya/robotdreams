﻿using RobotDreams.API.Model;

namespace RobotDreams.API.Model2.Model
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
            _SchoolAvarage /= Students.Count;

            return _SchoolAvarage;
        }


   


    }
}
