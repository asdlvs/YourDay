using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Collections.ObjectModel;
using System.Transactions;
using System.Security.Cryptography;
using System.Web;

namespace YourDay.Security
{
    public class MembershipProvider : System.Web.Security.MembershipProvider
    {
        public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            using (SecurityEntities context = new SecurityEntities())
                {
                    if (context.Users.Any(x => x.Login.Equals(username)))
                    {
                        status = MembershipCreateStatus.DuplicateUserName;
                    }

                    POCO.SimpleUser user = new POCO.SimpleUser();
                    user.Login = username;
                    user.EMail = email;
                    user.Password = HashPassword(password);//new byte[0];
                    user.Salt = Guid.NewGuid();
                    user.UserActivities = new Collection<POCO.UserActivity>();
                    POCO.UserActivity activityItem = new POCO.UserActivity();
                    activityItem.DateTime = DateTime.Now;
                    user.UserActivities.Add(activityItem);
                    BLL.Post.SimpleUser(user);
                    BLL.Mail.Send(user, YourDay.Constants.Enums.MailType.ApproveRegistration);
                    status = MembershipCreateStatus.Success;
                    return new MembershipUser(user);
                }
        }

        public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                MembershipUser mu = new MembershipUser(context.Users.FirstOrDefault(x => x.Salt == (Guid)providerUserKey));
                return mu.IsOnline == userIsOnline ? mu : null;
            }
        }

        public override System.Web.Security.MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (String.IsNullOrEmpty(username))
                return null;
            using (SecurityEntities context = new SecurityEntities())
            {
                MembershipUser mu = new MembershipUser(context.Users.Include("UserActivities").FirstOrDefault(x => x.Login.Equals(username)));
                return mu;
                //TODO: разобраться с этой шляпой
                //return mu.IsOnline == userIsOnline ? mu : null;
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                
                var user = context.Users.FirstOrDefault(x => x.Login.Equals(username));
                if (user != null)
                {
                    byte[] pwdHash = HashPassword(password);
                    bool result = pwdHash.SequenceEqual<byte>(user.Password);
                    //if (result)
                    //{
                    //    RoleProvider rp = new RoleProvider();
                    //    string role = rp.GetRolesForUser(username).First();
                    //    MembershipUser.SetAuthCookie(username, role);
                    //    //FormsAuthentication.SetAuthCookie(username, true);
                    //}
                    return result;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void UpdateUser(System.Web.Security.MembershipUser user)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                YourDay.Security.MembershipUser ydUser = (YourDay.Security.MembershipUser)user;
                var pocoUser = context.Users.Single(x => x.Login.Equals(ydUser.UserName));
                pocoUser.LastName = ydUser.LastName;
                pocoUser.FirstName = ydUser.FirstName;
                pocoUser.AvatarSrc = ydUser.AvatarSrc;
                context.SaveChanges();
            }
        }

        public override bool UnlockUser(string salt)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Salt.Equals(new Guid(salt)));
                if (user != null)
                {
                    user.IsApproved = true;
                    context.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
        }

        public byte[] HashPassword(string password)
        {
            byte[] pwdBytes = Encoding.Unicode.GetBytes(password);
            MD5CryptoServiceProvider csp = new MD5CryptoServiceProvider();
            byte[] result = csp.ComputeHash(pwdBytes, 0, pwdBytes.Length);

            return result;
        }

        protected override byte[] EncryptPassword(byte[] password)
        {
            return base.EncryptPassword(password);
        }

        protected override byte[] DecryptPassword(byte[] encodedPassword)
        {
            return base.DecryptPassword(encodedPassword);
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                var user = context.Users.FirstOrDefault(x => x.Login.Equals(username));
                if (user != null)
                {
                    context.Users.DeleteObject(user);
                    return true;
                }
                else
                    return false;
            }
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                var user = context.Users.Single(x => x.Login.Equals(username));
                if (user.Password.SequenceEqual(HashPassword(oldPassword)))
                {
                    user.Password = HashPassword(newPassword);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;//base.ChangePassword(username, oldPassword, newPassword);
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            using (SecurityEntities context = new SecurityEntities())
            {
                var user = context.Users.Single(x => x.Login.Equals(username));
                Guid guid = Guid.NewGuid();
                string pwd = guid.ToString().Replace("-", "").Substring(0, 8);
                user.Password = HashPassword(pwd);
                context.SaveChanges();
                return pwd;
            }
        }
    }
}
