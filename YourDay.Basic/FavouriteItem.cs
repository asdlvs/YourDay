using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class FavouriteItem
    {
        public int Id
        { get; set; }
        public int UserId
        { get; set; }
        public User User
        { get; set; }
        public int Type
        { get; set; }
        public int ItemId
        { get; set; }

        
    }
}
