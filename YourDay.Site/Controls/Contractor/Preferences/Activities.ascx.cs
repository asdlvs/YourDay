using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor.Preferences
{
    public partial class Activities : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            POCO.Contractor u = (POCO.Contractor)YourDay.Security.MembershipUser.CurrentUser;
            TextBoxAdditional.Text = u.Additional;
            TextBoxDescription.Text = u.Description;
        }

        protected void ImageButtonSave_Click(object sender, ImageClickEventArgs e)
        {
            POCO.Contractor u = (POCO.Contractor)YourDay.Security.MembershipUser.CurrentUser;
            u.Description = TextBoxDescription.Text;
            u.Additional = TextBoxAdditional.Text;
            BLL.Post.UpdateUser(u);
        }
    }
}