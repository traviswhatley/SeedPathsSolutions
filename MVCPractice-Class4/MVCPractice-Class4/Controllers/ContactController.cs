using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace MVCPractice_Class4.Controllers
{
    
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Models.ContactForm());
        }

        //[HttpPost]
        //public ActionResult Index(Models.ContactForm contactForm)
        //{
        //    //create a connection to the database
        //    Models.ContactFormEntities db = new Models.ContactFormEntities();
        //    //add our contact info to the database
        //    db.ContactForms.Add(contactForm);
        //    //save the changes
        //    db.SaveChanges();
        //    //kick the user to the thank you page
        //    return RedirectToAction("ThankYou", "Contact");
        //}

        //new contact form post to send me an 
        // email with the info
        [HttpPost]
        public ActionResult Index(Models.ContactForm contactForm)
        {
           //sending an email
           //step 1.  add using System.Net.Mail;
            //step 2. create a new message, first param
            //  is who its from, second is who its to.
            MailMessage message = new MailMessage("theRobots@seedpaths.com", "dustin@seedpaths.com");
            //step 3.  Set the subject
            message.Subject = "Contact Request from " + contactForm.Name;
            //step 4.  Construct the body with a stringBuilder
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("You have a new contact request.");
            sb.AppendLine("Name: " + contactForm.Name);
            sb.AppendLine("Email: " + contactForm.Email);
            sb.AppendLine("Message: " + contactForm.Message);
            sb.AppendLine("I love you,");
            sb.AppendLine("The Robots");
            //step 5.  Add the body to the message
            message.Body = sb.ToString();

            //step 6.  Declare the SMTP client
            //          aka. the mail server
            SmtpClient smtpClient = new SmtpClient("mail.dustinkraft.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential("postmaster@dustinkraft.com", "techIsFun1");
            //step 7. Send the message
            smtpClient.Send(message);
            //done.
            //kick the user to the ThankYou page
            return RedirectToAction("ThankYou", "Contact");    
        }



        public ActionResult ThankYou()
        {
            return View();
        }

    }
}
