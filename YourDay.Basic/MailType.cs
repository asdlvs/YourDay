using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class MailType
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        public ICollection<MailQueue> MailQueue { get; set; }
    }
}
