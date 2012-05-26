using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using YourDay.Security;

namespace YourDay.Site.Handlers
{
    /// <summary>
    /// Summary description for approve
    /// </summary>
    public class approve : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string salt = null;
            if (!String.IsNullOrEmpty(salt = context.Request.QueryString["salt"]))
            {
                MembershipProvider mp = new MembershipProvider();
                mp.UnlockUser(salt);
                MembershipUser.SetAuthCookie(MembershipUser.CurrentUser.Login, RoleProvider.SIMPLE_USER);
            };
            
            context.Response.Redirect(ConfigurationManager.AppSettings["default"]);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}