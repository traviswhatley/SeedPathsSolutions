using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    //Authorize data annotation requires a user to be
    // logged in to access anything in this controller
    [Authorize()]
    public class PostController : Controller
    {
        //make a connection to the database
        Models.MyBlogEntities db = new Models.MyBlogEntities();

        //
        // GET: /Post/
        public ActionResult Index()
        {
            // the index will return all of the
            // user's posts
            return View(db.Posts.Where(x => x.Username.ToLower() == User.Identity.Name.ToLower()));
        }

        // GET: /Post/Create
        [HttpGet]
        public ActionResult Create()
        {
            //pass a blank post object to the view
            return View(new Models.Post());
        }

        //POST: /Post/Create
        [HttpPost]
        public ActionResult Create(Models.Post post)
        {
            //set the username on the post object
            post.Username = User.Identity.Name;
            //set the date create to be NOW
            post.DateCreated = DateTime.Now;
            //set the likes to 0
            post.Likes = 0;

            //make sure that imageURL has a value
            if (post.ImageURL == null)
            {
                post.ImageURL = "";
            }

            //add it to the database
            db.Posts.Add(post);
            //save our changes
            db.SaveChanges();
            //kick user back to their list of posts
            return RedirectToAction("Index", "Post");

        }

    }
}
