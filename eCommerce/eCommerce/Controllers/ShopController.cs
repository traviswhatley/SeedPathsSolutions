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

        
    }
}
