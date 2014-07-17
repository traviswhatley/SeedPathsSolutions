using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; // add using for Memberships

namespace MyBlog.Controllers
{
    public class AccountController : Controller
    {
        //add a connection to the myBlog database
        Models.MyBlogEntities db = new Models.MyBlogEntities();

        //
        // GET: /Account/

        public ActionResult Index()
        {
            //To create a user
            Membership.CreateUser("admin", "techIsFun1");

            //To check if the username and password match
            if (Membership.ValidateUser("admin", "techIsFun1"))
            {
                //user/pass is a match, log them in
                FormsAuthentication.SetAuthCookie("admin", false);
            }
            return View();
        }

        // GET: /Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            //creating a blank registration object
            // to pass to our view.
            return View(new Models.Register());
        }

        // POST: /Account/Register
        [HttpPost]
        public ActionResult Register(Models.Register reg)
        {
            //post action receives a Register object
            
            //1. check to see if the username is already in use
            if (Membership.GetUser(reg.Username) == null)
            {
                //username is valid, so add the user to the database
                Membership.CreateUser(reg.Username, reg.Password);
                //add the user to our myBlog authors table
                Models.Author author = new Models.Author();
                //set the properties of our author object
                author.Username = reg.Username;
                author.Name = reg.Name;
                author.ImageURL = reg.ImageURL;
                //add the author to the database.
                db.Authors.Add(author);
                db.SaveChanges();
                //Log the user in
                FormsAuthentication.SetAuthCookie(reg.Username, false);
                //kick the user back to the landing page.
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //username is already in use, send a message 
                //to the view to let the user know
                ViewBag.Error = "Username is already in use, good sir.  Please choose another.";
                //return the view, with the reg object
                return View(reg);
            }
        }

        // GET: /Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            //log out the user
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Models.Login());
        }

        // POST: /Account/Login
        [HttpPost]
        public ActionResult Login(Models.Login log)
        {
            //check to see if the username and password match
            if (Membership.ValidateUser(log.Username, log.Password))
            {
                //its correct, so log them in
                FormsAuthentication.SetAuthCookie(log.Username, false);
                //kick them back to the home page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //not a valid user
                ViewBag.Error = "Username and/or password invalid!";
                //return them to the login page
                return View(log); 
            }
        }
    }
}
