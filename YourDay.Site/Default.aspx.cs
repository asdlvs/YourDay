using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace YourDay.Site
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CategoriesMenuSimpleItem.DataSource = BLL.Get.Categories().ToDictionary(x => x.Title, x => BLL.Manager.GetCategoryLink(x.Id));
        }
    }
}