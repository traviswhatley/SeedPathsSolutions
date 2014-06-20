using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataConversions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data conversions
            //Converting a string to a number
            string numberString = "1234";
            string numberString2 = "10";
            Console.WriteLine(numberString + numberString2);
            //Convert to an int
            int aNumber = int.Parse(numberString);
            int aNumber2 = int.Parse(numberString2);
            Console.WriteLine(aNumber + aNumber2);

            //Converting charactors to strings
            char letter = 'c';
            string letterString = letter.ToString();
            //Convert the string to UPPERCASE
            Console.WriteLine(letterString.ToUpper());
            //Convert the string to LOWERCASE
            Console.WriteLine(letterString.ToLower());

            string test = "Asdf";
            Console.WriteLine(test);
            test = test.Remove(2, 1).Insert(2, " ");


            bool itsPrime = true;
            for (int i = 0; i < 12; i++)
            {
                if (true) //check to see if its divisible
                {
                    //if it is divisible, not a prime
                    itsPrime = false;
                    break;
                }
            }

            if (itsPrime)
            {
                Console.WriteLine("its prime");
            }
            else
            {
                Console.WriteLine("not prime");
            }

            Console.WriteLine(test);

            //Keep the console window open
            Console.ReadKey();
        }
    }
}
