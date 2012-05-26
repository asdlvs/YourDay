using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class Comment
    {
        public int Id
        { get; set; }
        public int AuthorId
        { get; set; }
        public POCO.User Author
        { get; set; }
        public int ReceiverId
        { get; set; }
        public POCO.User Receiver
        { get; set; }
        public DateTime DateTime
        { get; set; }
        public string Text
        { get; set; }
        public int Type
        { get; set; }
        public int RelationId
        { get; set; }
        public bool AlreadyRead
        { get; set; }

    }
}
