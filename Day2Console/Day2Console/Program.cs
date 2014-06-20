using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //new function declarations
            //can't be here
            HelloWorld();
            Greeting("Dustin");
            Greeting("Pat");
            Add(7, 3);
            Console.WriteLine(Multiply(3, 7));
            int total = Multiply(13, 236);
            Add(total, 10);
            Console.ReadKey(); //keeps window open
            
        }

        static void HelloWorld()
        {
            Console.WriteLine("Hello World");
        }

        static void Greeting(string name)
        {
            Console.WriteLine("How's it going " + name);
        }

        static void Add(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }

        static int Multiply(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
