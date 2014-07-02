using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Student
    {
        //Defining properties for our student object
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int StudentID { get; set; }
        public List<Course> Courses { get; set; }
        
        //Declare a Constructor, this initializes our
        //   object
        public Student(string firstName, string lastName, int studentID)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.StudentID = studentID;
            this.Courses = new List<Course>();
        }
    }
}
