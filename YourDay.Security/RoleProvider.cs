using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace YourDay.Security
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {
        public const string NOT_APPROVED = "NotApproved";
        public const string SIMPLE_USER = "SimpleUser";
        public const string CONTRACTOR = "Contractor";

       
        public override string[] GetAllRoles()
        {
            return new string[] { NOT_APPROVED, SIMPLE_USER, CONTRACTOR };
        }

        public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
        {
            base.Initialize(name, config);
        }
        public override string[] GetUsersInRole(string roleName)
        {
            string[] result = null;
            using (SecurityEntities context = new SecurityEntities())
            {
                switch (roleName)
                {

                    case SIMPLE_USER:
                        result = context.Users.OfType<POCO.SimpleUser>().Where(x => x.IsApproved).Select(x => x.Login).ToArray();
                        break;
                    case CONTRACTOR:
                        result = context.Users.OfType<POCO.Contractor>().Select(x => x.Login).ToArray();
                        break;
                    case NOT_APPROVED:
                    default:
                        result = context.Users.OfType<POCO.SimpleUser>().Where(x => !x.IsApproved).Select(x => x.Login).ToArray();
                        break;
                }
            }
            return result;
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            string[] users = GetUsersInRole(roleName);
            return users.Contains(username);
        }

        public override bool RoleExists(string roleName)
        {
            return GetAllRoles().Contains(roleName);
        }


        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
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

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            foreach (string role in GetAllRoles())
            {
                if (IsUserInRole(username, role))
                    return new string[] { role };
            }
            
            return new string[0];
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
    }
}
