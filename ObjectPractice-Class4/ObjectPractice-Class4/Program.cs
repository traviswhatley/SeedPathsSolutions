using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice_Class4
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Honda", "Civic");
            Car car2 = new Car();

            //write the info for both cars to the console
            Console.WriteLine(myCar.GetInfo());
            Console.WriteLine(car2.GetInfo());

            myCar.Honk();

            //create a student
            Student Pat = new Student(10001, "Pat", "McClary");
            //add a course
            Pat.Courses.Add(new Course("Professional Development", "B"));
            Pat.Courses.Add(new Course("Hockey 101", "A"));
            Pat.Courses.Add(new Course("Intro to Programming", "D"));
            Pat.Courses.Add(new Course("Being Rad", "A"));
            Pat.Courses.Add(new Course("English 102", "A"));
            
            //Print out all the info about Pat
            Pat.PrintInfo();

            Student Logan = new Student(10002, "Logan", "Whatever your last name is");
            Logan.Courses.Add(new Course("Professional Development", "C"));
            Logan.Courses.Add(new Course("Programming", "B"));

            Logan.PrintInfo();

            //keep the console open
            Console.ReadKey();
        }
    }

   
}
