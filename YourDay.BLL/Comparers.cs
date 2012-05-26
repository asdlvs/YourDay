using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourDay.POCO;

namespace YourDay.BLL
{
    public class Comparers
    {
        public class EventCardCompanyComparer : IEqualityComparer<POCO.EventCardCompany>
        {
            public EventCardCompanyComparer()
            { 
            
            }

            public bool Equals(POCO.EventCardCompany x, POCO.EventCardCompany y)
            {
                return x.ContractorId == y.ContractorId && x.EventCardId == y.EventCardId && x.SubcategoryId == y.SubcategoryId;
            }

            public int GetHashCode(POCO.EventCardCompany obj)
            {
                return (new int[] { obj.SubcategoryId, obj.EventCardId, obj.ContractorId }).GetHashCode();
            }
        }

        public class EventCardCategoryComparer : IEqualityComparer<POCO.EventCardCategory>
        {
            public EventCardCategoryComparer()
            { }


            public bool Equals(EventCardCategory x, EventCardCategory y)
            {
                return x.SubcategoryId == y.SubcategoryId && x.EventCardId == y.EventCardId;
            }

            public int GetHashCode(EventCardCategory obj)
            {
                return 0;
            }
        }

        public class ContractorsComparer : IEqualityComparer<POCO.Contractor>
        {
            public ContractorsComparer()
            { }
            public int GetHashCode(Contractor obj)
            {
                return 0;
            }
            public bool Equals(Contractor x, Contractor y)
            {
                return x.Login == y.Login;
            }

        }

        public class EventCardComparer : IEqualityComparer<POCO.EventCard>
        {
            public EventCardComparer()
            { }
            public int GetHashCode(EventCard obj)
            {
                return 0;
            }
            public bool Equals(EventCard x, EventCard y)
            {
                return x.Id == y.Id;
            }

        }

        public class SimpleUsersComparer : IEqualityComparer<POCO.SimpleUser>
        {
            public SimpleUsersComparer()
            { }

            public int GetHashCode(SimpleUser obj)
            {
                return 0;
            }
            public bool Equals(SimpleUser x, SimpleUser y)
            {
                return x.Login == y.Login;
            }
        }

        public class FavouriteItemsComparer : IEqualityComparer<POCO.FavouriteItem>
        {
            public FavouriteItemsComparer()
            { }

            public int GetHashCode(FavouriteItem obj)
            {
                return 0;
            }
            public bool Equals(FavouriteItem x, FavouriteItem y)
            {
                return x.Id == y.Id;
            }
        }
    }
}
