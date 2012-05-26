using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.BLL
{
    public static class Admin
    {
        //TODO: Сделать чтобы бралось из админки
        
        private static int defaultSubcategory = 51;
        public static int DefaultSubcategoryForTopSix()
        {
            return defaultSubcategory;
        }

        private static int defaultEventCard = 1;
        public static int DefaultEventCardForMainPhotoes()
        {
            return defaultEventCard;
        }

       
     }
}
