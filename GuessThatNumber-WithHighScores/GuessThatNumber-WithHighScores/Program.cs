using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber_WithHighScores
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayHighScores();

            //Call the function
            GuessThatNumber();

            //Keep the console open
            Console.ReadKey();

        }

        /// <summary>
        /// A function to guess a number
        /// </summary>
        static void GuessThatNumber()
        {
            //Make a random number generator
            Random rng = new Random();
            //Get our number to guess
            int rand = rng.Next(0, 101);

            //Boolean to keep guessing
            bool guessing = true;

            //Guess counter
            int guesses = 0;
            bool hasGuessed = false;
            //While we haven't guessed the number
            while (guessing)
            {
                bool isHigh = false;
                //Prompt the user
                if (!hasGuessed)
                {
                    Console.WriteLine("I am sure you will not guess this number correctly. Not even if I told you it was from 1 to 100. \nGo ahead though, I will enjoy watching you struggle.");
                    hasGuessed = true;
                }
                else
                {
                    Console.WriteLine("I don't understand why you perservere but try again if you must.");
                }
                //Get input
                string input = Console.ReadLine();
                //Declare our guess variable
                int guess = 0;

                //Attempt to parse our input 
                if (!(int.TryParse(input, out guess)))
                {
                    //If fail, then chastize
                    Console.WriteLine("That is not a number");
                    //Call them high
                    guess = 101;
                }
                //Increase guesses
                guesses++;
                //Is guess too high?
                if (guess > rand)
                {
                    if (!isHigh)
                    {
                        Console.WriteLine("Don't get ahead of yourself, that was too high.");
                        isHigh = true;
                    }
                    else
                    {
                        if (guess - rand > 25)
                        {
                            Console.WriteLine("You are so far away. You might as well give up.");

                        }
                        else if (guess - rand > 5 && guess - rand < 25)
                        {
                            Console.WriteLine("Even as you approach the number you are doubting yourself.");
                        }
                        else if (guess - rand < 5)
                        {
                            Console.WriteLine("You are quite close but you will inevitably fail.");
                        }
                    }

                }
                //Is it too low?
                else if (guess < rand)
                {
                    //Let them know!
                    if (isHigh)
                    {
                        Console.WriteLine("You really aren't very confident in this are you. Try a little higher.");
                        isHigh = false;
                    }
                    else
                    {

                        if (rand - guess > 25)
                        {
                            Console.WriteLine("That is a serious underestimation. Are you even trying?");
                        }
                        else if (rand - guess > 5 && rand - guess < 25)
                        {
                            Console.WriteLine("You are getting closer. Truthfully, I'll be glad to be rid of you.");
                        }
                        else if (rand - guess < 5)
                        {
                            Console.WriteLine("You are really close which makes this even more unbearable");
                        }
                    }
                }
                //Otherwise
                else
                {
                    //They are correct
                    Console.WriteLine("Really, I thought it was going to take much longer to guess this simple number. You took a pitiful " + guesses + " guesses to accomplish this meaningless task!");
                    //Stop guessing
                    guessing = false;
                }


            }
            //game over, add to high scores, display high scores
            AddHighScore(guesses);
            DisplayHighScores();

        }

        static void AddHighScore(int playerScore)
        {
            //get the player name for the high scores
            Console.WriteLine("Your name:");
            string playerName = Console.ReadLine();

            //create a gateway to the database
            DustinEntities db = new DustinEntities();
            
            //create a new high score object,
            // fill it with our user's data
            HighScore newHighScore = new HighScore();
            newHighScore.DateCreated = DateTime.Now;
            newHighScore.Game = "Guess That Number";
            newHighScore.Name = playerName;
            newHighScore.Score = playerScore;

            //add it to the database
            db.HighScores.Add(newHighScore);

            //save our changes
            db.SaveChanges();
            

        }

        static void DisplayHighScores()
        {
            //clear the console
            Console.Clear();
            //Write the High Score Text
            Console.WriteLine("Guess That Number High Scores");
            Console.WriteLine("-----------------------------");

            //create a new connection to the database
            DustinEntities db = new DustinEntities();
            //get the high score list
            List<HighScore> highScoreList = db.HighScores
                .Where(x => x.Game == "Guess That Number")
                .OrderBy(x => x.Score).Take(10)
                .ToList();

            foreach (HighScore highScore in highScoreList)
            {
                Console.WriteLine("{0}. {1} - {2} on {3}", 
                    highScoreList.IndexOf(highScore) + 1, 
                    highScore.Name, 
                    highScore.Score,
                    highScore.DateCreated.Value.ToShortDateString());
            }
            Console.WriteLine("\n\n\n");

        }
    }
}