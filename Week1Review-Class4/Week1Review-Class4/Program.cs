using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1Review_Class4
{
    class Program
    {
        //declare a global variable to hold
        // the total number of loops executed
        static int loopCount = 0;

        static void Main(string[] args)
        {
            //call the stringbuilding function
            StringBuilding("a brown fox jumped over the brown fence to watch doctor who");
            //print out the number of loops performed
            Console.WriteLine(loopCount);

            //call the stringbuilding function to do
            // more loops
            StringBuilding("running a few more loops");
            //print out the number of loops performed
            Console.WriteLine(loopCount);

            //Call our ListPractice() function
            ListPractice();

            //keep console window open
            Console.ReadKey();
        }

        //building a string
        //Take in a string, and output a string
        // with all vowels uppercase, and
        // all consonants lowercase.
        static void StringBuilding(string input)
        {
            //declare a string to hold 
            // our output
            string output = "";

            //loop over the input, to compare
            // each letter
            for (int i = 0; i < input.Length; i++)
            {
                //get a letter from the input
                // convert the char to a string
                string letter = input[i].ToString();

                //determine if the letter is a vowel
                string vowels = "aeiou";
                if (vowels.Contains(letter.ToLower()))
                {
                    //it is a vowel, add it a uppercase
                    // letter to our output
                    output = output + letter.ToUpper();
                }
                else
                {
                    //its not a vowel.  add it a lowercase
                    // letter to our output
                    output = output + letter.ToLower();
                }
                //we did a loop, hooray!
                // add one to the loop counter
                loopCount = loopCount + 1;
            }
            //after the loop, print the output
            Console.WriteLine(output);
        }

        //working with LISTS
        static void ListPractice()
        {
            //declare a new list of strings
            List<string> sportsList = new List<string>() { "Baseball", "Basketball", "Badmitton", "La Crosse", "Luge", "Curling" };

            //print out the contents of sportsList using a for loop
            // in asceding order
            for (int i = 0; i < sportsList.Count; i++)
            {
                Console.WriteLine(sportsList[i]);
                //we did a loop, count it on the loopCount global variable
                loopCount++;
            }

            //print out the contents of sportsList using a
            // for loop in reverse order.
            //Things to Note: .Count - 1, >= 0
            for (int i = sportsList.Count - 1; i >= 0; i = i - 1)
            {
                Console.WriteLine(sportsList[i]);
                //we did a loop, count it on the loopCount global variable
                loopCount++;
            }

            //list out the contents of the sportsList using a
            // foreach loop
            foreach (var item in sportsList)
            {
                Console.WriteLine(item);
            }

            //looping over a string using a foreach loop
            string whatever = "party on wayne";
            foreach (char item in whatever)
            {
                Console.WriteLine(item);
            }
        }
    }
}
