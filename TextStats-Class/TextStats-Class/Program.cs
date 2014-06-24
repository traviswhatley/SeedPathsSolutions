using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStats_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStats("who is your daddy and what does he do?");
            TextStats("i dont know.  some words here.  things too.  I like stuff and things.");
            //Keep the console open
            Console.ReadKey();
        }

        static void TextStats(string input)
        {
            //display the original input
            Console.WriteLine("Original Input: " + input);
            //format my string to be all lowercase
            input = input.ToLower();

            //number of characters
            Console.WriteLine("# of Characters: " + input.Length);
            //number of words
            Console.WriteLine("# of Words: " + input.Split(' ').Length);

            // declaring variables to hold the number
            // of each type of character
            int numVowels = 0;
            int numCons = 0;
            int specChars = 0;
            for (int i = 0; i < input.Length; i++)
            {
                //grabbing one letter from the string
                // by it's index.
                char letter = input[i];
                //number of vowels
                //Is it a vowel?
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    //found a vowel! add 1 to the vowel count
                    numVowels = numVowels + 1;
                }
                else if (letter == '.' || letter == ' ')
                {
                    //number of special characters
                    //found a spec char, add 1 to our counter
                    specChars = specChars + 1;
                }
                else
                {
                    //number of consonants
                    //assume we found a consonant, 
                    //add 1 to our counter
                    numCons = numCons + 1;
                }   
            }
            //Output number of vowels, cons,
            // and spec chars
            Console.WriteLine("# of Vowels: " + numVowels);
            Console.WriteLine("# of Consonants: " + numCons);
            Console.WriteLine("# of Spec Chars: " + specChars);
        }
    }
}
