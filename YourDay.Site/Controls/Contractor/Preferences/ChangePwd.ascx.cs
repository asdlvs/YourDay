using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.Security;

namespace YourDay.Site.Controls.Contractor.Preferences
{
    public partial class ChangePwd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButtonSave_Click(object sender, ImageClickEventArgs e)
        {
            if (Page.IsValid)
            {
                MembershipProvider mp = new MembershipProvider();
                string oldPwd = TextBoxOldPwd.Text;
                string newPwd = TextBoxNewPwd.Text;
                string newRepeatedPwd = TextBoxRepeatNewPwd.Text;
                if (newPwd.Equals(newRepeatedPwd) && Regex.IsMatch(newPwd, "\\S{6,}"))
                    mp.ChangePassword(MembershipUser.CurrentUser.Login, oldPwd, newPwd);
            }

        }
    }
}