using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using YourDay.POCO;

namespace YourDay.DAL
{
    public class MailEntities : ObjectContext, IDisposable
    {
        public MailEntities()
            : base("name=MailEntities", "MailEntities")
        { }

        public ObjectSet<MailQueue> MailQueue
        { 
            get 
            { 
                return base.CreateObjectSet<MailQueue>("MailQueue"); 
            } 
        }
    }
}
