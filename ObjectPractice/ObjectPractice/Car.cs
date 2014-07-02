using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice
{
    class Car
    {
        //Properties - define attributes of an object
        public string Make { get; set; }
        public string Model { get; set; }
        private int Year { get; set; }

        //Constructors come next
        public Car(string make, string model, int year)
        {
            this.Make = make; this.Model = model;
            this.Year = year;
        }
        
        //Default constructor (optional)
        public Car()
        {
            this.Make = "undefined";
            this.Model = "undefined";
        }

        //Functions come after constructors
        public string GetInfo()
        {
            return this.Year + " " + this.Make + " " + this.Model;
        }

        public void Honk()
        {
            Console.WriteLine("Beep beep!");
        }
    }
}
