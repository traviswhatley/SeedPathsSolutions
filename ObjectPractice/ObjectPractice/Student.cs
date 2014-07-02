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

        //Functions for our class come next
        public void PrintInfo()
        {
            Console.WriteLine(this.FirstName + " " + this.LastName);
            Console.WriteLine("Student ID: " + this.StudentID);
            //foreach (var course in this.Courses)
            //{
            //    Console.WriteLine(course.CourseName + " " + course.LetterGrade + " " + course.GradePoints);
            //}
            //Single line solution to replace the foreach loop using
            // the .Select lambda extension
            Console.WriteLine(string.Join("\n", this.Courses.Select(x => x.CourseName + " " + x.LetterGrade + " " + x.GradePoints)));
            //using the .Average lamdba extension
            Console.WriteLine("GPA: " + this.Courses.Average(x => x.GradePoints));
        }
    }
}
