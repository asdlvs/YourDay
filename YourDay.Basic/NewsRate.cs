using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class NewsRate
    {
        public int Id
        { get; set; }
        public int NewsId
        { get; set; }
        public News News
        { get; set; }
        public bool IsPositive
        { get; set; }
        public int AuthorId
        { get; set; }
        public User Author
        { get; set; }

    }
}
