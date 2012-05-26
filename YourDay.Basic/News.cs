using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class News
    {
        public int Id
        { get; set; }
        public string Title
        { get; set; }
        public string Content
        { get; set; }
        public string Image
        { get; set; }
        public DateTime DateTime
        { get; set; }
        public ICollection<NewsRate> NewsRates
        { get; set; }
    }
}
