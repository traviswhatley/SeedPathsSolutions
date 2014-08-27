using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingOverStrings_Class4
{
    class Program
    {
        static void Main(string[] args)
        {
            FindALetter("e", "the united states of 'murica");
            FindAWord("and", "i'm really happy that its not raining today, because rain is for the birds and jerks. and and and");

            //keep the console window open
            Console.ReadKey();
        }

        //create a new function to loop over the letters of
        // a string, and count the number of a certain letter
        static void FindALetter(string letterToFind, string text)
        {
            //declare a variable to hold the # 
            // of letter matches
            int letterCount = 0;

            //loop over the string
            for (int i = 0; i < text.Length; i++)
            {
                //get the current letter we're 
                // looking at, and convert to a 
                // string for ease of use
                string letter = text[i].ToString();
                
                //is this a letter we need to find?
                //convert both the letter and letterToFind
                // to lowercase
                if (letter.ToLower() == letterToFind.ToLower())
                {
                    //found a letter, increment 
                    // our counter
                    letterCount = letterCount + 1;
                }
            }
            //time to display output
            Console.WriteLine("Found " + letterCount + " " + 
                letterToFind + "'s in '" + text);
        }

        //Create a function to loop over words in a string
        static void FindAWord(string wordToFind, string text)
        {
            //counter to count the number of words found
            int wordCount = 0;
            //split the string into words, 
            // and convert the array to a list for ease of use
            List<string> words = text.Split(' ').ToList();

            //loop over each word
            for (int i = 0; i < words.Count; i++)
            {
                //get the current word in our loop
                string word = words[i];
                //compare the lowercase word with the wordToFind
                if (word.ToLower() == wordToFind.ToLower())
                {

                    //found a word, COUNT IT!
                    wordCount = wordCount + 1;
                }
            }
            //output
            Console.WriteLine("Found " + wordCount + " " +
                wordToFind + "'s in '" + text);
        }
    }
}
