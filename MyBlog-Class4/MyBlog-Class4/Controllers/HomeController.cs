using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog_Class4.Controllers
{
    public class HomeController : Controller
    {
        //set up the data context for the home controller class
        Models.BlogEntities db = new Models.BlogEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(x=> x.DateCreated));
        }

        public ActionResult AddComment(Models.Comment commentToAdd)
        {
            //make sure the comment is fully filled out
            commentToAdd.DateCreated = DateTime.Now;

            //add the comment to the database
            db.Comments.Add(commentToAdd);
            db.SaveChanges();

            ////for now, until we ajax it, we will kick the user back
            //// to the index
            //return RedirectToAction("Index", "Home");

            //ajax'd the POST method, so we will return 
            // a partial view instead.  we must pass in
            // the comment object that we just added
            return PartialView("Comment", commentToAdd);
        }

        public ActionResult LikePost(int id)
        {
            //get the post from the database that 
            // matches the id
            Models.Post thePostToLike = db.Posts.Find(id);
            //increment the likes by 1
            thePostToLike.Likes++;
            //save the changes to the database
            db.SaveChanges();
            //we need to return the number of likes
            return Content(thePostToLike.Likes + " likes");
        }

    }
}
