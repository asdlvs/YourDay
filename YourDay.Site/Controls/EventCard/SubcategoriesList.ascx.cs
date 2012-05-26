using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.EventCard
{
    public partial class SubcategoriesList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataListSubcategories.DataSource = BLL.Get.SubCategories()
                .OrderBy(x => x.Title)
                .Select(x => new { Text = x.Title, Value = x.Id });
            DataListSubcategories.DataBind();
        }
    }
}