using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CartController : BaseController
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View();
        }

        //Get /Cart/MiniCart
        public ActionResult MiniCart()
        {
            //returns a partial view for use in the header.
            return PartialView(this.MyOrder);
        }

        //POST /Cart/Add
        [HttpPost]
        public ActionResult Add(Models.OrderLine ol)
        {
            //see if the product is already present
            // in our cart
            if (this.MyOrder.OrderLines.Where(x => x.ProductID == ol.ProductID).Any())
            {
                //get the order line to update the quantity on
                var cartItem = this.MyOrder.OrderLines.Where(x => x.ProductID == ol.ProductID).First();
                //update the quantity
                cartItem.Quantity = cartItem.Quantity + ol.Quantity;
            }
            else
            {
                //not in cart, add our orderline to our order
                this.MyOrder.OrderLines.Add(ol);
            }
            //save changes
            db.SaveChanges();
            //return the MiniCart View
            return RedirectToAction("MiniCart", "Cart");
        }

    }
}
