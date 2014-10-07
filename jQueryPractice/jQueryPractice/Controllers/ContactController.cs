using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryPractice.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.ContactForm cf)
        {
            if (Request.IsAjaxRequest())
            //TODO: code to send an email
            return PartialView("ThankYou");
        }
    }
}
