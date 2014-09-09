using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPractice_Class4
{
    public class Car
    {
        // Step 1. Declare properties 
        // code snippet: propfull <tab><tab>
        //variable for the Make property
        private string _make; 
        //declare the Make property
        public string Make
        {
            get
            {
                return _make;
            }
            set
            {
                _make = value.ToUpper();
            }
        }

        //shorthand version of a property
        // code snippet: prop <tab><tab>
        public string Model { get; set; }
        
        //Step 2. Declare Constructor
        public Car(string make, string model)
        {
            //set the property Make = the argument make
            this.Make = make;
            this.Model = model;
        }

        public Car()
        {
            this.Model = "undefined";
            this.Make = "undefined";
        }

        //Step 3. Methods and Functions
        public void Honk()
        {
            Console.WriteLine("Beep beep");
            Console.Beep();
            Console.Beep();
        }

        public string GetInfo()
        {
            //returns a string with information about the
            // car
            return this.Make + " " + this.Model;
        }
    }
}
