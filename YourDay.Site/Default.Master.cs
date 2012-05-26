using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site
{
    public partial class _Default : System.Web.UI.MasterPage
    {

        protected void Page_Init()
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["reload"]))
            {
                Manager.ClearCache();
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //TODO:В верстке убрать хардкод
            //Ад: при реврайте адреса, action Ломается
            Context.RewritePath(this.Context.Request.RawUrl);
            
        }

     
    }
}