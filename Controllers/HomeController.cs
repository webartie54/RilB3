using MVCWebApplicationTD.Helpers;
using MVCWebApplicationTD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplicationTD.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseProductsEntities db = new DatabaseProductsEntities();
        public ActionResult Index(int ?id)
        {
            return View(db.ProductSet.ToList());
        }

        public ActionResult About()
        {

            if (Session["lang"] == null)
                Session["lang"] = "fr";
            ViewBag.Message = Translate.TranslateTo("about", Session["lang"].ToString());

           

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}