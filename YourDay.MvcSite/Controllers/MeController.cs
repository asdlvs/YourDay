using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YourDay.MvcSite.Controllers
{
    public class MeController : Controller
    {
        //
        // GET: /Me/

        public ActionResult Index()
        {
            return RedirectToActionPermanent("Events");
        }

        public ActionResult Events()
        {
            return View();
        }

        public ActionResult Messages()
        {
            return View();
        }

        public ActionResult Favourites()
        {
            return View();
        }

        public ActionResult Preferences()
        {
            return View();
        }

    }
}
