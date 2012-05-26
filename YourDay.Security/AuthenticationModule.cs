using System;
using System.Web;
using System.Web.Security;

namespace YourDay.Security
{
    public class AuthenticationModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
            // Below is an example of how you can handle LogRequest event and provide 
            // custom logging implementation for it
            context.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        string value = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Value;
                        if (!String.IsNullOrEmpty(value))
                        {
                            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(value);

                            string user = ticket.Name;

                            if (!String.IsNullOrEmpty(user))
                            {
                                System.Security.Principal.IIdentity identity = new FormsIdentity(ticket);
                                System.Threading.Thread.CurrentPrincipal =
                                    new System.Security.Principal.GenericPrincipal(identity, new string[] { ticket.UserData });
                            }
                        }
                    }
                    catch
                    {
                        HttpContext.Current.Response.Cookies.Clear();
                    }
                }
            }
            else
            {
                throw new HttpException("Cookieless Forms Authentication is not " +
                                        "supported for this application.");
            }

        }

        #endregion

       
    }
}
