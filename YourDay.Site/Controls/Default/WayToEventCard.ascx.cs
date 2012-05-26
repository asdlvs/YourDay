using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.Security;

namespace YourDay.Site.Controls.Default
{
    public partial class WayToEventCard : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (MembershipUser.CurrentUser == null)
            {
                anchorCreateEvent.Attributes.Add("onclick", "showlogin();return false;");
            }
            else
            {
                anchorCreateEvent.Attributes.Add("onclick", "showcreateeventpopup();return false;");
            }
            
        }
    }
}