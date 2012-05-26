using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class ArticleRate
    {
        public int Id
        { get; set; }
        public int AuthorId
        { get; set; }
        public bool IsPositive
        { get; set; }
        public int ArticleId
        { get; set; }
        public POCO.Article Article
        { get; set; }
        public POCO.User Author
        { get; set; }
    }
}
