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
    public class VersionsController : Controller
    {
        private DatabaseProductsEntities db = new DatabaseProductsEntities();

        // GET: Versions
        public ActionResult Index()
        {
            var versionOfProduct = db.VersionOfProduct.Include(v => v.ProductSet);
            return View(versionOfProduct.ToList());
        }

        // GET: Versions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VersionOfProduct versionOfProduct = db.VersionOfProduct.Find(id);
            if (versionOfProduct == null)
            {
                return HttpNotFound();
            }
            return View(versionOfProduct);
        }

        // GET: Versions/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name");
            return View();
        }

        // POST: Versions/Create
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VersionName,ReleaseDate,ProductId")] VersionOfProduct versionOfProduct)
        {
            if (ModelState.IsValid)
            {
                db.VersionOfProduct.Add(versionOfProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name", versionOfProduct.ProductId);
            return View(versionOfProduct);
        }

        // GET: Versions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VersionOfProduct versionOfProduct = db.VersionOfProduct.Find(id);
            if (versionOfProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name", versionOfProduct.ProductId);
            return View(versionOfProduct);
        }

        // POST: Versions/Edit/5
        // Afin de déjouer les attaques par survalidation, activez les propriétés spécifiques auxquelles vous voulez établir une liaison. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VersionName,ReleaseDate,ProductId")] VersionOfProduct versionOfProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(versionOfProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.ProductSet, "Id", "Name", versionOfProduct.ProductId);
            return View(versionOfProduct);
        }

        // GET: Versions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VersionOfProduct versionOfProduct = db.VersionOfProduct.Find(id);
            if (versionOfProduct == null)
            {
                return HttpNotFound();
            }
            return View(versionOfProduct);
        }

        // POST: Versions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VersionOfProduct versionOfProduct = db.VersionOfProduct.Find(id);
            db.VersionOfProduct.Remove(versionOfProduct);
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
