﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        //GLOBAL VARIABLES
        static Random rng = new Random();
        static int PauseDuration = 1000;

        static bool IsPlaying = true;
        static int RoundCounter = 0;
        static int NachosRemaining = 0;
        static int BirdsRemaining = 0;
        static bool ChuckNorrisPower = false;
        static string PlayerSuccess = string.Empty;
        static string BirdSuccess = string.Empty;



        static void Main(string[] args)
        {
            Console.SetWindowSize(116, 50);

            IntroAnimation();
            TitleSequence();
            Instructions();
            RunGame();

            //for testing...
            //Console.ReadKey();
        }


        /// <summary>
        /// animation sequence to start off game
        /// </summary>
        static void IntroAnimation()
        {
            Console.CursorVisible = false;
            IntroAniGraphics(0);
            Thread.Sleep(PauseDuration);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("Man....I love being retired.", 30);
            Thread.Sleep(PauseDuration * 2);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("                              ", 8);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("Nothing like enjoying some NACHOS at the beach.", 30);
            Thread.Sleep(PauseDuration * 2);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("                                                ", 8);
            Thread.Sleep(PauseDuration * 2);

            Console.Clear();
            IntroAniGraphics(1);
            Thread.Sleep(PauseDuration);
            Console.SetCursorPosition(15, 18);
            OldTimeyTextPrinter("OH CRAP!!  NOT AGAIN....!", 30);
            Thread.Sleep(PauseDuration);

            Console.Clear();
            IntroAniGraphics(2);
            Thread.Sleep(PauseDuration);
            Console.Clear();
            IntroAniGraphics(3);
            Thread.Sleep(PauseDuration / 4);
            Console.Clear();
            IntroAniGraphics(4);
            Thread.Sleep(PauseDuration / 2);
            Console.SetCursorPosition(15, 32);
            OldTimeyTextPrinter("GET AWAY FROM MY NACHOS YOU DAMN BIRDS!!!", 30);
            Thread.Sleep(PauseDuration * 3);
        }

        /// <summary>
        /// more animation...title of game and picture of players
        /// </summary>
        static void TitleSequence()
        {
            Console.Clear();
            SeagullShowdownText_1();
            Thread.Sleep(PauseDuration / 2);
            Console.Clear();
            SeagullShowdownText_2();
            Thread.Sleep(PauseDuration / 2);
            ManandSeagull_2();
            Thread.Sleep(PauseDuration);

            //make title of game "blink" 3 times
            for (int i = 0; i < 3; i++)
            {
                Console.Clear();
                SeagullShowdownText_3();
                ManandSeagull_2();
                Thread.Sleep(PauseDuration / 4);
                Console.Clear();
                SeagullShowdownText_2();
                ManandSeagull_2();
                Thread.Sleep(PauseDuration / 4);
            }

            Thread.Sleep(PauseDuration * 2);

        }

        /// <summary>
        /// Prints instructions on how to play the game.
        /// </summary>
        static void Instructions()
        {
            Console.CursorVisible = false;
            Console.Clear();

            SeagullShowdownText_2();
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            OldTimeyTextPrinter("Man, you've been through this crap before.  Just trying to enjoy some nachos at the beach \nand a swarm of Seagulls come and eat all your food, ruining the day.", 20);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("This time you're fighting back!!  You've brought a bunch of Alka-Seltzer with you...\nknowing that Seagulls blow up if they eat one.", 20);
            Thread.Sleep(PauseDuration / 2);
            Console.WriteLine();
            Console.WriteLine();
            OldTimeyTextPrinter("You've also been honing your skills at kicking sand.  You're totally ready for this!!", 20);
            Thread.Sleep(PauseDuration);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("       COMBAT CHOICES:");
            Thread.Sleep(PauseDuration);
            OldTimeyTextPrinter("**Alka-Seltzer kills a bird and causes others to fly away...IF the bird eats it.", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("**Kicking sand always works, but only makes a few birds fly away at most.", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration / 4);
            OldTimeyTextPrinter("**Add more chips to the nachos if you almost run out (2-4).", 10);
            Console.WriteLine();
            Thread.Sleep(PauseDuration);
            Console.WriteLine();
            OldTimeyTextPrinter("WORK FAST!!!  The Seagulls are attacking your plate the whole time, grabbing up to several chips at a time!!", 20);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(PauseDuration);

            //instruction screen will remain until user presses a key to start the game
            Console.WriteLine("Press any key to continue: ");
            Console.ReadKey();
        }

        /// <summary>
        /// Main game function, collects input and processes it.
        /// </summary>
        static void RunGame()
        {
            IsPlaying = true;
            RoundCounter = 0;
       //***REMEMBER TO CHANGE VALUES BACK TO 20 AND 30 after testing
            NachosRemaining = 20;
            BirdsRemaining = 30;
            ChuckNorrisPower = false;
            PlayerSuccess = string.Empty;
            BirdSuccess = string.Empty;

            //game runs until player wins or loses and gets to choose to quit
            while (IsPlaying == true)
            {
                Console.Clear();
                //once "Chuck Norris Power" is turned on it remains on.  Has 30% random chance of turning on only after 4th round of play.
                if (ChuckNorrisPower == false)
                {
                    if (RoundCounter > 4)
                    {
                        if (3 >= rng.Next(1, 11))
                        {
                            ChuckNorrisPower = true;
                        }
                    }
                }
                //Display title of game
                SeagullShowdownText_2();
                //Display current round information (such as points remaining, etc)
                RoundInfo();
                //Display basic combat instructions
                BasicInstructions();

                //Get user input, then validate.  If valid then process input by game logic and increase counter.
                string userCombatChoice = Console.ReadLine();
                if (InputValidator(userCombatChoice))
                {
                    GameAction(userCombatChoice);
                    RoundCounter++;
                }
                //check to see if player has won or lost
                WhoWon();
            }
        }

        /// <summary>
        /// Displays information from previous round of game play
        /// </summary>
        static void RoundInfo()
        {
            //after first round 
            if (RoundCounter > 0)
            {
                //Print results of Player and Bird success results from last round of play
                OldTimeyTextPrinter(PlayerSuccess, 10);
                Thread.Sleep(PauseDuration / 2);
                Console.WriteLine();
                Console.WriteLine();
                OldTimeyTextPrinter(BirdSuccess, 10);
                Thread.Sleep(PauseDuration);
            }
            //when game first starts, before there are any play results yet
            else
            {
                Thread.Sleep(PauseDuration / 2);
                OldTimeyTextPrinter("NEVER GIVE UP!!", 10);
                Thread.Sleep(PauseDuration / 2);
                Console.WriteLine();
                Console.WriteLine();
                OldTimeyTextPrinter("THESE BIRDS WILL STOP AT NOTHING!!", 10);
                Thread.Sleep(PauseDuration);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //print number of birds and nachos remaining and include graphical representation of score
            Console.Write(("Number of remaining BIRDS:  " + BirdsRemaining).PadRight(33));
            for (int i = 0; i < BirdsRemaining; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            //Console.WriteLine();
            Console.Write(("Number of remaining NACHOS: " + NachosRemaining).PadRight(33));
            for (int i = 0; i < NachosRemaining; i++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine();

        }

        /// <summary>
        /// Basic instructions of game printed every round
        /// </summary>
        static void BasicInstructions()
        {
            //print basic instructions
            Console.WriteLine("Enter 1 to use an Alka-Seltzer tablet...");
            Console.WriteLine("Enter 2 to kick sand at the damn birds...");
            Console.WriteLine("Enter 3 to replenish your chips if running low...");
            Console.WriteLine();
            //if Chuck Norris Power is turned on print following text to inform player and tell them how to use it.
            if (ChuckNorrisPower == true)
            {
                ChuckNorrisPowerText();
                Console.WriteLine();
                Console.WriteLine("***HOLY SMOKES!!***  The Gods have bestowed upon you CHUCK NORRIS POWER!!");
                Console.WriteLine("Enter 4 to throw a tornado of sand at the birds and wipe them out!!!  DO IT!!!");
                Console.WriteLine();
                Console.WriteLine();
            }
            Console.Write("Enter your combat choice: ");
        }

        /// <summary>
        /// Input needs to be a 1, 2, or 3.  Can be a 4 only after "Chuck Norris Power" is enabled
        /// </summary>
        /// <param name="userInput_">1, 2, 3, or sometimes a 4</param>
        /// <returns>true if input is valid</returns>
        static bool InputValidator(string userInput_)
        {
            //if input is more or less than 1 digit, it's invalid
            if (userInput_.Length != 1)
            {
                Console.WriteLine();
                OldTimeyTextPrinter("ENTER A VALID INPUT...", 10);
                PlayerSuccess = "STOP GOOFING AROUND!!";
                BirdSuccess = "YOUR NACHOS ARE IN DANGER!!";
                Thread.Sleep(PauseDuration);
                return false;
            }
            //if input is a 1, 2, or a 3 then the input is valid
            else if ("123".Contains(userInput_[0]))
            {
                return true;
            }
            //input of 4 is valid only if Chuck Norris Power is enabled, otherwise invalid
            else if (userInput_ == "4")
            {
                if (ChuckNorrisPower == true)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine();
                    OldTimeyTextPrinter("ENTER A VALID INPUT...", 10);
                    PlayerSuccess = "STOP GOOFING AROUND!!";
                    BirdSuccess = "YOUR NACHOS ARE IN DANGER!!";
                    Thread.Sleep(PauseDuration);
                    return false;
                }
            }
            //if input is invalid (for a case i didn't think of testing for...)
            else
            {
                Console.WriteLine();
                OldTimeyTextPrinter("ENTER A VALID INPUT...", 10);
                PlayerSuccess = "STOP GOOFING AROUND!!";
                BirdSuccess = "YOUR NACHOS ARE IN DANGER!!";
                Thread.Sleep(PauseDuration);
                return false;
            }


        }

        /// <summary>
        /// Main game logic, using a rng to determine results from user input
        /// </summary>
        /// <param name="userChoice_">user's input while playing game</param>
        static void GameAction(string userChoice_)
        {
        //***maybe make some string arrays to give slightly differnt responses for "PlayerSuccess" and "BirdSuccess"
            //turn user choice into an integer number
            switch (Int32.Parse(userChoice_))
            {
                //combat choice 1
                case 1:
                    //if the Alka-Seltzer works...
                    if (rng.Next(2) == 0)
                    {
                        //Your play first
                        BirdsRemaining--;
                        //rng to see how many extra birds fly away
                        int extraBirdsFlyAway = rng.Next(2, 5);
                        BirdsRemaining -= extraBirdsFlyAway;
                        //to prevent score from going below zero
                        if (BirdsRemaining < 0)
                        {
                            BirdsRemaining = 0;
                        }
                        //string created that prints in RoundInfo() function
                        PlayerSuccess = "THE ALKA-SELTZER WORKED!!  " + extraBirdsFlyAway + " other birds also flew away!!";
                        //Seagull's play
                        SeagullsTurn();

                        //show animation of play results
                        Console.Clear();
                        BirdEatsAlkaSeltzer();
                        Thread.Sleep(PauseDuration);
                    }
                    else
                    {
                        //Your play
                        PlayerSuccess = "Sorry, that bird is too smart for your shenanigans.";
                        //Seagull's play
                        SeagullsTurn();

                        //animation of play results
                        Console.Clear();
                        BirdAvoidsAlkaSeltzer();
                        Thread.Sleep(PauseDuration * 2);
                    }
                    break;

                case 2:
                    //Your play
                    //effectiveness of sand kick
                    int sandSuccess = rng.Next(1, 4);
                    BirdsRemaining -= sandSuccess;
                    if (BirdsRemaining < 0)
                    {
                        BirdsRemaining = 0;
                    }
                    PlayerSuccess = "Nice sand kick!!  " + sandSuccess + " birds flew off.";
                    //Seagull's play
                    SeagullsTurn();

                    //graphic of play result
                    Console.Clear();
                    KickSand();
                    Thread.Sleep(1500);
                    break;

                case 3:
                    //Your play
                    //determine number of chips added
                    int chipsAdded = rng.Next(2, 5);
                    NachosRemaining += chipsAdded;
                    PlayerSuccess = "You added " + chipsAdded + " chips back to your nachos.";
                    //Seagull's play
                    SeagullsTurn();
                    //no animation or graphics for adding chips
                    break;

                case 4:
                    //Your play
                    BirdsRemaining = 0;
                    PlayerSuccess = "OH YEAH!!!  You wiped them all out!!  Time to chill with some nachos!!";
                    //Seagull's play
                    BirdSuccess = "Seagulls are no match for a Chuck Norris size tornado of sand!!";

                    //Chuck Norris Power animation
                    Console.Clear();
                    ChuckNorrisFace();
                    Thread.Sleep(PauseDuration * 2);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// determinds number of chips seagulls take per round
        /// </summary>
        static void SeagullsTurn()
        {
            int nachosTaken = 0;

            nachosTaken = rng.Next(1, 4);
            NachosRemaining -= nachosTaken;
            if (NachosRemaining < 0)
            {
                NachosRemaining = 0;
            }
            BirdSuccess = "The Seagulls made off with " + nachosTaken + " of your chips!!";
        }

        /// <summary>
        /// checks to see if you or the seagull has won
        /// </summary>
        static void WhoWon()
        {
            //YOU LOST!!
            if (NachosRemaining <= 0)
            {
                //show final round info
                Console.Clear();
                SeagullShowdownText_2();
                RoundInfo();
                Thread.Sleep(PauseDuration * 3);
                Console.Clear();
                Console.CursorVisible = false;
                //animation if you lost
                for (int i = 0; i < 3; i++)
                {
                    YouLost();
                    Thread.Sleep(PauseDuration / 6);
                    Console.Clear();
                    Thread.Sleep(PauseDuration / 6);
                }
                YouLost();
                Console.WriteLine();
                OldTimeyTextPrinter("         You can't win against some pesky birds???", 20);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(PauseDuration);
                //ask user if they want to play again
                PlayAgain();
            }
            //YOU WON!!
            else if (BirdsRemaining <= 0)
            {
                //show final round info
                Console.Clear();
                SeagullShowdownText_2();
                RoundInfo();
                Thread.Sleep(PauseDuration * 3);
                Console.Clear();
                Console.CursorVisible = false;
                //animation if you won
                for (int i = 0; i < 3; i++)
                {
                    YouWon();
                    Thread.Sleep(PauseDuration / 6);
                    Console.Clear();
                    Thread.Sleep(PauseDuration / 6);
                }
                YouWon();
                Console.WriteLine();
                OldTimeyTextPrinter("         Damn birds are no match for your awesome skills!!", 20);
                Console.WriteLine();
                Console.WriteLine();
                Thread.Sleep(PauseDuration);
                //ask user to play again
                PlayAgain();
            }
        }

        /// <summary>
        /// ask user to play again, run game again if yes, exit game if no
        /// </summary>
        static void PlayAgain()
        {
            Console.WriteLine();
            Console.Write("Do you want to play again, Y or N: ");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                RunGame();
            }
            IsPlaying = false;
        }

        /// <summary>
        /// Prints text to screen one char at a time
        /// </summary>
        /// <param name="inputText">text you want to print</param>
        /// <param name="pause">time between each digit printing</param>
        static void OldTimeyTextPrinter(string inputText, int pause)
        {
            //loop through each character
            for (int i = 0; i < inputText.Length; i++)
            {
                char letter = inputText[i];
                Console.Write(letter);
                Thread.Sleep(pause);
            }
        }


        //************GRAPHICS**************

        static void IntroAniGraphics(int picNumber_)
        {
            switch (picNumber_)
            {
                case 0:
                    Console.WriteLine(@"
                 

                                                                              .     :     .
                                                                            .  :    |    :  .
                                                                             .  |   |   |  ,
                                                                              \  |     |  /
                                                                          .     ,-''''`-.     .
                                                                            '- /         \ -'
                                                                              |           |
                                                                        - --- |           | --- -
                                                                              |           |
                                                                            _- \         / -_
                                                                          .     `-.___,-'     .
                                                                              /  |     |  \
                                                                            .'  |   |   |  `.
                                                                               :    |    :
                                                                              .     :     .
                                                                                    .
 

              

    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                                                     ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          <()>                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 1:
                    Console.WriteLine(@"
                 

                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /         \ -'
            `^`^`^'`',    ;                                                   |           |
                      '; (                                              - --- |           | --- -
                        ``                                                    |           |
                                                                            _- \         / -_
                                                                          .     `-.___,-'     .
                                                                              /  |     |  \
                                                                            .'  |   |   |  `.
                                                                               :    |    :
                                                                              .     :     .
                                                                                    .
 

              

    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                                                     ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          <()>                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 2:
                    Console.WriteLine(@"
                 

                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /         \ -'
            `^`^`^'`',    ;                                                   |           |
                      '; (                        ___   ________        - --- |           | --- -
                        ``                       /---<9;/  ,__-==`            |           |
                                                ./~~( `)/`                  _- \         / -_
                                             ,-'_/// \  }                 .     `-.___,-'     .
                                              ~       XX\\                    /  |     |  \
                                                          \                 .'  |   |   |  `.
                                                                               :    |    :
                                                                              .     :     .
                                                                                    .
 

              

    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                         \    /                      ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          \()/                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 3:
                    Console.WriteLine(@"
 
                
                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /         \ -'
            `^`^`^'`',    ;                                                   |           |
                      '; (                        ___   ________        - --- |           | --- -
                        ``                       /---<9;/  ,__-==`            |           |
                                                ./~~( `)/`                  _- \         / -_
                                             ,-'_/// \  }                 .     `-.___,-'     .
                                              ~       XX\\                    /  |     |  \
      .`.   _ ____                                        \                 .'  |   |   |  `.
    __;_ \ /,//---\                                                            :    |    :
    --, `._) (                                                                .     :     .
     '//,,,  |                                                                      .
          )_/                
         /_|                 
                             
                                
    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                         \    /                      ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          \()/                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                case 4:
                    Console.WriteLine(@"
 
                
                                                                              .     :     .
                                                                            .  :    |    :  .
                       _,___                                                 .  |   |   |  ,
             __.=""=._/' /---\                                                 \  |     |  /
            `'=.__,    (                                                  .     ,-''''`-.     .
            ,'=='   ;  `=,                                                  '- /  __ __  \ -'
            `^`^`^'`',    ;                                                   |  | .I. |  |
                      '; (                        ___   ________        - --- |   --^--   | --- -
                        ``                       /---<9;/  ,__-==`            |    ___    |
                                                ./~~( `)/`                  _- \  (___)  / -_
                                             ,-'_/// \  }                 .     `-.___,-'     .
                                              ~       XX\\                    /  |     |  \
      .`.   _ ____                                        \                 .'  |   |   |  `.
    __;_ \ /,//---\                                                            :    |    :
    --, `._) (                                                                .     :     .
     '//,,,  |                              ,                                       .
          )_/                 ,_     ,     .'<_
         /_|                 _> `'-,'(__.-' __<
                             >_.--(.. )  =;`
                                  `V-'`'\/``
    ---....___________________________________  ___ _______ __ _ ___ ___ __ _ _ _____ _ _ ___ __  _ ___ _____
                                              ---...__ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== _-=_-_ -=- =-
                         \    /                      ---...___ =-= = -_= -=_= _-=_-_ -=- =-_=_-_ -=-== 
                          \()/                                 ```--.._= -_= -_= _-=- -_= _=-_= _-=- -_
                           #\                                        ``--._=-_ =-=_-= _-= _=-_ =-=_-
                           ##\/\                                           ``-._=_-=_- =_-=_= _-=- --
                           #####\_                                           `-._-=_-_=-=-_ =-=_=-
                                                                                 `-._=-_=-=_-= _-= _-=_-_ -=- =-
                                                                                   `-._= _-=- -_-=_-_ -=- =-
                                                                                      `-._=-_=-=_-= _-= 

");
                    break;

                default:
                    break;
            }
        }

        static void SeagullShowdownText_1()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
  _____   ___   ____   ____  __ __  _      _         
 / ___/  /  _] /    T /    T|  T  T| T    | T        
(   \_  /  [_ Y  o  |Y   __j|  |  || |    | |       
 \__  TY    _]|     ||  T  ||  |  || l___ | l___      
 /  \ ||   [_ |  _  ||  l_ ||  :  ||     T|     T    
 \    ||     T|  |  ||     |l     ||     ||     |    
  \___jl_____jl__j__jl___,_j \__,_jl_____jl_____j      
                                                                                                                   
");
            Console.WriteLine();
        }

        static void SeagullShowdownText_2()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
  _____   ___   ____   ____  __ __  _      _           _____ __ __   ___   __    __  ___     ___   __    __  ____  
 / ___/  /  _] /    T /    T|  T  T| T    | T         / ___/|  T  T /   \ |  T__T  T|   \   /   \ |  T__T  T|    \ 
(   \_  /  [_ Y  o  |Y   __j|  |  || |    | |        (   \_ |  l  |Y     Y|  |  |  ||    \ Y     Y|  |  |  ||  _  Y
 \__  TY    _]|     ||  T  ||  |  || l___ | l___      \__  T|  _  ||  O  ||  |  |  ||  D  Y|  O  ||  |  |  ||  |  |
 /  \ ||   [_ |  _  ||  l_ ||  :  ||     T|     T     /  \ ||  |  ||     |l  `  '  !|     ||     |l  `  '  !|  |  |
 \    ||     T|  |  ||     |l     ||     ||     |     \    ||  |  |l     ! \      / |     |l     ! \      / |  |  |
  \___jl_____jl__j__jl___,_j \__,_jl_____jl_____j      \___jl__j__j \___/   \_/\_/  l_____j \___/   \_/\_/  l__j__j
                                                                                                                   
");
            Console.WriteLine();
        }

        static void SeagullShowdownText_3()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(@"
  _____   ___   ____   ____  __ __  _      _           _____ __ __   ___   __    __  ___     ___   __    __  ____  
 / ___/  /  _] /    T /    T|  T  T| T    | T         / ___/|  T  T /   \ |  T__T  T|   \   /   \ |  T__T  T|    \ 
(   \_  /  [_ Y  o  |Y   __j|  |  || |    | |        (   \_ |  l  |Y     Y|  |  |  ||    \ Y     Y|  |  |  ||  _  Y
 \__  TY    _]|     ||  T  ||  |  || l___ | l___      \__  T|  _  ||  O  ||  |  |  ||  D  Y|  O  ||  |  |  ||  |  |
 /  \ ||   [_ |  _  ||  l_ ||  :  ||     T|     T     /  \ ||  |  ||     |l  `  '  !|     ||     |l  `  '  !|  |  |
 \    ||     T|  |  ||     |l     ||     ||     |     \    ||  |  |l     ! \      / |     |l     ! \      / |  |  |
  \___jl_____jl__j__jl___,_j \__,_jl_____jl_____j      \___jl__j__j \___/   \_/\_/  l_____j \___/   \_/\_/  l__j__j
                                                                                                                   
");
            Console.WriteLine();
        }

        static void ManandSeagull_2()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"
                                                   
                .-'--.                                                                  _______        
              .'      '.                                                            _.-'       ''...._
             /     _    `-.                                                       .'        .--.    '.`
            /      .\-     \,  ,                                                 : .--.    :    :     '-.
           ;       .-|-'    \####,                                              : :    :   :    :       :`
           |,       .-|-'    ;####                                              : :  @ :___:  @ : __     '`.
          ,##         `     ,|###'                                       _____..:---''''   `----''  `.   .''
        #,####, '#,        ,#|^;#                                     -''                      ___j  :   :
        `######  `#####,|##' |`)|                                    /                   __..''      :    `.
         `#####    ```o\`\o_.| ;\                                   /---------_______--''        __..'   /``
          (-`\#,    .-'` |`  : `;                                   \ _______________________--''       /
          `\ ;\#,         \   \-'                                                    --''               \
            )( \#    C,_   \   ;                                                     :                :`.:
            (_,  \  /   `'./   |                                                      :              /
              \  / | .-`'--'`. |                                                       \            /
               | ( \   ,  /_,  |                                                        \          .'
               \    `   ``     /                                                         :         :
                '-.__     // .'                                                           :        \
                     `'`.__.'                                                             :         \

");

        }

        static void ChuckNorrisPowerText()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(@"
  _______            __     _  __             _       ___                    
 / ___/ /  __ ______/ /__  / |/ /__  ________(_)__   / _ \___ _    _____ ____
/ /__/ _ \/ // / __/  '_/ /    / _ \/ __/ __/ (_-<  / ___/ _ \ |/|/ / -_) __/
\___/_//_/\_,_/\__/_/\_\ /_/|_/\___/_/ /_/ /_/___/ /_/   \___/__,__/\__/_/   
                                                                             ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void ChuckNorrisFace()
        {
            Console.WriteLine(@"                                                                                
                                ..MMMMMMMMMMM. ..                               
                              .$MMMMMMMMMMMMMMMMM..                             
                            ..MMMMMMMMMMMMMMMMMMMM .                            
                           .MMMMMMMMMMMMMMMMMMMMMMM .                           
                          .MMMMMMMMMMMMMMMMMMMMMMMMM..                          
                          MMMMMMMMMMMMMMMMMMMMMMMMMMM.                          
                        .MMMMMMMMMMMMMMMMMMMMMMMMMMMM:                          
                        OMMMMMMMMMMMMMMMMMMMMMMMMMMMMM               
                        MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMI..            
                        8MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM:          
         $MMMMMMMMM$,.   MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM.       
      MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMD    
    OMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM    
    MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM   
    MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM   
    MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM 
     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM  
     MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM..MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM
      MMMMMMMMMMMMMMMMMMM    MMMMMM.  7MMMMMD       MMMMMMMMMMMMMMMMMMMMMMMMMM 
      ?MMMMMMMMMMMMMMMMMO  MMMMMMMM      MMMMM8  .   MMMMMMMMMMMMMMMMMMMMMMMMM
       NMMMMMMMMMMMMMMMMN  ....MMM .      ... ....    MMMMMMMMMMMMMMMMMMMMMMMM 
        NMMMMMMMMMMMMMMMM.      M, .                  ,MMMMMMMMMMMMMMMMMMMMMM+ 
         8MMMMMMMMMMMMMMM       M.                    .MMMMMMMMMMMMMMMMMMMMMM  
           MMMMMMMMMMMMMM ..                     .    ZMMMMMMMMMMMMMMMMMMMMM    
            MMMMMMMMMMMMM       ...    .          . ..MMMMMMMMMMMMMMMMMMMMM  
              MMMMMMMMMMM       MMM~.MMM.          ..MMMMM MMMMMMMMMMMMMMM    
               ~MMMMMMMMM        MMMM               MMM.O. MMMMMMMMMMMMMM   
                  MMMMMMM    .MMMMMMMMMMMD          IM  .  MMMMMMMMMMMM     
                     MMMM. .MMMMMMMMMMMMMMMM        IM.  .MMMMMMMMMMM     
                        M .MMMMMMMMMMMMMMMMMM    ..DMM . OMMMMMMMMM         
                        M.MMMN           8MMMM, ..~MMM. +MMMMMMMM              
                        MMMM               ~MMM..IMMMM..MMMMMMMMMI              
                        MMMMM    MMM        ZMMMMMMMMM8.MMMMMMMMMM            
                        MMMMMMMMMMMMMMMMMMMMMMMMMMMM8 .8MMMMMMMM              
                        7MMMMMMMMMMMMMMMMMMMMMMMMMMM . ,MMMMMMMMM               
                         OMMMMMMMMMMMMMMMMMMMMMMMMM.    MMMMMMMMM              
                          NMMMMMMMMMMMMMMMMMMMMMMZ      ? MMMMMMM              
                           $MMMMMMMMMMMMMMMMMMMM,..     .MMMMMM8MM             
                             MMMMMMMMMMMMMMMMM. .        ?MMMMM             
                               MMMM=7MMMMMM, ...      ..MMMMMM            
                                   .. . . . .         MMMMMMMMO                 
                                                   .MMMMMMMMMMM                 
                              M                 ..DMMMMMMMMMMMMM              
                             MMM      .  .N    .~MMMMMMMMMMMMMMM               
                           .MMMMM     .MM.    .MMMMMMMMMMMMMMMMMM             
                          7MMMMMMN    ....   MMMMMMMMMMMMMMMMMMMM              
                         NMMMMMMMM.        MMMMMMMMMMMMMMMMMMMMM               
                        MMMMMMMMMMM      MMMMMMMMMMMMMMMMMMMMM          
");
        }

        static void BirdEatsAlkaSeltzer()
        {
            Console.WriteLine(@"


                                             _______
                                         _.-'       ''...._
                                       .'        .--.    '.`
                                      : .--.    :    :     '-.
                                     : :    :   :    :       :`
                                     : :  @ :___:  @ : __     '`.
                              _____..:---''''   `----''  `.   .''
                      	   -''                      ___j  :   :
                          /                   __..''      :    `.
                         /---------_______--''        __..'   /``
                         \ _______________________--''       /
                                          --''               \
                                          :                :`.:
                                           :              /
                                            \            /
                                             \          .'
                                              :         :
                                               :        \
                                               :         \

");
            Thread.Sleep(PauseDuration);
            Console.Clear();

            Console.WriteLine(@"


                                             _______
                                         _.-'       ''...._
                                       .'        .--.    '.`
                                      : .--.    :    :     '-.
                                     : :    :   :    :       :`
                                     : :  @ :___:  @ : __     '`.
                              _____..:---''''   `----''  `.   .''
                      	   -''                            :   :
                          /                               :    `.
                         /--------@@-------------\    __..'   /``
                          ________@@_____________/--''       /
                         \ _______________________:          \
                                          :                :`.:
                                           :              /
                                            \            /
                                             \          .'
                                              :         :
                                               :        \
                                               :         \

");
            Thread.Sleep(PauseDuration / 2);
            Console.Clear();

            Console.WriteLine(@"


                                             _______
                                         _.-'       ''...._
                                       .'        .--.    '.`
                                      : .--.    :    :     '-.
                                     : :    :   :    :       :`
                                     : :  @ :___:  @ : __     '`.
                              _____..:---''''   `----''  `.   .''
                      	   -''                      ___j  :   :
                          /                   __..''      :    `.
                         /---------_______--''        __..'   /``
                         \ _______________________--''       /
                                          --''               \
                                          :                :`.:
                                           :              /
                                            \            /
                                             \          .'
                                              :         :
                                               :        \
                                               :         \

");
            Thread.Sleep(PauseDuration / 2);
            Console.Clear();

            Console.WriteLine(@"


                                             _______
                                         _.-'    .----...._
                                       .'----.  :      : '.`
                                      ::      : :      :   '-.
                                     : :   X  : :   X  :     :`
                                     : :      :_:      :      '`.
                              _____..:---''''   `----'        .''
                      	   -''                            \   :
                          /                               :    `.
                         /-------\                    __..'   /``
                         \ _______________________--''       /
                                          --''               \
                                          :                :`.:
                                           :              /
                                            \            /
                                             \          .'
                                              :         :
                                               :        \
                                               :         \

");
            Thread.Sleep(PauseDuration);
            Console.Clear();

            Console.WriteLine(@"






                        ██████╗  ██████╗  ██████╗ ███╗   ███╗██╗██╗
                        ██╔══██╗██╔═══██╗██╔═══██╗████╗ ████║██║██║
                        ██████╔╝██║   ██║██║   ██║██╔████╔██║██║██║
                        ██╔══██╗██║   ██║██║   ██║██║╚██╔╝██║╚═╝╚═╝
                        ██████╔╝╚██████╔╝╚██████╔╝██║ ╚═╝ ██║██╗██╗
                        ╚═════╝  ╚═════╝  ╚═════╝ ╚═╝     ╚═╝╚═╝╚═╝
                                           

");
           


        }

        static void BirdAvoidsAlkaSeltzer()
        {
            Console.WriteLine(@"


                                             _______
                                         _.-'       ''...._
                                       .'        .--.    '.`
                                      : .--.    :    :     '-.
                                     : :    :   :    :       :`
                                     : :  @ :___:  @ : __     '`.
                              _____..:---''''   `----''  `.   .''
                      	   -''                      ___j  :   :
                          /                   __..''      :    `.
                         /---------_______--''        __..'   /``
                         \ _______________________--''       /
                                          --''               \
                                          :                :`.:
                                           :              /
                                            \            /
                                             \          .'
                                              :         :
                                               :        \
                                               :         \

");
            Thread.Sleep(PauseDuration);
            Console.Clear();
            Console.WriteLine(@"


                                             _______
                                         _.-'       ''...._
                                       .' \        /     '.`
                                      : .--\      /--.     '-.
                                     : :____\   /____:       :`
                                     : :--@-:___:--@-:        '`.
                              _____..:---''''   `----''__     .''
                      	   -''                           \    :
                          /        _________              :    `.
                         /---------         -----___      :   /``
                         \ ____------------_____    \     /  /
                                            ''        ---    \
                                            :              :`.:
                                            :             /
                                            \            /
                                             \          .'
                                              :         :
                                               :        \
                                               :         \

");

        }

        static void KickSand()
        {
            Console.WriteLine(@"
                                                                *   *
                                                      *      *          *     *
                                                      
                       \|//                      *        *         *       *
                     -/_ /            ,-.   *         *
                       _\\_           |  \    *     *           *
                       \_  \          x  |   *   *      *                 *
                 ,///   >   )         \_  \     *     *             *
                / + +\ /   /         _/ )_/         *           *               *
                |     )  \/        _/ \/        *     *     * *
                /\__D/    \      _/    )                  *
                 /  _   o  \   _/,   _/        *    *           *   *
                /   /       ,_/   __/            *      *
               /   / \    o//    _/       * 
              /__o/   \___|    _/               *
              _//       \__ __/\            *               *
              \  \>       \     \            
              // |         \__   \            
                            /    /
                            \___(
                            /_/
                           / O \
                           '-   \__
                             \_____)  

");
        }

        static void YouWon()
        {
            Console.WriteLine(@"
                                                       ______ __          
                                                     {-_-_= '. `'.          
                                                      {=_=_-  \   \     
                       \|//                      *     {_-_   |   /   
                     -/_ /            ,-.   *           '-.   |  /    .===,
                       _\\_           |  \    *      .--.__\  |_(_,==`  ( o)'-...
                       \_  \          x  |   *      `---.=_ `     ;      `/ -----\
                 ,///   >   )         \_  \             `,-_       ;    .'
                / + +\ /   /         _/ )_/               {=_       ;=~`    
                |     )  \/        _/ \/                   `//__,-=~`
                /\__D/    \      _/    )                   <<__ \\__
                 /  _   o  \   _/,   _/                    /`)))/`)))
                /   /       ,_/   __/       
               /   / \    o//    _/        
              /__o/   \___|    _/          
              _//       \__ __/\            
              \  \>       \     \            
              // |         \__   \            
                            /    /
                            \___(
                            /_/
                           / O \
                           '-   \__
                             \_____)  

");
        }

        static void YouLost()
        {
                    Console.WriteLine(@"
                                               _
                                              ~\\_
                                                \\\\
                                               `\\\\\
                         |                       |\\\\\
          \_            /;                        \\\\\|__.--~~\
          `\~--.._     //'                     _--~            /
           `//////\  \\/;'                ___/~ //////  _-~~~~'
             ~/////\~\`---\             /____'-//////-//
                 `~'  |                      //////(((-)
                 ;'_\'\                    /////
                /~/ '' ''               _///'                
               `\/'                    ~


                       _O/                
                         \        
                         /\_         
                         \      
        
");
        }


    }
}