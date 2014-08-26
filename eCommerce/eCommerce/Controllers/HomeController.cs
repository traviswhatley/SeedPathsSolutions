using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eCommerce.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index()
        {
            //display all products on the landing page
            return View(db.Products.OrderByDescending(x => x.UnitPrice));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //GET: /Home/Navigation
        public ActionResult Navigation()
        {
            //return a partial view for our root (parentless) categories
            return PartialView(db.Categories.Where(x => x.ParentID == null));
        }

    }
}
