using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            TextStats("who is your daddy and what does he do?");
            Console.ReadKey();
        }

        static void TextStats(string input)
        {
            //standardize our input
            input = input.ToLower();
            //# of letters
            Console.WriteLine("# of letters: " + input.Length);
            //# of vowels
            Console.WriteLine("# of vowels: " + input.Where(x => "aeiou".Contains(x)).Count());
            //# of special chars
            Console.WriteLine("# of spec chars: " + input.Where(x => " .,?".Contains(x)).Count()); 
            //# of consonants
            Console.WriteLine("# of consonants: " + input.Where(x => !"aeiou .,?".Contains(x)).Count()); 

            //# of words
            Console.WriteLine("# of words: " + input.Split(' ').Count());
            //longest word
            Console.WriteLine("Longest word: " + input.Replace(".", "").Split(' ').OrderByDescending(x => x.Length).First());
            //second longest word
            Console.WriteLine("2nd Longest word: " + input.Split(' ').OrderByDescending(x => x.Length).Skip(1).Take(1).First());
            //shortest word
            Console.WriteLine("Shortest word: " + input.Split(' ').OrderBy(x=> x.Length).First());
        }
    }
}
