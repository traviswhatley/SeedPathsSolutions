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
            Console.WriteLine("Input: {0}", input);
            //standarize my input
            input = input.ToLower();
            //print # of letters
            Console.WriteLine("# of letters: {0}", input.Length);
            //print # of words
            Console.WriteLine("# of words: {0}", input.Split(' ').Count());
            //print # of vowels
            Console.WriteLine("# of vowels: {0}", input.Where(x => "aeiou".Contains(x.ToString())).Count());
            //print # of consonants
            Console.WriteLine("# of consonants: {0}", input.Count(x => "bcdfghjklmnpqrstvwxyz".Contains(x.ToString())));
            //print # of special characters
            Console.WriteLine("# of special characters: {0}", input.Count(x => "?.'\" !@#$%^&*()<>,/".Contains(x.ToString())));
            //print longest word
            Console.WriteLine("Longest Word: {0}", input.Split(' ').OrderBy(x => x.Length).Last());
            //print shortest word
            Console.WriteLine("Shortest Word: {0}", input.Split(' ').OrderBy(x => x.Length).First());
        }
    }
}
