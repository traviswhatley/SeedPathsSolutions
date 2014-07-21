using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Week5CodeChallenge.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [HttpGet]
        public ActionResult Index()
        {
            //making a contact page, 
            // requires a contactForm object
            return View(new Models.ContactForm());
        }

        //POST: /Contact
        [HttpPost]
        public ActionResult Index(Models.ContactForm cf)
        {
            //establish a connection to the database
            var db = new Models.ContactFormEntities();
            //add our contact form to the database
            db.ContactForms.Add(cf);
            //save the changes to the database
            db.SaveChanges();
            //kick the user to the thank you page
            return RedirectToAction("ThankYou");
        }

        //GET: Contact/ThankYou
        public ActionResult ThankYou() {
            //Returning a static view, 
            // no object required.
            return View();
        }
    }
}
