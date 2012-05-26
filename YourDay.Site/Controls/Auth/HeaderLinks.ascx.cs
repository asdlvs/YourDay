using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using YourDay.BLL;

namespace YourDay.Site.Controls.Auth
{
    public partial class HeaderLinks : System.Web.UI.UserControl
    {
        public POCO.User User
        { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (this.User != null ||
                (this.User = YourDay.Security.MembershipUser.CurrentUser) != null)
            {
              
                if (System.Threading.Thread.CurrentPrincipal.IsInRole(YourDay.Security.RoleProvider.CONTRACTOR))
                {
                    Repeater RepeaterLinks = LoginViewHeaderLinks.DeepFindControl<Repeater>("RepeaterLinks");
                    HtmlImage userimg = LoginViewHeaderLinks.DeepFindControl<HtmlImage>("userimg");
                    Label LabelUserName = LoginViewHeaderLinks.DeepFindControl<Label>("LabelUserName");

                    RepeaterLinks.DataSource = Constants.Strings.ContractorHeaderLinkDictionary.Select(x => new { Text = x.Key, Url = x.Value });
                    RepeaterLinks.DataBind();
                    userimg.Src = this.User.GetAvatarImage(52);//.AvatarSrc;
                    LabelUserName.Text = UIManager.IsEmpty(((POCO.User)User).FullName, ((POCO.User)User).Login);
                }
                else if (System.Threading.Thread.CurrentPrincipal.IsInRole(YourDay.Security.RoleProvider.SIMPLE_USER))
                {
                    Repeater RepeaterLinks = LoginViewHeaderLinks.DeepFindControl<Repeater>("RepeaterLinks");
                    HtmlImage userimg = LoginViewHeaderLinks.DeepFindControl<HtmlImage>("userimg");
                    Label LabelUserName = LoginViewHeaderLinks.DeepFindControl<Label>("LabelUserName");

                    RepeaterLinks.DataSource = Constants.Strings.SimpleUserHeaderLinkDictionary.Select(x => new { Text = x.Key, Url = x.Value });
                    RepeaterLinks.DataBind();
                    userimg.Src = this.User.GetAvatarImage(52);//.AvatarSrc;
                    LabelUserName.Text = UIManager.IsEmpty(((POCO.User)User).FullName, ((POCO.User)User).Login);
                }
                else if (System.Threading.Thread.CurrentPrincipal.IsInRole(YourDay.Security.RoleProvider.NOT_APPROVED))
                {
                    Label LabelNotApprovedText = LoginViewHeaderLinks.DeepFindControl<Label>("LabelNotApprovedText");
                    LabelNotApprovedText.Text = String.Format(YourDay.Constants.Strings.NotApprovedText, "sendApproveMail();");
                }
                //else if (User.GetType() == typeof(POCO.SimpleUser))
                //{ }
            }

        }
    }
}