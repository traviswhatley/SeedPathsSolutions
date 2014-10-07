using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO; //import namespace for using Path
using System.Web.Security; // import namespace for using Memberships

namespace MyBlog_Class4.Controllers
{
    public class AccountController : Controller
    {
        //set up my data context
        Models.BlogEntities db = new Models.BlogEntities();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        //step 3. add a httpPostedFileBase parameter
        [HttpPost]
        public ActionResult Register(Models.Registration registration, HttpPostedFileBase Image)
        {
            if (Image != null)
            {
                //save the image to our website
                //GUID generates random characters, that we
                // can use to make sure the file name is not
                // repeated
                string filename = Guid.NewGuid().ToString().Substring(0, 6) + Image.FileName;
                //specify the path to save the file to.
                // Server.MapPath actually gets the physical
                //  location of the website on the server
                string path = Path.Combine(Server.MapPath("~/content/"), filename);
                // SAVE the file
                Image.SaveAs(path);
                //update our registration object, with the Image
                registration.Image = "/content/" + filename;
            }
            //create our Membership user
            Membership.CreateUser(registration.Username, registration.Password);
            //create and populate our Author object
            Models.Author author = new Models.Author();
            author.Name = registration.Name;
            author.ImageUrl = registration.Image;
            author.Username = registration.Username;
            //add the author to the database
            db.Authors.Add(author);
            db.SaveChanges();
            
            //registration complete!  Log in the user
            FormsAuthentication.SetAuthCookie(registration.Username, false);

            //kick the user to the create post section
            return RedirectToAction("Index", "Post");
        }

        public ActionResult Logout()
        {
            //to log out a user do this
            FormsAuthentication.SignOut();
            //kick the user to the login screen
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Login login)
        {
            //see if they are a valid user
            if (Membership.ValidateUser(login.Username, login.Password))
            {
                //credentials are gold, log them in
                FormsAuthentication.SetAuthCookie(login.Username, false);
                //kick the user to the create post page
                return RedirectToAction("Index", "Post");
            }
            else
            {
                //bad news bears, bad password or username
                ViewBag.ErrorMessage = "Invalid username and/or password!";
                return View(login);
            }
        }

    }
}
