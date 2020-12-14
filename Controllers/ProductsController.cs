using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWebApplicationTD.Models;

namespace MVCWebApplicationTD.Controllers
{
    public class ProductsController : Controller
    {
        private DatabaseProductsEntities db = new DatabaseProductsEntities();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.ProductSet.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSet productSet = db.ProductSet.Find(id);
            if (productSet == null)
            {
                return HttpNotFound();
            }
            return View(productSet);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Description")] ProductSet productSet)
        {
            if (ModelState.IsValid)
            {
                db.ProductSet.Add(productSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productSet);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSet productSet = db.ProductSet.Find(id);
            if (productSet == null)
            {
                return HttpNotFound();
            }
            return View(productSet);
        }

        // POST: Products/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Description")] ProductSet productSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productSet);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSet productSet = db.ProductSet.Find(id);
            if (productSet == null)
            {
                return HttpNotFound();
            }
            return View(productSet);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSet productSet = db.ProductSet.Find(id);
            db.ProductSet.Remove(productSet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
