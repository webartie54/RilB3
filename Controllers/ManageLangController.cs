using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWebApplicationTD.Controllers
{
    public class ManageLangController : Controller
    {
        // GET: ManageLang
        public ActionResult Index(string lang)
        {
            Session["lang"] = lang;
            return Redirect("~/home");
        }
    }
}