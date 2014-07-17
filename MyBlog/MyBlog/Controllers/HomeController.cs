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

    }
}
