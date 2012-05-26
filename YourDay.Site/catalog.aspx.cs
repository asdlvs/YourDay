using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.POCO;
using YourDay.BLL;

namespace YourDay.Site
{
    public partial class Catalog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int subcategoryId;
            string subcategoryIdS;
            if (!String.IsNullOrEmpty(subcategoryIdS = Request.QueryString["subcategory"]) && Int32.TryParse(subcategoryIdS, out subcategoryId))
            {
                ContractorList1.SubCategoryId = subcategoryId;
            }
        }
    }
}