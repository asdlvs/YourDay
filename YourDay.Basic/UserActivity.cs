using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class UserActivity
    {
        public int Id
        { get; set; }
        public int UserId
        { get; set; }
        public int EventStatus
        { get; set; }
        public User User
        { get; set; }
        public DateTime DateTime
        { get; set; }
    }
}
