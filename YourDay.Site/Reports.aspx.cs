using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;
using YourDay.Security;

namespace YourDay.Site
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuSimpleLeft.DataSource = Get
                .EventCardCompanies(MembershipUser.CurrentUser.Id)
                .GroupBy(x => x.SubcategoryId)
                .ToDictionary(
                x => Get.SubCategory(x.Key).Title,
                x => Manager.GetReportWithSubcategoryLink(x.Key)
                );
        }
    }
}