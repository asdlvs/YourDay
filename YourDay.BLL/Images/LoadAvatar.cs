using System;
using System.Web;
using System.IO;
using System.Configuration;

namespace YourDay.BLL.Images
{
    public class LoadAvatar : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {

            string host = ConfigurationManager.AppSettings["Images"];
            string login = System.Web.Security.Membership.GetUser().UserName;
            string folder = context.Server.MapPath(String.Format(@"{0}/{1}/", host, login));
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            string file = String.Format("{0}{1}", folder, "avatar.png");

            HttpFileCollection coll = HttpContext.Current.Request.Files;
            HttpPostedFile postedFile = coll[0];
            BLL.Del.Avatar(login);
            postedFile.SaveAs(file);


        }

        #endregion
    }
}
