using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GitHub()
        {
            ViewBag.Message = "Mine projekter";

            return View();
        }

        public ActionResult Kontakt()
        {
            ViewBag.Message = "Min kontakt side";

            return View();
        }
    }
}