using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jQueryPractice.Controllers
{
    public class AjaxGETController : Controller
    {
        //
        // GET: /AjaxGET/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cats()
        {
            if (Request.IsAjaxRequest())
            {
                //you only want to return a partial view with an
                // AJAX GET request
                return PartialView();
            }
            else
            {
                return View();
            }
        }

        public ActionResult Dogs()
        {
            return PartialView();
        }

    }
}
