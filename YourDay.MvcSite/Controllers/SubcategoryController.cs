using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YourDay.MvcSite.Controllers
{
    public class SubcategoryController : Controller
    {
        //
        // GET: /Subcategory/

        
       
        int takenCount = 0;
        int countOnRequest = 10;

        public ActionResult Index(int id)
        {
            if(BLL.Get.SubCategory(id) == null)
                return null;

            var contractorGroups = BLL.Get.ContractorsGroupByPlateSize(id);


           


            return View();
        }

        [HttpGet]
        public JsonResult MoreContractors()
        {
            return View();
        }

    }
}
