using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YourDay.MvcSite.Controllers.Common
{
    public class TemplateController : Controller
    {
        //
        // GET: /Footer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Footer()
        {
            double i = 0;
            var mapItemsList = BLL.Get.Categories()
               .OrderBy(x => x.Title)
               .GroupBy(x => Math.Floor(++i / 11));

            ViewBag.CategoryLinks = mapItemsList;

            if (YourDay.Security.MembershipUser.CurrentUser != null)
            {
                ViewBag.HeaderLinks = Constants.Strings.ContractorHeaderLinkDictionary;
            }

            ViewBag.AdvLinks = Constants.Strings.BottomProjectLinks;
            return PartialView();
        }

    }
}
