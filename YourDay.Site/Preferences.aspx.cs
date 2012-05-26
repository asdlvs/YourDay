using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site
{
    public partial class Preferences : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Threading.Thread.CurrentPrincipal.IsInRole(YourDay.Security.RoleProvider.CONTRACTOR))
            {
                MenuSimpleLeft.DataSource = Constants.Strings.ContractorPreferencesMenuItems;
            }
            else if (System.Threading.Thread.CurrentPrincipal.IsInRole(YourDay.Security.RoleProvider.SIMPLE_USER))
            {
                MenuSimpleLeft.DataSource = Constants.Strings.SimpleUserPreferencesMenuItems;
            }
            string q = null;
            if (!String.IsNullOrEmpty(q = (string)Request.QueryString["type"]))
            {
                PreferencesFormItem.Type = q.ToLower();
            }
        }
    }
}