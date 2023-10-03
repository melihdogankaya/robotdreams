﻿namespace RobotDreams.API.Model2
{
    public class Student
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int IDNumber { get; set; }
        public string Gender { get; set; }

        public int LanguageFirstExam { get; set; }
        public int LanguageLastExam { get; set; }

        public virtual decimal CalculateAverage()
        {
            decimal avarage = (LanguageFirstExam + LanguageLastExam) / 2;
            return avarage;

        }



    }
}