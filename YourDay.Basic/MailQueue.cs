using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class MailQueue
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int MailTypeId { get; set; }
        public MailType MailType { get; set; }
        public bool IsProcessed { get; set; }
    }
}
