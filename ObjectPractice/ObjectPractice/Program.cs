using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Car Car1 = new Car("Honda", "Civic", 1998);
            //Car Car2 = new Car();

            //Console.WriteLine(Car1.GetInfo());
            //Console.WriteLine(Car2.GetInfo());

            //Car2.Make = "Ford";
            //Car2.Model = "Taurus";

            //Car1.Honk();

            //Console.WriteLine(Car2.GetInfo());

            Student Pat = new Student("Pat", "McClary", 1337);
            Pat.Courses.Add(new Course("Professional Development", "A"));
            Pat.Courses.Add(new Course("Intro to Business", "C"));
            Pat.Courses.Add(new Course("Being Rad", "B"));
            Pat.Courses.Add(new Course("Intro to Programming", "D"));
            Pat.Courses.Add(new Course("Hockey 101", "A"));
            Pat.PrintInfo();

            Console.ReadKey(); //Keep the console open
        }
    }
}
