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
            //Car myCar = new Car("Honda", "Civic");
            //Car car2 = new Car();

            ////write the info for both cars to the console
            //Console.WriteLine(myCar.GetInfo());
            //Console.WriteLine(car2.GetInfo());

            //myCar.Honk();

            ////create a student
            //Student Pat = new Student(10001, "Pat", "McClary");
            ////add a course
            //Pat.Courses.Add(new Course("Professional Development", "B"));
            //Pat.Courses.Add(new Course("Hockey 101", "A"));
            //Pat.Courses.Add(new Course("Intro to Programming", "D"));
            //Pat.Courses.Add(new Course("Being Rad", "A"));
            //Pat.Courses.Add(new Course("English 102", "A"));
            
            ////Print out all the info about Pat
            //Pat.PrintInfo();

            //Student Logan = new Student(10002, "Logan", "Whatever your last name is");
            //Logan.Courses.Add(new Course("Professional Development", "C"));
            //Logan.Courses.Add(new Course("Programming", "B"));

            //Logan.PrintInfo();

            TicketExample();

            //keep the console open
            Console.ReadKey();
        }

        static void TicketExample()
        {
            //create a new list to hold our tickets
            List<Ticket> ticketList = new List<Ticket>();
            //create a new ticket
            Ticket ticket1 = new Ticket("Nicole", "RSVP Form is broken", Priority.Critical);
            //let some time pass, (1 second)
            System.Threading.Thread.Sleep(1000);
            //resolve ticket 1
            ticket1.ResolveTicket();
            //add it to the list
            ticketList.Add(ticket1);

            //add two more tickets to list
            // using the highimportance and 
            // non critcal priorities
            ticketList.Add(new Ticket("Pat", "Hockey stick is broke", Priority.NonCritical));
            ticketList.Add(new Ticket("Logan", "he's sick today", Priority.HighImportance));

            //print them out to the console, ordered by priority
            Console.WriteLine(string.Join("\n", ticketList.OrderBy(x => x.Priority).Select(x => x.GetTicketInfo())));

            //print out only the unresolved tickets
            Console.WriteLine(string.Join("\n", ticketList.Where(x=> x.Resolved == false).OrderBy(x => x.Priority).Select(x => x.GetTicketInfo())));


        }
    }

   
}
