using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor.Preferences
{
    public partial class CI : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            POCO.Contractor u = (POCO.Contractor)YourDay.Security.MembershipUser.CurrentUser;
            TextBoxCity.Text = u.City.Title;
            TextBoxCity.Enabled = false;
            TextBoxFB.Text = u.Facebook;
            TextBoxPhone.Text = u.Phone;
            TextBoxSite.Text = u.Site;
            TextBoxMail.Text = u.EMail;
            TextBoxTwitter.Text = u.Twitter;
            TextBoxVK.Text = u.VK;
        }

        protected void ImageButtonSave_Click(object sender, ImageClickEventArgs e)
        {
            POCO.Contractor u = (POCO.Contractor)YourDay.Security.MembershipUser.CurrentUser;
            u.Facebook = TextBoxFB.Text;
            u.Phone = TextBoxPhone.Text;
            u.Site = TextBoxSite.Text;
            u.EMail = TextBoxMail.Text;
            u.Twitter = TextBoxTwitter.Text;
            u.VK = TextBoxVK.Text;
            BLL.Post.UpdateUser(u);
        }
    }
}