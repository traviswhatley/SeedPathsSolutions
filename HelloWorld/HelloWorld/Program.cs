using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //our code goes here!
            Console.WriteLine("Hello World");

            //loop from 1 to 1000, print out every number

            for (int i = 1; i <= 1000; i = i + 1)
            {
                // the code inside of the code block { }, gets repeated each time
                Console.WriteLine(i);
            }

            //same loop, only using a while this time
            //Step 1. Create an incrementor
            int j = 1;
            //Step 2. Set up your while loop
            while (j <= 1000)
            {
                Console.WriteLine(j);
                //Step 3. INCREMENT!
                j = j + 1;
            }

            //call our greeting function.
            Console.WriteLine(Greeting("Santa Claus"));
            Console.WriteLine(Greeting("That guy from Nickelback"));

            //call our random loop function
            RandomLoop(10);
            RandomLoop(32);
            RandomLoop(72);

            //call multiply
            Multiply(31, 2);

            Multiply(31, 2, 3);

            //keep the console window open
            //this should always be the last line of your Main() function.
            Console.ReadKey();
        }

        //When creating a new function declaration, it MUST go outside of other functions, but inside of a class

        /// <summary>
        /// A function that greets somebody
        /// </summary>
        /// <param name="name">The name of the person to greet</param>
        /// <returns>Returns a string with both the greeting and the name</returns>
        static string Greeting(string name)
        {
            return "Hello, " + name;
        }

        /// <summary>
        /// Does a loop from 1 to 100, incrementing by a random number between 1 and the maximumNumber each time.
        /// </summary>
        /// <param name="maximumNumber">Maximum number to increment by</param>
        static void RandomLoop(int maximumNumber)
        {
            //declare a new random number generator
            Random randomNumberGenerator = new Random();
            for (int i = 1; i <= 100; i = i + randomNumberGenerator.Next(1, maximumNumber + 1))
            {
                Console.WriteLine(i);
            }

        }

        /// <summary>
        /// Multipies some nummbas
        /// </summary>
        /// <param name="numberOne">a number</param>
        /// <param name="numberTwo">another number</param>
        /// <returns>the product of two numbers</returns>
        static int Multiply(int numberOne, int numberTwo)
        {
            return numberOne * numberTwo;
        }

        static int Multiply(int numberOne, int numberTwo, int numberThree)
        {
            return Multiply(Multiply(numberOne, numberTwo), numberThree);
            //or
            //return numberOne * numberTwo * numberThree;
        }
        
      
    }
}
