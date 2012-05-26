using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor.Preferences
{
    public partial class PreferencesForm : System.Web.UI.UserControl
    {
        public string Type
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //TODO: ХК
            switch (this.Type)
            { 
                case "private":
                    Private p = (Private)LoadControl("~/Controls/Contractor/Preferences/Private.ascx");
                    PlaceHolderMiddle.Controls.Add(p);
                    break;
                case "ci":
                    CI ci = (CI)LoadControl("~/Controls/Contractor/Preferences/CI.ascx");
                    PlaceHolderMiddle.Controls.Add(ci);
                    break;
                case "actdesc":
                    Activities a = (Activities)LoadControl("~/Controls/Contractor/Preferences/Activities.ascx");
                    PlaceHolderMiddle.Controls.Add(a);
                    break;
                case "pwd":
                    ChangePwd ch = (ChangePwd)LoadControl("~/Controls/Contractor/Preferences/ChangePwd.ascx");
                    PlaceHolderMiddle.Controls.Add(ch);
                    break;
                case "img":
                    AvatarLoader al = (AvatarLoader)LoadControl("~/Controls/Contractor/Preferences/AvatarLoader.ascx");
                    PlaceHolderMiddle.Controls.Add(al);
                    break;

            }
        }
    }
}