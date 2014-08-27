using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithLists
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare a new list of strings for a menu
            List<string> myMenu = new List<string>() 
            {"Pizza","Tacos","Hummus","Instant Potatoes"};

            //add one more menu item to our list
            myMenu.Add("Deep-fried Twix");

            //loop through our menu and print each item
            for (int i = 0; i < myMenu.Count; i++)
            {
                Console.WriteLine(myMenu[i]);
            }

            //remove things from a list
            //remove by name
            myMenu.Remove("Pizza");
            //remove by index
            myMenu.RemoveAt(1);

            //Another EASIER way of printing out an array
            Console.WriteLine(string.Join(", ", myMenu));

            //Loop through the List again, to make Twix pop
            for (int i = 0; i < myMenu.Count; i++)
            {
                //set a variable equal to the current item
                // in our list
                string item = myMenu[i];
                //convert the item to lowercase and search
                // it for the word twix
                if (item.ToLower().Contains("s"))
                {
                    //found a twix, make it capitalized
                    Console.WriteLine(item.ToUpper());
                }
                else
                {
                    Console.WriteLine(item);
                }

            }

            //keep the window open
            Console.ReadKey();
        }
    }
}
