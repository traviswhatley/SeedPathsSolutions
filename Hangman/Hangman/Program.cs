using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //bool keepPlaying = true;
            //can do a while loop to keep
            // playing here
            Hangman();

            Console.ReadKey(); //keep the console open
        }

        static void Hangman()
        {
            //boolean to hold whether to continue the game.
            bool playing = true;
            string playerName; //hold the player's name
            int lives = 7; //number of guesses
            
            //Create our word bank, obviously
            List<string> wordBank = new List<string>() {"nickleback","nickleback"};
            
            Random rng = new Random(); //make a new rng
            //select a random number between 0 and the #
            // of things in our wordBank List
            int randomNumber = rng.Next(0, wordBank.Count());
            //choose a random item from our wordBank List
            // force it to be UPPERCASE
            string wordToGuess = wordBank[randomNumber].ToUpper();

            //one line solution for getting a random item
            //string wordToGuess = wordBank[new Random().Next(0, wordBank.Count())];

            //need to track what letters they've guessed
            string lettersGuessed = string.Empty;

            //start our game loop
            while (playing)
            {
                //1. show the masked word
                Console.WriteLine(MaskedWord(wordToGuess, lettersGuessed));
                //2. tell them how many lives left
                Console.WriteLine("You have " + lives + " lives left");
                //3. ask for input
                Console.WriteLine("Enter a guess");
                //4. get the input, force it to be UPPERCASE
                string input = Console.ReadLine().ToUpper();

                //determine if its a letter or a word guess
                if (input.Length == 1)
                {
                    //guessed a letter, add it to the string
                    lettersGuessed += input;

                    //letter guess.  determine if its a
                    // correct guess
                    if (wordToGuess.Contains(input))
                    {
                        //correct guess!
                        Console.WriteLine("Good job!");
                        //determine if they have guessed all the letters in the word
                        if (AllLettersGuessed(MaskedWord(wordToGuess, lettersGuessed)))
                        {
                            playing = false;
                            Console.WriteLine("You won! Who is awesome?  You are awesome!");
                        }
                    }
                    else
                    {
                        //incorrect guess!
                        Console.WriteLine("Bad job");
                        lives--;
                    }
                }
                else
                {
                    //word guess
                    if (wordToGuess == input)
                    {
                        //they won
                        Console.WriteLine("You won!");
                        playing = false;
                    }
                    else
                    {
                        //lose a life
                        Console.WriteLine("Incorrect");
                        lives--;
                    }
                }
                //check for a loss because of life
                if (lives == 0)
                {
                    playing = false;
                    Console.WriteLine("You suck, not like nickleback.");
                }

            }
            
        }

        static string MaskedWord(string wordToGuess, string lettersGuessed)
        {
            //a string to return our masked word.
            // ex: a _ _ l _
            string returnString = "";

            //loop over the string to examine each character
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                //get a character from wordToGuess by using
                // the index i
                char letter = wordToGuess[i];

                //check if the letter in the wordToGuess 
                // has been guessed by the user
                //Using Char.ToUpper() to make sure its UPPERCASE
                if (lettersGuessed.ToUpper().Contains(Char.ToUpper(letter)))
                {
                    //they've guessed the letter, so add the letter
                    // not an underscore to our return string
                    returnString += letter + " ";
                }
                else
                {
                    //did NOT guess the letter, add an underscore
                    // to our return string.
                    returnString += "_" + " ";
                }
            }
            //return the returnString
            return returnString;
        }

        static bool AllLettersGuessed(string maskedWord)
        {
            //determine if the user has guessed all the
            //letters of the word.
            if (maskedWord.Contains("_"))
            {
                return false;
            }
            else
            {
                return true;
            }

            //One line solution: not maskedWord contains an underscore
            //return !maskedWord.Contains("_");
        }
    }
}
