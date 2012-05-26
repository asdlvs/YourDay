using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace YourDay.Security
{
    public class MembershipUser : System.Web.Security.MembershipUser
    {
        public MembershipUser(POCO.User user)
        {
            this.userName = user.Login;
            this.providerUserKey = user.Salt;
            this.email = user.EMail;
            this.isApproved = user.IsApproved;
            //TODO: LastActivityDate
            //this.lastActivityDate = user.UserActivities.OrderByDescending(x => x.Id).First().DateTime;
            //this.isOnline = (DateTime.Now - this.lastActivityDate).TotalMinutes < 30;
        }

        private string userName;
        public override string UserName
        {
            get
            {
                return userName;
            }
        }

        private object providerUserKey;
        public override object ProviderUserKey
        {
            get
            {
                return providerUserKey;
            }
        }

        private string email;
        public override string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        private bool isOnline;
        public override bool IsOnline
        {
            get
            {
                return isOnline;
            }
        }

        private DateTime lastActivityDate;
        public override DateTime LastActivityDate
        {
            get
            {
                return lastActivityDate;
            }
            set
            {
                lastActivityDate = value;
            }
        }

        private bool isApproved;
        public override bool IsApproved
        {
            get
            {
                return isApproved;
            }
            set
            {
                isApproved = value;
            }
        }

        public string FirstName
        { get; set; }
        public string LastName
        { get; set; }
        public string AvatarSrc
        { get; set; }

        public static POCO.User CurrentUser
        {
            get
            {
                try
                {
                    //TODO:  Разобраться что за шлак
                    System.Web.Security.MembershipUser mu = System.Web.Security.Membership.GetUser();
                    if (mu != null)
                        return BLL.Manager.GetUser(mu.UserName);
                    else
                        return null;
                }
                catch
                {
                    return null;
                }
            }
        }

        public static void SetAuthCookie(string username, string role)
        {
         FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                            (
                                1, 
                                username, 
                                DateTime.Now, 
                                DateTime.Now.AddDays(30), 
                                true,
                                role,
                                FormsAuthentication.FormsCookiePath
                            );
                        string hash = FormsAuthentication.Encrypt(ticket);
                        HttpCookie cookie = new HttpCookie(
                           FormsAuthentication.FormsCookieName, 
                           hash); 
                        if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                        HttpContext.Current.Response.Cookies.Add(cookie); 
        }
    }
}
