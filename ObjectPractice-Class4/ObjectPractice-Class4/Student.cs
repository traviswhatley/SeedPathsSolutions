using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice_Class4
{
    class Student
    {
        //STEP 1: Declare Properties
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; }

        //STEP 2: Constructor
        public Student(int studentID, string firstName, string lastName)
        {
            this.StudentID = studentID;
            this.FirstName = firstName;
            this.LastName = lastName;
            //make sure to initialize the Course List
            this.Courses = new List<Course>();
        }

        //STEP 3: Methods and Functions
        public void PrintInfo()
        {
            Console.WriteLine("{0} {1}", this.FirstName, this.LastName);
            Console.WriteLine("Student ID: " + this.StudentID);
            //write out each course and grade
            Console.WriteLine(string.Join("\n", this.Courses.Select(x => x.GetCourseInfo())));

            //foreach loop that does the same thing as the line above
            //foreach (var item in this.Courses)
            //{
            //    Console.WriteLine(item.GetCourseInfo());
            //}

            //write out total GPA
            Console.WriteLine("GPA: {0}", this.Courses.Average(x => x.GradePoints));
        }
        
    }
}
