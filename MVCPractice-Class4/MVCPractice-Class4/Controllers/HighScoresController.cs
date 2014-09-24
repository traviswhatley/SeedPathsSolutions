using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//bring in the objects
using MVCPractice_Class4.Models;

namespace MVCPractice_Class4.Controllers
{
    public class HighScoresController : Controller
    {
        //
        // GET: /HighScores/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GuessThatNumber()
        {
            //set up a connection to the database
            HighScoresEntities db = new HighScoresEntities();
            //pass the list of high scores for GTN to
            // the view
            return View(db.HighScores.Where(x=> x.Game == "Guess That Number").OrderBy(x=> x.Score));
        }

    }
}
