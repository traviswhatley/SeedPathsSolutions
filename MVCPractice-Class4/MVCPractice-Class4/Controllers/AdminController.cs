using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPractice_Class4.Controllers
{
    public class AdminController : Controller
    {
        //step 1.  create a connection to our database
        Models.ContactFormEntities db = new Models.ContactFormEntities();


        //
        // GET: /Admin/
        
        public ActionResult Index()
        {
            //list the contents of our contact forms
            return View(db.ContactForms);
        }

        public ActionResult Details(int id)
        {
            return View(db.ContactForms.Find(id));
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.ContactForms.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Models.ContactForm contactForm)
        {
            //tell the DB context that the contact form needs to be
            // updated
            db.Entry(contactForm).State = System.Data.EntityState.Modified;
            //save our changes to the DB
            db.SaveChanges();
            //kick the user back to the list
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult Delete(int id)
        {
            return View(db.ContactForms.Find(id));
        }

        public ActionResult DeleteConfirm(int id)
        {
            //get the form to delete from the database
            Models.ContactForm formToDelete = db.ContactForms.Find(id);
            //set the form to be deleted
            db.ContactForms.Remove(formToDelete);
            //save our changes
            db.SaveChanges();
            //kick them back to the list
            return RedirectToAction("Index", "Admin");
        }

    }
}
