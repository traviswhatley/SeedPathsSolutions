using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingOverStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            //how to loop over a string by each letter
            string text2 = "it looks pretty crappy outside";
            for (int i = 0; i < text2.Length; i = i + 1)
            {
                // get one letter from our string
                char letter = text2[i];
                //see if that character is a p
                if (letter == 'p')
                {
                    Console.WriteLine("Found a P!!! huzzah!");
                }
            }

            //how to loop over each word in a string
            string text = "it looks pretty crappy outside";
            //splitting the text into words
            // and converting to a List
            List<string> wordList = text.Split(' ').ToList();
            //print out the words in reverse order
            for (int i = wordList.Count() - 1; i >= 0; i = i - 1)
            {
                //print out the word to the console.
                Console.WriteLine(wordList[i]);
            }

            //keep the console open
            Console.ReadKey();
        }


        
    }
}
