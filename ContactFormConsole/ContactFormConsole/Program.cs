using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactFormConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //ALWAYS FIRST - Create a connection to our database
            DustinEntities db = new DustinEntities();

            
            //Add a new Record to our Contact Form Database
            // Create a new Contact Form Object
            ContactForm add = new ContactForm();
            // Fill out our new object
            add.Name = "Dustin";
            add.Email = "dustin@seedpaths.com";
            add.CompanyName = "SeedPaths";
            add.Comments = "You guys are the tops!";

            //add our object to the database
            db.ContactForms.Add(add);
            //save it
            db.SaveChanges();

            //Retrieve a record from our database
            var contact = db.ContactForms.Find(1);

            //Update the name
            contact.Name = "Billy Joel";

            //save changes
            db.SaveChanges();

            //delete a record from our database
            db.ContactForms.Remove(contact);

            //save the changes
            db.SaveChanges();

        }
    }
}
