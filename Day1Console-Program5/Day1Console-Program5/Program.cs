using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Console_Program5
{
    class Program
    {
        static void Main(string[] args)
        {
            //where our code goes

            //Write hello world to the console
            Console.WriteLine("Hello World!");

            //declare a variable to hold a name
            string name = "Dustin";

            //write a greeting to the console
            Console.WriteLine("Hello, " + name);

            name = "Kraft";

            //see if name is my first name or last name
            if (name == "Dustin")
            {
                //name is my first name
                Console.WriteLine("sweet name bro");
            }
            else if (name=="Kraft")
            {
                Console.WriteLine("regal last name, good sir");
            }

            for (int i = 0; i < 21; i = i + 1)
            {
                Console.WriteLine(i);
            }

            //print out each letter of name, one per line
            for (int i = 0; i < name.Length; i = i + 1)
            {
                char letter = name[i];
                Console.WriteLine(letter);
            }
            
            //do the same as above, only reversed
            for (int i = name.Length - 1; i >= 0; i = i - 1)
            {
                Console.WriteLine(name[i]);
            }

            //call our Add() function
            Console.WriteLine(Add(20, 15));

            //keep the console window open
            Console.ReadKey();
            
        }

        //new functions must go outside of
        // other functions, but still inside
        // of a class
        /// <summary>
        /// Adds two numbers
        /// </summary>
        /// <param name="num1">Number to add</param>
        /// <param name="num2">Another number to add</param>
        /// <returns>Sum of num1 and num2</returns>
        static int Add(int num1, int num2)
        {
            return num1 + num2;
        }


    }
}
