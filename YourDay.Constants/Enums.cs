using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.Constants
{
    public static class Enums
    {
        public enum ContractorStatus
        { 
            Online = 1,
            Offline = 2
        }

        public enum Shifts
        { 
            Morning = 0,
            Day = 1,
            Night = 2
        }
        
        [Flags]
        public enum EventCardCompanyStatus
        { 
            Order = 1,
            Payed = 2,
            UserCancel = 4,
            ContractorCancel = 8,
            Offer = 16
        }

        [Flags]
        public enum CommentsType
        { 
            PrivateMessageToContractorFromSimpleUser = 1,
            PrivateMessageFromContractorToSimpleUser = 2,
            In = 1,
            Out = 2,
            All = 3

        }

        public enum CommentFilter
        { 
            Item = 1,
            Opponent = 2,
            Date = 3
        }

        public enum EventCardCategoryStatus
        { 
            New = 1,
            Offered = 2,
            Close = 3

        }

        public enum MediaType
        {
            Photo = 1,
            Video = 2
        }

        public enum MailType
        { 
            ApproveRegistration = 1,
            ChangePassword = 2
        }

        public enum FavouriteType
        { 
            Contractor = 1,
            EventCard = 2,
            Article = 3
        }
    }
}
