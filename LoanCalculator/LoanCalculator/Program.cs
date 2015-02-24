using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Amortization table1 = new Amortization(new SerialLoan(1000, 0.01, 10));
            Amortization table2 = new Amortization(new AnnuityLoan(10000, 0.02, 10));

            table1.Print();
            table2.Print();
        }
    }

    /// <summary>
    /// Our base abstract class that represents the properties and methods of a Loan, but does not implement the behaviors of any particular type of loan.
    /// </summary>
    public abstract class Loan
    {
        protected double principal;
        protected double rate;
        protected int periods;

        public Loan(double principal, double rate, int periods)
        {
            this.principal = principal;
            this.rate = rate;
            this.periods = periods;
        }

        public double Principal
        {
            get { return this.principal; }
        }

        public double Rate
        {
            get { return this.rate; }
        }

        public int Periods
        {
            get { return periods; }
        }

        abstract public double Payment(int n);
        abstract public double Interest(int n);
        abstract public double Repayment(int n);
        abstract public double Outstanding(int n);
    }

    public class SerialLoan : Loan
    {
        public SerialLoan(double principal, double rate, int periods)
            : base(principal, rate, periods)
        {
            //since we are using the base class (Loan) constructor, we don't need to put any code here
        }

        public override double Repayment(int n)
        {
            return principal / periods;
        }

        public override double Outstanding(int n)
        {
            return Repayment(0) * (periods - n);
        }

        public override double Interest(int n)
        {
            return Outstanding(n - 1) * rate;
        }

        public override double Payment(int n)
        {
            return Repayment(n) + Interest(n);
        }
    }

    public class AnnuityLoan : Loan
    {
        public AnnuityLoan(double principal, double rate, int periods) : base(principal, rate, periods) 
        {
            //since we are using the base class (Loan) constructor, we don't need to put any code here
        }

        public override double Payment(int n)
        {
            return principal * rate / (1 - Math.Pow(1 + rate, -periods));
        }

        public override double Outstanding(int n)
        {
            return principal * Math.Pow(1 + rate, n) - Payment(0) * (Math.Pow(1 + rate, n) - 1) / rate;
        }
        public override double Interest(int n)
        {
            return Outstanding(n - 1) * rate;
        }

        public override double Repayment(int n)
        {
            return Payment(n) - Interest(n);
        }
    }

    public class Amortization
    {
        private Loan loan;
        public Amortization(Loan loan)
        {
            this.loan = loan;
        }

        public void Print()
        {
            Console.WriteLine("Principal: {0, 18:F}", loan.Principal);
            Console.WriteLine("Rate of interest: {0, 10:F}%", loan.Rate * 100);
            Console.WriteLine("Number of periods: {0, 10:D}\n", loan.Periods);
            Console.WriteLine("{0, 7}{1, 15}{2, 15}{3, 15}{4, 15}","Periods", "Payment", "Repayment", "Interest", "Outstanding");
            for (int n = 1; n <= loan.Periods; n++)
            {
                Console.WriteLine("{0, 7:D}{1, 15:F}{2, 15:F}{3, 15:F}{4, 15:F}", n, loan.Payment(n), loan.Repayment(n), loan.Interest(n), loan.Outstanding(n));
            }
        }
    }


}
