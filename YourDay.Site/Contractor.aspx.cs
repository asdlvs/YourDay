using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site
{
    public partial class Contractor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string contractor = Request.QueryString["contractor"];
            string subcategory = Request.QueryString["subcategory"];
            int contractorId, subcategoryId;
            if (
                !String.IsNullOrEmpty(contractor) &&
                !String.IsNullOrEmpty(subcategory) &&
                Int32.TryParse(contractor, out contractorId) &&
                Int32.TryParse(subcategory, out subcategoryId)
                )
            {
                ContractorCurrent.CurrentContractor = BLL.Get.Contractor(contractorId);
                ContractorCurrent.SubcategoryId = subcategoryId;
            }
        }
    }
}