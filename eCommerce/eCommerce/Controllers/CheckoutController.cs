using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        //GET /Checkout/ShippingAddress
        [HttpGet]
        public ActionResult ShippingAddress()
        {
            return View(this.MyOrder.ShippingAddress);
        }

        // POST: /Checkout/ShippingAddress
        [HttpPost]
        public ActionResult ShippingAddress(Models.Address address)
        {
            //OLD WAY:
            //add the address to the database
            //db.Addresses.Add(address);
            //save changes
            //db.SaveChanges();
            //update the order with the shippingaddressID
            //this.MyOrder.ShippingAddressID = address.AddressID;
            //db.SaveChanges();

            //NEW WAY: set the order shipping address to our 
            // new object and save
            this.MyOrder.ShippingAddress = address;
            db.SaveChanges();

            return RedirectToAction("BillingAddress");
        }

        //GET: /Checkout/BillingAddress
        [HttpGet]
        public ActionResult BillingAddress()
        {
            return View(this.MyOrder.BillingAddress);
        }

        //POST: /checkout/billingaddress
        [HttpPost]
        public ActionResult BillingAddress(Models.Address address)
        {
            //set the billing address for the order to be this address
            this.MyOrder.BillingAddress = address;
            //save changes
            db.SaveChanges();
            return RedirectToAction("Payment");
        }

        //GET /checkout/payment
        [HttpGet]
        public ActionResult Payment()
        {
            return View(this.MyOrder.Payment);
        }

        //POST /checkout/payment
        [HttpPost]
        public ActionResult Payment(Models.Payment payment)
        {
            //set the order payment to be our payment object.
            this.MyOrder.Payment = payment;
            //save changes
            db.SaveChanges();
            
            //kick user to the review screen
            return RedirectToAction("Review");

        }

        //GET /checkout/review
        [HttpGet]
        public ActionResult Review()
        {
            return View(this.MyOrder);
        }


        //public ActionResult CreditCardTest()
        //{
        //    //whats sends our transaction request, pass in our api information
        //    Gateway target = new Gateway("9y7a2UJ94yy9", "9g36b6A8S8675JzD", true);
        //    //creating an authorization request, passing in credit card data
        //    IGatewayRequest request = new AuthorizationRequest("5424000000000015", "0224", (decimal)20.10, "AuthCap transaction approved testing", true);
        //    //add the address
        //    request.Address = "123 main st. apt 2 denver co 80203";
        //    //description
        //    string description = "Test Transaction for order #: XXXXXX";
        //    IGatewayResponse response = target.Send(request, description);

        //    //the response is now populated. 
        //    return Content(response.Approved);
        //}

    }
}
