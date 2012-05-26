using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace YourDay.Site.Controls.Contractor.Preferences
{
    public partial class Private : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            POCO.User u = YourDay.Security.MembershipUser.CurrentUser;
            TextBoxName.Text = u.FirstName;
            TextBoxSurname.Text = u.LastName;
            
        }

       

        protected void ImageButtonSave_Click(object sender, ImageClickEventArgs e)
        {
            POCO.User u = YourDay.Security.MembershipUser.CurrentUser;
            u.FirstName = TextBoxName.Text;
            u.LastName = TextBoxSurname.Text;
            BLL.Post.UpdateUser(u);
        }

       

       
    }
}