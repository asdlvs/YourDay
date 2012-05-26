using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using YourDay.POCO;

namespace YourDay.Security
{
    public partial class SecurityEntities : ObjectContext, IDisposable
    {
        public SecurityEntities()
            : base("name=SecurityEntities", "SecurityEntities")
        {
        }
        public ObjectSet<User> Users
        {
            get { return base.CreateObjectSet<User>("Users"); }
        }

    }

    
}
