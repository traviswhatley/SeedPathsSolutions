using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            FindPrimes(10001);
            Console.WriteLine();
            EvenFibonacciSequencer(1000000);
            //EvenFibonacciSequencer(22);
            var timeStart = DateTime.Now;
            Console.WriteLine();
            Console.WriteLine("Starting Collatz Sequence.... Engage");
            Console.WriteLine("Collatz Start Time: " + DateTime.Now.ToLongTimeString());
            LongestCollatzSequence(1000000);
            //Console.WriteLine("Collatz Sequence took: " + (DateTime.Now - timeStart).Milliseconds + " milliseconds.");
            Console.WriteLine("Collvatz End Time: " + DateTime.Now.ToLongTimeString());
            
            Console.ReadKey();

        }

        static void FindPrimes(int maxPrime)
        {
            //integer to hold the number of primes we've found
            int primeCount = 0;
            //integer to see if its a prime number
            //starting at 2 because 1 is not a prime
            int testNumber = 2;
            //use a while loop to count prime numbers
            while (primeCount < maxPrime)
            {
                if (IsPrime(testNumber))
                {
                    //is a prime, add one to our count
                    primeCount += 1;
                }
                //increment our test number
                testNumber += 1;
            }
            Console.WriteLine("The " + maxPrime + " prime is: " + (testNumber - 1));
        }

        static bool IsPrime(int num)
        {
            bool prime = true;
            for (var i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }

        static void EvenFibonacciSequencer(int maxValue)
        {
            //fib seqence starts with 1 and 2.
            int first = 1;
            int second = 2;
            int sum = 0;
            //int to hold total of evens, starts at 
            // 2 since we've already placed that value in 
            // second
            int evenTotal = 2;

            //while our fib numbers are less than the max
            // do some stuff
            while (sum < maxValue)
            {
                //add the fib numbers
                sum = first + second;
                //see if the sum is even
                if (sum % 2 == 0)
                {
                    evenTotal += sum;
                }
                //shift numbers down for the next fib loop
                first = second;
                second = sum;
            }
            Console.WriteLine("Even Total: " + evenTotal);
        }

        static void LongestCollatzSequence(int input)
        {
            //counting the number of operations to get to 1
            int count = 0;
            //keep track of our longest number and chain for output
            int maxCount = 0;
            int maxNumber = 0;

            //looping from 1 to whatever input is
            for (int i = 1; i < input; i++)
            {
                //n is the variable we will be doing math on
                long n = i;
                //reset the count to 1
                count = 1;
                while (n != 1)
                {
                    if (n % 2 == 0)
                    {
                        //it's even
                        n = n / 2;
                    }
                    else
                    {
                        //it's odd
                        n = n * 3 + 1;
                    }
                    //add to the count.
                    count++;
                }
                //see if this number produced a higher count than others
                if (maxCount < count)
                {
                    //set the maxCount and maxNumber to our current number
                    maxCount = count;
                    maxNumber = i;
                }
            }
            //output
            Console.WriteLine(maxNumber + " is the number with the longest chain of " + maxCount + " between 1 - " + String.Format("{0:n0}", input));
        }

        //static void FindPrimes(int maxPrime)
        //{
        //    int numPrimes = 0;
        //    int curNum = 2;
        //    while (numPrimes < maxPrime)
        //    {
        //        if (IsPrime(curNum)) { numPrimes++; }
        //        curNum++; 
        //    }
        //    Console.WriteLine("last prime was: " + (curNum  - 1) );
        //}

        //static bool IsPrime(int num)
        //{
        //    bool prime = true;
        //    for (var i = 2; i < num; i++ )
        //    {
        //        if (num % i == 0)
        //        {
        //            prime = false;
        //            break;
        //        }
        //    }
        //    return prime;
        //}

        //static void EvenFibonacciSequencer(int maxValue) {
        //    int curNum = 2;
        //    int prevNum = 1;
        //    //starts at 2
        //    int evenTotal = 2;

       

        //    while (curNum < maxValue)
        //    {
        //        int newNum = prevNum + curNum;
        //        if (newNum % 2 == 0) { evenTotal += newNum; }
        //        prevNum = curNum;
        //        curNum = newNum;
        //    }
        //    Console.WriteLine("Fibonnaci Even Total (1 - " + curNum + "): " + evenTotal);
        //}

        //static void LongestCollatzSequence(int input)
        //{
        //    //runTo = 20000000
        //    int longestChain = 0;
        //    int longestNumber = 0;
        //    for (var i = 1; i <= input; i++ )
        //    {
        //        long curNum = i;
        //        int curChain = 1;   
        //        while (curNum != 1)
        //        {
        //            if (curNum % 2 == 0)
        //            {
        //                //it's even
        //                curNum = curNum / 2;
        //            }
        //            else
        //            {
        //                //must be odd
        //                curNum = (curNum * 3) + 1;
        //            }
        //            curChain += 1;
        //        }
        //        if (curChain > longestChain) { longestChain = curChain; longestNumber = i; }
        //    }

        //    Console.WriteLine(longestNumber + " is the number with the longest chain of " + longestChain + " between 1 - " + String.Format("{0:n0}", input));
            

        //}

        

      
    }
}
