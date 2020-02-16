using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double GPA { get; set; }

        public Student(int id, string firstName, string lastName, double GPA)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GPA = GPA;
        }
    }
}
