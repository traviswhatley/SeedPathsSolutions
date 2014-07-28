using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Models;
using System.IO; // add System.IO to save/get files

namespace eCommerce.Controllers
{
    //Limit access only to admin users
    [Authorize(Roles = "admin")]
    public class ProductImagesController : BaseController
    {
        private eCommerceEntities db = new eCommerceEntities();

        //
        // GET: /ProductImages/

        public ActionResult Index()
        {
            var images = db.Images.Include(i => i.Product);
            return View(images.ToList());
        }

        //
        // GET: /ProductImages/Details/5

        public ActionResult Details(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // GET: /ProductImages/Create

        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name");
            return View();
        }

        //
        // POST: /ProductImages/Create

        //add the httpPostedFileBase parameter to our post action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Image image, HttpPostedFileBase upload)
        {
            //handle the file upload
            //step 1: Get the filename
            string fileName = upload.FileName;
            //step 2: get the file path to save the
            // upload to
            string path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
            //step 3: Save our uploaded file to the hard drive
            upload.SaveAs(path);
            //step 4: Update the ImageURL for our 
            // database object
            image.ImageURL = "/Content/Images/" + fileName;

            if (ModelState.IsValid)
            {
                db.Images.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", image.ProductID);
            return View(image);
        }

        //
        // GET: /ProductImages/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", image.ProductID);
            return View(image);
        }

        //
        // POST: /ProductImages/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Image image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "Name", image.ProductID);
            return View(image);
        }

        //
        // GET: /ProductImages/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Image image = db.Images.Find(id);
            if (image == null)
            {
                return HttpNotFound();
            }
            return View(image);
        }

        //
        // POST: /ProductImages/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}