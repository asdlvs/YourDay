using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourDay.Constants;
using YourDay.DAL;

namespace YourDay.BLL
{
    public class Mail
    {
        public static void Send(POCO.User user, Enums.MailType mailType)
        {
            using (MailEntities context = new MailEntities())
            {
                POCO.MailQueue el = new POCO.MailQueue();
                el.MailTypeId = (int)mailType;
                el.UserId = user.Id;
                context.MailQueue.AddObject(el);
                context.SaveChanges();
            }
        }
    }

}
