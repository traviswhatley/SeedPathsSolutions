using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        //set up a connection to the database
        Models.MyBlogEntities db = new Models.MyBlogEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            //Pass all the posts to the view, order by
            // newest first.
            return View(db.Posts.OrderByDescending(x=>x.DateCreated));
        }

        // GET: /Home/Like/id
        public ActionResult Like(int id)
        {
            //go to the database and retrieve the post
            // that matches the id
            Models.Post post = db.Posts.Find(id);
            //add 1 to the post likes
            post.Likes = post.Likes + 1;
            //save that changes to the database
            db.SaveChanges();
            //return the the number of likes
            return Content(post.Likes + " likes");
        }

        //AJAX POST: /Home/addComment
        public ActionResult addComment(Models.Comment c)
        {
            //set the Date Created property of the comment
            c.DateCreated = DateTime.Now;
            //add it to the database
            db.Comments.Add(c);
            //save the changes
            db.SaveChanges();
            //return the comment view
            return PartialView("comment", c);
        }

    }
}
