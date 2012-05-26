using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using YourDay.Constants;
using YourDay.POCO;
using YourDay.Security;

namespace YourDay.MailService
{
    public class MailProcesser
    {
        public static string GetActualMail(MailQueue mail)
        {
            string result = mail.MailType.Text;
            switch (mail.MailTypeId)
            {
                case (int)Enums.MailType.ApproveRegistration:
                    result = GetApproveRegistrationMail(mail);
                    break;
                default:
                    result = GetNewPasswordMail(mail);
                    break;
            }
            return result;
        }

        private static string GetApproveRegistrationMail(MailQueue mail)
        {
            string html = mail.MailType.Text;
            string aLink = String.Format(ConfigurationManager.AppSettings["approveRegistrationUrl"], mail.User.Salt);
            string result = String.Format(html, aLink);
            return result;
        }

        public static string GetNewPasswordMail(MailQueue mail)
        {
            string html = mail.MailType.Text;
            YourDay.Security.MembershipProvider mp = new YourDay.Security.MembershipProvider();
            string newPwd = mp.ResetPassword(mail.User.Login, null);
            string result = String.Format(html, newPwd);
            return result;
        }
    }
}
