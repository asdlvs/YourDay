using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class MediaRate
    {
        public int Id
        { get; set; }

        public int EventCardCompanyMediaId
        { get; set; }

        public int AuthorId
        { get; set; }
        public bool IsPositive
        { get; set; }
        public User Author
        { get; set; }
        public Media Media
        { get; set; }
    }
}
