using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Web.UI;
using System.Threading;
using YourDay.Security;
using YourDay.Configuration;

namespace YourDay.Masquaradue
{
    public class MasquaradueModule : IHttpModule
    {
        /// <summary>
        /// You will need to configure this module in the web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        private const string contractorPage = "contractor";
        private const string subcategoryPage = "subcategory";

        public void Dispose()
        {
            //clean-up code here.
        }

        public void Init(HttpApplication context)
        {
                       // context.BeginRequest += new EventHandler(context_BeginRequest);
                        //context.EndRequest += new EventHandler(context_EndRequest);
                        //context.AuthorizeRequest += new EventHandler(context_AuthorizeRequest);
            context.PostAuthenticateRequest += new EventHandler(context_PostAuthenticateRequest);
                        context.PostAcquireRequestState += new EventHandler(context_PostAcquireRequestState);
        }

        //void context_PostAuthenticateRequest(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //void context_AuthorizeRequest(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        //void context_EndRequest(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        

        private bool a = false;
        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            if (a /*&& Membership.GetUser() == null*/)
            {
                HttpContext.Current.Server.Transfer("~/WTF.aspx");
            }
        }

        public static Regex skipRegex = new Regex(@".AXD|CSS|JS|ASYNCFILEUPLOADID|.JPG");
        void context_PostAuthenticateRequest(object sender, EventArgs e)
        {

           

            a = false;
            HttpContext context = HttpContext.Current;
            //TODO: Придумать что-нибудь получше с ?id=5

            string requestUrl = context.Request.RawUrl.Split('?')[0];

            if (skipRegex.IsMatch(requestUrl.ToUpper()))
                return;
            
            //if (HttpContext.Current.Request.HttpMethod != "POST" && !HttpContext.Current.Request.Url.OriginalString.EndsWith("/"))
            //    HttpContext.Current.Response.Redirect(String.Format("{0}/", HttpContext.Current.Request.Url.OriginalString));

            MasquaradueRulesConfigSection rulesCS = (MasquaradueRulesConfigSection)ConfigurationManager.GetSection("masquaradueRules");
            Rules rules = rulesCS.Rules;

            foreach (Rule rule in rules)
            {
                Regex regex = new Regex(rule.Regex, RegexOptions.IgnoreCase);
                
                if (regex.IsMatch(requestUrl))
                {
                    bool accessGranted = false;
                    var currentUser = YourDay.Security.MembershipUser.CurrentUser;
                    if (currentUser != null)
                    {
                        foreach (string role in rule.ActualRoles)
                        {

                            string username = currentUser.Login;
                            YourDay.Security.RoleProvider rp = new Security.RoleProvider();
                            if (rp.IsUserInRole(username, role))
                            {
                                accessGranted = true;
                                break;
                            }
                        }
                    }
                    if (!rule.EnableUnauthorizedAccess && !accessGranted)
                    {
                        a = true;
                        continue;
                    }
                    
                        string rewritePath = Regex.Replace(requestUrl, rule.Regex, rule.Link, RegexOptions.IgnoreCase);
                        context.RewritePath(rewritePath);
                        a = false;
                        break;
                }

            }
        }


        

        #endregion

      
    }
}
