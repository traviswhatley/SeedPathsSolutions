using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1CodeChallenge_Class_4
{
    class Program
    {
        static void Main(string[] args)
        {
            //call fizzbuzz for 0=>20
            Console.WriteLine("Calling Fizzbuzz for 0=>20");
            for (int i = 0; i <= 20; i++)
            {
                FizzBuzz(i);
            }
            Console.WriteLine("Calling Fizzbuzz for 92=>72");
            //call fizzbuzz for 92=>72
            for (int i = 92; i >= 72; i--)
            {
                FizzBuzz(i);
            }

            Console.WriteLine("\n\n YODAIZER");
            Yodaizer("I like code");
            Yodaizer("I really like code");
            Yodaizer("Nickleback rocks hard");

            Console.WriteLine("\n\n TEXT STATS");
            TextStats("Logan's favorite band is Nickleback.  He wants everyone to know.  He started the Denver chapter of their fan club.");

            Console.WriteLine("\n\n IS PRIME");
            for (int i = 1; i <= 25; i++) //call for 1=>25
            {
                IsPrime(i);
            }

            Console.WriteLine("\n\n DASH INSERT");
            DashInsert(8675309);
            DashInsert(353535353);
            //keep the console window open
            Console.ReadKey();
        }

        //Function for FizzBuzz
        static void FizzBuzz(int number)
        {
            //check to see if its 
            // divisable by 5 & 3
            if (number % 3 == 0 && number % 5 == 0)
            {
                //div by both, write fizzbuzz
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 5 == 0)
            {
                //div by 5, write fizz
                Console.WriteLine("Fizz");
            }
            else if (number % 3 == 0)
            {
                //div by 3, write buzz
                Console.WriteLine("Buzz");
            }
            else
            {
                //not div by any, write the number
                Console.WriteLine(number);
            }
        }

        //function for the Yodaizer
        static void Yodaizer(string text)
        {
            //prints out each word of the text
            // in opposite order

            //use .split function to split the text
            // into a list of words
            List<string> words = text.Split(' ').ToList();

            //declare a string to hold output text
            string output = "";

            //Extra Credit: Check for three words
            if (words.Count == 3)
            {
                //is 3 words, print the last one first, then the
                // other two in normal order
                //We know the the words list contains 3 items,
                // words[2] is the last word, words[0] is the first
                output = words[2] + ", " + words[0] + " " + words[1];
            }
            else
            {
                //Extra Credit: Not 3 words long
                // proceed normally

                //loop through each word, starting with
                // the last word.  
                for (int i = words.Count - 1; i >= 0; i--)
                {
                    //add the current word to the
                    // output, with a space for readability.
                    output = output + words[i] + " ";
                }
            }
            //print out the output
            Console.WriteLine(output);
        }

        //function for TextStats
        static void TextStats(string input)
        {
            //print the # of characters, # words, # vowels
            // # consonants, # special characters

            int numChars = input.Length;
            //split the input on the spaces, count the #
            // of items in the list
            int numWords = input.Split(' ').ToList().Count;
            //declare integers to hold the # of character
            // types
            int numVowels = 0;
            int numCons = 0;
            int numSpec = 0;

            for (int i = 0; i < input.Length; i++)
            {
                //grab our current letter from the input
                //lowercase it to standardize the input
                string letter = input[i].ToString().ToLower();
                if ("aeiou".Contains(letter))
                {
                    //it is a vowel, add to #vowels
                    numVowels++;
                }
                else if (" .,?".Contains(letter))
                {
                    //its a special char
                    numSpec++;
                }
                else
                {
                    //its a consonant
                    numCons++;
                }
            }
            //looped through all letters, print output
            Console.WriteLine(input);
            Console.WriteLine("# Chars: " + numChars);
            Console.WriteLine("# Words: " + numWords);
            Console.WriteLine("# Vowels: " + numVowels);
            Console.WriteLine("# Consonants: " + numCons);
            Console.WriteLine("# Spec Chars: " + numSpec);

        }

        //function for IsPrime
        static void IsPrime(int number)
        {
            //assume the number is prime
            // until it isn't
            bool prime = true;
            //need to check all numbers in
            // between 1 and itself to see
            // if it is divisible by anything else
            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    //it's divisible a number, not a prime
                    prime = false;
                    break; // escape the loop
                }
            }
            //done with the loop, time for output
            if (prime)
            {
                Console.WriteLine(number + " is prime");
            }
            else
            {
                Console.WriteLine(number);
            }
        }

        //function for DashInsert
        static void DashInsert(int number)
        {
            //Goal: Insert a dash between two odd numbers
            //declare a string to hold our output
            string output = ""; 
            //declare a string to hold our number as a string
            // and convert the input number to a string
            string numberString = number.ToString();
            //loop through each digit of our string
            for (int i = 0; i <= numberString.Length - 2; i++)
            {
                //get our current digit and the one next to it
                string num1String = numberString[i].ToString();
                string num2String = numberString[i + 1].ToString();
                //convert our numberStrings to actual numbers
                int num1 = int.Parse(num1String);
                int num2 = int.Parse(num2String);
                //see if they are both odd
                if (num1 % 2 != 0 && num2 % 2 != 0)
                {
                    //both odd, add num1 and dash to the output
                    output = output + num1 + "-";
                }
                else
                {
                    //not both add, just add num1
                    output = output + num1;
                }
            }
            //need to add the last digit to our output, 
            //because the loop does not add it
            output = output + numberString[numberString.Length - 1];
            //print output
            Console.WriteLine(output);
        }

    }
}
