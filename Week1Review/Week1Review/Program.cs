using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Review
{
    class Program
    {
        //Global Variables
        //must be declared static <DATATYPE> name
        static string myName = "Dustin";
        static int loopCount = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(myName);

            string name = "Humberto";
            name = "Daniel";
            name = "Simone";

            bool looping = true;
            while (looping)
            {
                Console.WriteLine("I'm looping");
                //set looping flag to false
                looping = false;
            }

            //adding a double variable to 
            //an int variable
            int anInt = 5;
            double aDouble = 3.5;
            //if you want to store a the sum
            //must use a double variable.
            double total = anInt + aDouble;
            
            //modulo, doubles, and you
            // ex. 3.5 % 2 == 1.5
            Console.WriteLine(aDouble % 2);

            //call the function to increase loopcount
            // to increment a GLOBAL int value.
            aFunction();
            Console.WriteLine(loopCount);
            aFunction();
            Console.WriteLine(loopCount);
            aFunction();
            Console.WriteLine(loopCount);


            //Keep the console open
            Console.ReadKey();
        }

        static void aFunction()
        {
            for (int i = 0; i < 53; i++)
            {

                loopCount = loopCount + 1;
            }

        }
    }
}
