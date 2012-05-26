using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class Avatar
    {
        public int Id
        { get; set; }
        public int UserId
        { get; set; }
        public User User
        { get; set; }
        public string ImageName
        { get; set; }
        public int Width
        { get; set; }
        public int Height
        { get; set; }
    }
}
