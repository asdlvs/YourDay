using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using YourDay.DAL;
using System.Web;
using YourDay.POCO;
using System.Collections;
using System.Web.UI;
using YourDay.Constants;
using System.Data.Objects;


namespace YourDay.BLL
{
    public class Get
    {

        #region lockers
        private static object contractorsLocker = new object();
        private static object simpleUsersLocker = new object();
        private static object categoriesLocker = new object();
        private static object eventcardLocker = new object();
        private static object eventcardCompanyLocker = new object();
        private static object articleLocker = new object();
        private static object newsLocker = new object();
        private static object eventcardTypesLocker = new object();
        private static object commentLocker = new object();
        private static object mediaLocker = new object();
        private static object favouriteItemsLocker = new object();
        #endregion

        #region Common
        private static T[] GetItems<T, Y>(string name, ref object locker, Func<List<Y>, IEnumerable<T>> filter, IQueryable<Y> common)
        {
            object o = System.Web.HttpContext.Current.Cache[name];

            if (o == null)
            {
                lock (locker)
                {
                    if (o == null)
                    {
                        //запись в кэш из базы
                        System.Web.HttpContext.Current.Cache[name] = common.ToList();
                       
                        return GetFromCache<T, Y>(name, filter);

                    }
                    else
                    {
                        return GetFromCache<T, Y>(name, filter);
                    }
                }
            }
            else
            {
                return GetFromCache<T, Y>(name, filter);
            }
        }

        private static T[] GetFromCache<T, Y>(string name, Func<List<Y>, IEnumerable<T>> function)
        {
            List<Y> result = (List<Y>)System.Web.HttpContext.Current.Cache[name];
            return function(result).ToArray();
        }
        #endregion

        #region Public
        //TODO: Обдумать OrderBY
        public static User User(string userName)
        {
            return (User)Contractors().FirstOrDefault(x => x.Login.Equals(userName))
                ?? (User)SimpleUsers().FirstOrDefault(x => x.Login.Equals(userName));
        }

        public static User User(int Id)
        {
            return (User)Contractors().FirstOrDefault(x => x.Id.Equals(Id))
                   ?? (User)SimpleUsers().FirstOrDefault(x => x.Id.Equals(Id));
        }

        public static Contractor[] Contractors(int categoryId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Users.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<Contractor, Contractor>(
                    "contractors",
                    ref contractorsLocker,
                    x => x.Where(xx => xx.ContractorCategories != null && xx.ContractorCategories.Any(xxx => xxx.SubcategoryId == categoryId)),
                    Queries.GetContractorsList(context)
                    );
            }
        }
        public static Contractor[] Contractors()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Users.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<Contractor, Contractor>(
                    "contractors",
                    ref contractorsLocker,
                    x => x,
                    Queries.GetContractorsList(context)
                    );
            }
        }

        public static IEnumerable<IGrouping<bool, Contractor>> ContractorsGroupByPlateSize(int categoryId)
        {
            return Contractors(categoryId).GroupBy(x => x.HasBigPlate());
        }
        

        public static SimpleUser[] SimpleUsers()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Users.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<SimpleUser, SimpleUser>(
                    "simpleusers",
                    ref simpleUsersLocker,
                    x => x,
                    Queries.GetSimpleUsersList(context)
                    );
            }
        }
        public static Category[] Categories()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<Category, Category>(
                    "categories",
                    ref categoriesLocker,
                    x => x,
                    Queries.GetCategoriesList(context, true)
                    );
            }
        }
        public static SubCategory[] SubCategories()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.SubCategories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<SubCategory, Category>(
                       "categories",
                       ref categoriesLocker,
                       x => x.SelectMany(xx => xx.SubCategories),
                       Queries.GetCategoriesList(context, true)
                       );
            }
        }
        public static SubCategory[] SubCategories(int categoryId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.SubCategories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<SubCategory, Category>(
                       "categories",
                       ref categoriesLocker,
                       x => x.SelectMany(xx => xx.SubCategories.Where(xxx => xxx.CategoryId == categoryId)),
                       Queries.GetCategoriesList(context, true)
                       );
            }
        }
        public static SubCategory SubCategory(int subcategoryId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.SubCategories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                context.Categories.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                SubCategory[] a = GetItems<SubCategory, Category>(
                       "categories",
                       ref categoriesLocker,
                       x => x.SelectMany(xx => xx.SubCategories.Where(xxx => xxx.Id == subcategoryId)),
                       Queries.GetCategoriesList(context, true)
                       );
                if (a.Length > 0)
                    return a[0];
                else
                    return null;
            }
        }
        public static Contractor Contractor(int contractorId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                Contractor[] a = GetItems<Contractor, Contractor>(
                      "contractors",
                      ref contractorsLocker,
                      x => x.Where(xx => xx.Id == contractorId),
                      Queries.GetContractorsList(context)
                      );
                if (a.Length > 0)
                    return a[0];
                else
                    return null;
            }
        }

        public static Contractor Contractor(string login)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                Contractor[] a = GetItems<Contractor, Contractor>(
                      "contractors",
                      ref contractorsLocker,
                      x => x.Where(xx => xx.Login.Equals(login)),
                      Queries.GetContractorsList(context)
                      );
                if (a.Length > 0)
                    return a[0];
                else
                    return null;
            }
        }
        public static EventCard[] EventCards(int contractorId, int categoryId)
        {
            
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCards.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCard, EventCard>(
                    "eventcards",
                    ref eventcardLocker,
                    x => x.Where(xx => xx.EventCardCategories.Any(xxx => xxx.EventCardCompanies.Any(xxxx => xxxx.ContractorId == contractorId && xxxx.SubcategoryId == categoryId))),
                    //x => x.Where(xx => xx.EventCardCompanies.Any(xxx => xxx.ContractorId == contractorId && xxx.SubcategoryId == categoryId)),
                   EventCardsWithCompanies(contractorId).AsQueryable()//Queries.GetEventCards(context)
                    );
            }
        }

        //TODO: сделать по дате
        public static EventCard[] EventCards()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCards.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCard, EventCard>(
                    "eventcards",
                    ref eventcardLocker,
                    x => x,
                    //x => x.Where(xx => xx.EventCardCompanies.Any(xxx => xxx.ContractorId == contractorId && xxx.SubcategoryId == categoryId)),
                    Queries.GetEventCards(context)
                    );
            }
            
        }

        public static EventCard[] EventCards(int subcategoryId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCards.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCard, EventCard>(
                    "eventcards",
                    ref eventcardLocker,
                    x => x.Where(xx => xx.EventCardCategories.Any(xxx => xxx.SubcategoryId == subcategoryId)),
                    //x => x.Where(xx => xx.EventCardCompanies.Any(xxx => xxx.ContractorId == contractorId && xxx.SubcategoryId == categoryId)),
                    Queries.GetEventCards(context)
                    );
            }

        }

        public static EventCard EventCard(int Id)
        {
            return Get.EventCards().FirstOrDefault(x => x.Id == Id);

        }

        //public static EventCard[] EventCards(int contractorId)
        //{
        //    using (YourDayEntities context = new YourDayEntities())
        //    {
        //        context.EventCards.MergeOption = System.Data.Objects.MergeOption.NoTracking;
        //        return GetItems<EventCard, EventCard>(
        //            "eventcards",
        //            ref eventcardLocker,
        //             x => x.Where(xx => xx.EventCardCategories.Any(xxx => xxx.EventCardCompanies.Any(xxxx => xxxx.ContractorId == contractorId))),
        //            Queries.GetEventCards(context)
        //            );
        //    }
        //}

        public static Article[] Articles()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Articles.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<Article, Article>(
                    "articles",
                    ref articleLocker,
                    x => x,
                    Queries.GetArticles(context)
                    );
            }
        }

        public static News[] News()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.News.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<News, News>(
                    "news",
                    ref newsLocker,
                    x => x,
                    Queries.GetNews(context)
                    );
            }
        }

        //TODO: По-идее три функции точно можно в одну объединить.
        public static Media[] Medias(int contractorId, YourDay.Constants.Enums.MediaType type)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Medias.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return context.Medias
                    .Include("MediaRates")
                    .Where(x =>
                    EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.ContractorId).Equals(contractorId) &&
                    x.Type == (int)type).ToArray();
            }
        }

        public static Media[] Medias(int contractorId, int subcategoryId, YourDay.Constants.Enums.MediaType type)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Medias.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return context.Medias
                    .Include("MediaRates")
                    .Where(x =>
                     EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.ContractorId).Equals(contractorId) &&
                     EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.SubcategoryId).Equals(subcategoryId) &&
                     x.Type == (int)type).ToArray();
            }
        }

        public static Media[] Medias(int eventcardId, bool takeByEventCard, YourDay.Constants.Enums.MediaType type)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Medias.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return context.Medias
                    .Include("MediaRates")
                    .Where(x =>
                        EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.EventCardId).Equals(eventcardId) &&
                        x.Type == (int)type
                        ).ToArray();
            }
        }

        public static Media[] Medias(int contractorId = 0, int subcategoryId = 0, int eventcardId = 0, YourDay.Constants.Enums.MediaType type = Enums.MediaType.Photo)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Medias.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return context.Medias
                    .Include("MediaRates")
                    .Where(x =>
                     (contractorId == 0 || EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.ContractorId).Equals(contractorId)) &&
                     (subcategoryId == 0 || EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.SubcategoryId).Equals(subcategoryId)) &&
                     (eventcardId == 0 || EdmFunctions.GetRelationIdFromKey(x.RelationId, (int)MediaEventCardCompanySplitterType.EventCardId).Equals(eventcardId)) &&
                    x.Type == (int)type).ToArray();
            }
        }

        public static EventCardCompany[] EventCardCompanies(int contractorId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCardCompanies.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCardCompany, EventCardCompany>(
                    "eventcardcompanies",
                    ref eventcardCompanyLocker,
                    x => x.Where(xx => xx.ContractorId == contractorId),
                    Queries.GetEventCardCompanies(context)
                    );
            }
        }

        public static EventCardCompany[] EventCardCompanies(int eventCardId, Enums.EventCardCompanyStatus status)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCardCompanies.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCardCompany, EventCardCompany>(
                    "eventcardcompanies",
                    ref eventcardCompanyLocker,
                    x => x.Where(xx => xx.EventCardId == eventCardId && (status.HasFlag((Enums.EventCardCompanyStatus)Enum.Parse(typeof(Enums.EventCardCompanyStatus), xx.State.ToString())) || status == null)),
                    Queries.GetEventCardCompanies(context)
                    );
            }
        }

        public static EventCardCompany[] EventCardCompanies(int eventCardId, int subcategoryId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCardCompanies.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCardCompany, EventCardCompany>(
                    "eventcardcompanies",
                    ref eventcardCompanyLocker,
                    x => x.Where(xx => xx.EventCardId == eventCardId && (subcategoryId == 0 || xx.SubcategoryId == subcategoryId)),
                    Queries.GetEventCardCompanies(context)
                    );
            }
        }

        public static EventCardType[] EventCardTypes()
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCardTypes.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<EventCardType, EventCardType>(
                    "eventcardtypes",
                    ref eventcardLocker,
                    x => x,
                    Queries.GetEventCartTypes(context)
                    );
                
            }
        }


        public static Comment[] PrivateEventCardMessages(int contractorId, int eventcardId, int count = Int32.MaxValue)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Comments.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return  context.Comments.Where(xx => 
                         (
                            xx.AuthorId == contractorId 
                            || 
                            xx.ReceiverId == contractorId
                          ) 
                         && 
                            xx.RelationId == eventcardId 
                         && 
                         (
                            xx.Type == (int)Constants.Enums.CommentsType.PrivateMessageFromContractorToSimpleUser 
                            || 
                            xx.Type == (int)Constants.Enums.CommentsType.PrivateMessageToContractorFromSimpleUser
                          )
                          && xx.AlreadyRead == false
                       ).OrderByDescending(xx => xx.DateTime).Take(count).OrderBy(xx => xx.DateTime).ToArray();
            }
        }
        
        //TODO: Дохуя раз вызывается. и вообще как-то коряво
        public static EventCard[] EventCardsWithCompanies(int contractorId)
        {
            var ec = Get.EventCards();
            var ecc = Get.EventCardCompanies(contractorId);
            foreach(var el in ec)
                foreach(var el2 in el.EventCardCategories)
                    el2.EventCardCompanies = new System.Collections.ObjectModel.Collection<EventCardCompany>();


            var join = 
                ec.SelectMany(x => x.EventCardCategories)
                .Join(
                    ecc, 
                    x => x,
                    x => new EventCardCategory() { EventCardId = x.EventCardId, SubcategoryId = x.SubcategoryId },
                    (x, y) => FillEventCardWithCompanies(x,y),
                    new Comparers.EventCardCategoryComparer()
                    ).ToArray();

            return join;
        }

        public static FavouriteItem[] FavouriteItems(int userId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCardCompanies.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                return GetItems<FavouriteItem, FavouriteItem>(
                    "favouriteitems",
                    ref favouriteItemsLocker,
                    x => x.Where(xx => xx.UserId == userId),
                    Queries.GetFavouriteItems(context)
                    );
            }
        }

        private static EventCard FillEventCardWithCompanies(EventCardCategory eccat, EventCardCompany eccom)
        {
            EventCard ec = eccat.EventCard;
            if (eccat.EventCardCompanies == null)
                eccat.EventCardCompanies = new System.Collections.ObjectModel.Collection<EventCardCompany>();

            eccat.EventCardCompanies.Add(eccom);
            return ec;
        }


        #region Messages

        public static int NewMessagesCount(POCO.User user, DateTime Date)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                return Queries.GetNewMessagesCount(context, user.Id, Date);
            }
        }

        private static Comment[] Messages(POCO.User user, int skip = 0, int take = Int32.MaxValue)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                return Queries.GetCommentsByUser(context, user.Id, Enums.CommentsType.All, skip, take).ToArray();
            }
         }

        private static Comment[] Messages(POCO.User user, Constants.Enums.CommentsType type, int skip = 0, int take = Int32.MaxValue)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                return Queries.GetCommentsByUser(context, user.Id, type, skip, take).ToArray();
            }
        }

        private static Comment[] Messages(POCO.User user, Enums.CommentsType type, string param, Enums.CommentFilter paramType, int skip = 0, int take = Int32.MaxValue)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                return Queries.GetCommentsByUserAndParam(context, user.Id, type, param, paramType, skip, take).ToArray();
            }
        }

        public static Comment[] Messages(POCO.User user, ref string type, string ec, string op, string date, int skip = 0, int take = Int32.MaxValue)
        {
            Comment[] result = new Comment[0];



            Enums.CommentsType ct = Enums.CommentsType.All;
            //ХК
            if (string.IsNullOrEmpty(type))
            {
                ct = Enums.CommentsType.All;
            }
            else if (type.Equals("in"))
            {
                if (user.GetType() == typeof(POCO.Contractor))
                    ct = Enums.CommentsType.PrivateMessageToContractorFromSimpleUser;
                else
                    ct = Enums.CommentsType.PrivateMessageFromContractorToSimpleUser;
            }
            else if (type.Equals("out"))
            {
                if (user.GetType() == typeof(POCO.Contractor))
                    ct = Enums.CommentsType.PrivateMessageFromContractorToSimpleUser;
                else
                    ct = Enums.CommentsType.PrivateMessageToContractorFromSimpleUser;
            }

            int ecId, opId;
            DateTime dt;
            if (!string.IsNullOrEmpty(ec) && Int32.TryParse(ec, out ecId))
            {
                result = Messages(user, ct, ec, Enums.CommentFilter.Item, skip, take);
            }
            else if (!string.IsNullOrEmpty(op) && Int32.TryParse(op, out opId))
            {
                if (!op.Equals(user.Id.ToString()))
                    result = Messages(user, ct, op, Enums.CommentFilter.Opponent, skip, take);
                else
                    result = Messages(user, ct, skip, take);
            }
            else if (!string.IsNullOrEmpty(date) && DateTime.TryParse(date, out dt))
            {
                result = Messages(user, ct, date, Enums.CommentFilter.Date, skip, take);
            }
            else
            {
                result = Messages(user, ct, skip, take);
            }
            return result;
        }

        #endregion

        #endregion
    }   
}
