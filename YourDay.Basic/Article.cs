using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class Article
    {
        public int Id
        { get; set; }
        public string Title
        { get; set; }
        public string Content
        { get; set; }
        public int AuthorId
        { get; set; }
        public POCO.Contractor Author
        { get; set; }
        public string Image
        { get; set; }
        public DateTime DateTime
        { get; set; }
        public ICollection<POCO.ArticleRate> ArticleRates
        { get; set; }
    }
}
