using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekOnePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string myName = "Lauren Sweany";
            int myAge = 27;
            bool myBool = true;
            List<string> productsList = new List<string>() { "basketball", "baseball glove", "tennis shoes", "hockey puck" };

            Console.WriteLine("My name is " + myName + " and I am a beast of a programer ");
            Console.WriteLine("I am " + myAge + " years awesome.");
            Console.WriteLine(" I set my boolean value equal to " + myBool);


            for (int i = 0; i <= 4; i++)
            {
                //printing out the product list mentioned above
                Console.WriteLine(productsList);

            }

            for (int i = 1; i <= 10; i++)
            {
                //printing out numbers 1-10
                Console.WriteLine(i);
            }
            for (int i = 10; i >= 1; i = i - 1)
            {
                //counting down from 10-1
                Console.WriteLine(i);
            }

            for (int i = 10; i <= 30; i = i + 2)
            {
                //printing 10-30 even numbers only
                Console.WriteLine(i);
            }

            for (int i = 100; i >= 75; i = i - 5)
            {
                //printing out the numbers 100-75, printing only the fifth number
                Console.WriteLine(i);
            }

            int count = 1;
            while (count <= 10)
            {
                //using a while loop to count from 1 to 10

                count = count + 1;
                Console.WriteLine(count);
            }

            count = 10;
            while (count <= 1)
            {
                //using a while loop to count backwards from 10 to 1

                count = count - 1;
                Console.WriteLine(count);
            }

            count = 16;
            while (count <= 30)
            {
                //using while loop to count from 15 to 30 only even numbers
                count = count + 2;
                Console.WriteLine(count);
            }

            count = 100;
            while (count <= 75)
            {
                //using while loop to count from 100 to 75 only printing every fifth number
                count = count - 5;
                Console.WriteLine(count);
            }


            count = 1;
            while (myBool)
            {
                if (count % 4 == 0)
                {
                    myBool = false;
                }
                Console.WriteLine(count);
                count++;

            }
            Console.WriteLine("My name, " + myName + ", has " + myName.Count() + " in it. ");
            Console.WriteLine("My product list has " + productsList.Count() + " in it. ");

            for (int i = 0; i < productsList.Count(); i++)
            {
                Console.WriteLine(productsList[i] + " has " + productsList[i].Replace(" ", "").Length + " in it. ");
            }
            myGreeting(myName);

            myGreeting("Beef Hardchest");

            DoubleIt(1337);

            DoubleIt(27);

            Multiply(2, 8);

            Multiply(3, myAge);

            LoopThis(20, 30);

            LoopThis(0, myAge);

            SuperLoop(0, 100, 15);

            SuperLoop(0, 200, myAge);

            Console.WriteLine(NewGreeting("Neil deGrasse-Tyson"));

            Console.WriteLine(NewGreeting(myName));

            Console.WriteLine(TripleIt(10));

            Console.WriteLine(TripleIt(myAge));

            Console.WriteLine(RealMultiply(5, 10));

            Console.WriteLine(RealMultiply(2, myAge));

            SuperLoop(RealMultiply(1, 5), TripleIt(myAge), TripleIt(myAge - 10));

            SuperLoop(RealMultiply(1, TripleIt(3)), TripleIt(RealMultiply(myAge, 7)), TripleIt(myAge - RealMultiply(2, 4)));

            Console.ReadKey();




        }
        static void myGreeting(string name)
        {
            Console.WriteLine(" Hello, " + name);
        }

        static void DoubleIt(int num1)
        {
            Console.WriteLine(num1 + " doubled is " + num1 * 2);
        }

        static void Multiply(int num1, int num2)
        {
            Console.WriteLine(num1 + " times " + num2 + " is " + (num1 * num2));
        }

        static void LoopThis(int startNum, int endNum)
        {
            Console.WriteLine("I'm looping from " + startNum + " to " + endNum);
            for (int i = startNum; i <= endNum; i++)
            {
                Console.WriteLine(i);
            }


        }

        static void SuperLoop(int startNum, int endNum, int increment)
        {
            int loopCount = 0;
            Console.WriteLine("I'm looping from " + startNum + " to " + endNum + " ,incrementing " + increment + " each time.");
            for (int i = startNum; i <= endNum; i += increment)
            {
                Console.WriteLine(i);
                loopCount++;

            }
            Console.WriteLine("That loop was craaaaaazy, we looped " + loopCount + " times.");

        }
        static string NewGreeting(string name)
        {
            return "Hello, " + name;
        }

        static int TripleIt(int number)
        {
            return number * 3;
        }

        static int RealMultiply(int num1, int num2)
        {
            return num1 * num2;
        }


    }



}
