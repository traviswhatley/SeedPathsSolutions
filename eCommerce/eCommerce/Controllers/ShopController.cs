using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class ShopController : BaseController
    {
        //
        // GET: /Shop/ByProduct/{id}
        [HttpGet]
        public ActionResult ByProduct(int id)
        {
            return View(db.Products.Find(id));
        }

        //POST /Shop/Search
        [HttpPost]
        public ActionResult Search(string search)
        {
            ViewBag.Search = search;
            return View(db.SearchProductsByName(search));
        }

        //GET /Shop/ByCategory/{id}
        [HttpGet]
        public ActionResult ByCategory(int id)
        {
            //get the category based on the id in the arguments
            Models.Category cat = db.Categories.Find(id);
            //pass the name of the category to the view
            ViewBag.CategoryName = cat.Name;
            //return the view with the products of the category
            return View(db.GetAllProductsByCategoryID(id));
        }
        
    }
}
