using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i = i + 1)
            {
                FizzBuzz(i);
            }
            Console.WriteLine();
            for (int i = 10; i <= 30; i = i + 3)
            {
                FizzBuzz(i);
            }

            int j = 100;
            while (j >= 0)
            {
                FizzBuzz(j);
                j = j - 4;
            }

            bool looping = true;
            while (looping)
            {
                Console.WriteLine("I'm looping");
                if (j > 50)
                {
                    looping = false;
                }
                j = j + 1;
            }

            List<string> fruitList = new List<string>() { "kiwi", "apple", "orange" };
            fruitList.Add("strawberry");
            Console.WriteLine(fruitList[1]);

            for (int i = 0; i < fruitList.Count(); i = i + 1)
            {
                Console.WriteLine(fruitList[i]);
            }
            //foreach is optional (for now)
            foreach (string fruit in fruitList)
            {
                Console.WriteLine(fruit);
            }

            
            List<string> carList = new List<string>() { "BMW", "Audi" };

           
            Console.ReadKey(); //keep window open
        }
        static void FizzBuzz(int number)
        {
            //check if number is divisible by 
            // 5 and 3
            if (number % 5 == 0 && number % 3 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (number % 5 == 0) //divisible by 5?
            {
                Console.WriteLine("Fizz");
            }
            else if (number % 3 == 0) //divisible by 3?
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(number);
            }
        }
    }
}
