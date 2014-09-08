using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler_Class4
{
    class Program
    {
        static void Main(string[] args)
        {

            //call our Disemvoweler
            Disemvoweler("Nickleback is Logan's favorite band.  Their songwring cannot be beat!  Dark Horse is his favorite album.");

            //get a string to disemvowel from the user
            Console.WriteLine("Enter a sentence to disemvowel.");
            //place the user's input into a string variable
            string input = Console.ReadLine();
            //call the disemvoweler with the user's input
            Disemvoweler(input);

            //calling for user input inline with the disemvoweler call
            Console.WriteLine("\nEnter a sentence to disemvowel.");
            Disemvoweler(Console.ReadLine());
            

            //keep the console open
            Console.ReadKey();
        }

        /// <summary>
        /// Takes out the vowels and spaces of a string
        /// and print out the disemvowled string and the
        /// original
        /// </summary>
        /// <param name="input">string to disemvowel</param>
        static void Disemvoweler(string input)
        {
            //declare an output variable
            //string output = "";
            string output = string.Empty;
            //declare a variable to hold the vowels
            string vowels = string.Empty;

            //loop over each letter of the string
            for (int i = 0; i < input.Length; i++)
            {
                //put the current letter into a varible
                string letter = input[i].ToString();
                //determine if the letter is a vowel
                // (the letter.ToLower() converts the letter
                //  to lowercase, just for the if comparison,
                //  it does not change the value of letter
                //  permenently)
                if ("aeiou".Contains(letter.ToLower()))
                {
                    //its a vowel
                    vowels += letter;
                }
                else if (letter == " ")
                {
                    //its a space, do nothing
                }
                else
                {
                    //not a vowel or space, add it
                    // to the output
                    output += letter;
                }
            }
            //looped through all the letters
            //time to print the output
            Console.WriteLine("Original: " + input);
            Console.WriteLine("Disemvoweled: " + output);
            Console.WriteLine("Vowels: " + vowels);
        }


    }
}
