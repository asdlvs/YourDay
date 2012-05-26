using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourDay.DAL;
using System.Configuration;
using System.Web;
using System.IO;
using YourDay.Constants;


namespace YourDay.BLL
{
    public class Post
    {


        public static void InsertObject<T>(T obj)
        {
            string cacheName = Constants.Strings.PocoTypesCacheName.Single(x => x.Key == typeof(T)).Value;
            var objectSetFromCache = (List<T>)System.Web.HttpContext.Current.Cache[cacheName];
            if (objectSetFromCache != null)
                objectSetFromCache.Add(obj);
        }

        public static void UpdateObject<T>(T obj, IEqualityComparer<T> comparer)
        {
            string cacheName = Constants.Strings.PocoTypesCacheName.Single(x => x.Key == typeof(T)).Value;
            ((List<T>)System.Web.HttpContext.Current.Cache[cacheName]).RemoveAll(x => comparer.Equals(x, obj));
            ((List<T>)System.Web.HttpContext.Current.Cache[cacheName]).Add(obj);
            var o = ((List<T>)System.Web.HttpContext.Current.Cache[cacheName]);
        }


        public static void SimpleUser(POCO.SimpleUser su)
        {
            if (BLL.Get.Contractors().Any(x => x.Login == su.Login))
                throw new Exception(Constants.Errors.UserAlreadyExist);

            using (YourDayEntities context = new YourDayEntities())
            {
                //POCO.SimpleUser newSimpleUser = new POCO.SimpleUser();
                //newSimpleUser.Login = login;
                //newSimpleUser.EMail = login;
                context.Users.AddObject(su);
                InsertObject<POCO.SimpleUser>(su);
                context.SaveChanges();
            }
        }

        private static void UpdateContractor(POCO.Contractor con)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                

                POCO.Contractor curSql = context.Users.OfType<POCO.Contractor>()
                    .Include("Avatars")
                    .Single(x => x.Login.Equals(con.Login));

               

                curSql.FirstName = con.FirstName;
                curSql.LastName = con.LastName;
                curSql.Site = con.Site;
                curSql.Phone = con.Phone;
                curSql.Facebook = con.Facebook;
                curSql.VK = con.VK;
                curSql.Twitter = con.Twitter;
                curSql.EMail = con.EMail;
                curSql.Description = con.Description;
                curSql.Additional = con.Additional;
                curSql.AvatarSrc = con.AvatarSrc;
                if (!curSql.Avatars.Select(x => x.Id).SequenceEqual(con.Avatars.Select(x => x.Id)))
                {
                    foreach (var ava in curSql.Avatars.ToList())
                    {
                        context.Avatars.DeleteObject(ava);
                    }
                    curSql.Avatars = con.Avatars;
                }
                context.SaveChanges();
                UpdateObject<POCO.Contractor>(con, new BLL.Comparers.ContractorsComparer());
            }
        }

        private static void UpdateSimpleUser(POCO.SimpleUser su)
        { 
            using (YourDayEntities context = new YourDayEntities())
            {
                POCO.SimpleUser curSql = context.Users.OfType<POCO.SimpleUser>().Single(x => x.Login.Equals(su.Login));
                curSql.FirstName = su.FirstName;
                curSql.LastName = su.LastName;
                curSql.EMail = su.EMail;
                curSql.AvatarSrc = su.AvatarSrc;
                curSql.Avatars = su.Avatars;
                context.SaveChanges();
                UpdateObject<POCO.SimpleUser>(su, new BLL.Comparers.SimpleUsersComparer());
            }
        }

        public static void UpdateUser(POCO.User u)
        {
            if (u.GetType() == typeof(POCO.Contractor))
            {
                UpdateContractor((POCO.Contractor)u);
            }
            else
            {
                UpdateSimpleUser((POCO.SimpleUser)u);
            }
        }

        public static int EventCard(POCO.EventCard ec)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                context.EventCards.AddObject(ec);
                context.SaveChanges();
                InsertObject<POCO.EventCard>(ec);
                return ec.Id;
            }
            
        }

        public static void UpdateEventCardCompanyStatus(int contractorId, int ecId, int subcategoryId, int status)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                POCO.EventCardCompany ecc = context.EventCardCompanies.FirstOrDefault(x => x.EventCardId == ecId && x.SubcategoryId == subcategoryId && x.ContractorId == contractorId);
                if (ecc != null)
                {
                    ecc.State = status;
                    UpdateObject<POCO.EventCardCompany>(ecc, new BLL.Comparers.EventCardCompanyComparer());
                    context.SaveChanges();
                }

            }
        }

        public static void AddMessageToEcFromContractor(int contractorId, int receiverId, int ecId, string text)
        {
            POCO.Comment comment = new POCO.Comment();
            comment.AuthorId = contractorId;
            comment.ReceiverId = receiverId;
            comment.RelationId = ecId;
            comment.Text = text;
            comment.DateTime = DateTime.Now;
            comment.Type = (int)Constants.Enums.CommentsType.PrivateMessageFromContractorToSimpleUser;
            using (YourDayEntities context = new YourDayEntities())
            {
                context.Comments.AddObject(comment);
                context.SaveChanges();
            }
        }

        public static void UserAvatar(string login, byte[] file)
        {
            string host = ConfigurationManager.AppSettings["Images"];
            string folder = HttpContext.Current.Server.MapPath(String.Format(@"{0}/{1}/", host, login));
            File.WriteAllBytes(String.Format(@"{0}avatar.png", folder), file);
        }

        public static void MarkMessagesAsAR(int[] ids)
        {
            if (ids.Length == 0)
                return;
            using (YourDayEntities context = new YourDayEntities())
            {
                var cs = context.Comments.Where(x => ids.Contains(x.Id));
                var ugu = false;
                foreach (var c in cs)
                {
                    if (!c.AlreadyRead)
                    {
                        c.AlreadyRead = true;
                        ugu = true;
                    }
                }
                if(ugu)
                    context.SaveChanges();
            }
        }

        public static void AddFavourite(POCO.User user, int itemId, Enums.FavouriteType type)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                POCO.FavouriteItem fi = new POCO.FavouriteItem();
                fi.UserId = user.Id;
                fi.ItemId = itemId;
                fi.Type = (int)type;
                context.FavouriteItems.AddObject(fi);
                context.SaveChanges();
                UpdateObject<POCO.FavouriteItem>(fi, new Comparers.FavouriteItemsComparer());
            }
        }

        public static void AddEventCardCompany(int eventCardId, int subcategoryId, int contractorId, YourDay.Constants.Enums.EventCardCompanyStatus status)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                    POCO.EventCardCompany ecc = new POCO.EventCardCompany();
                    ecc.EventCardId = eventCardId;
                    ecc.SubcategoryId = subcategoryId;
                    ecc.ContractorId = contractorId;
                    ecc.State = (int)status;
                    context.EventCardCompanies.AddObject(ecc);
                    context.SaveChanges();
                    InsertObject<POCO.EventCardCompany>(ecc);
            }
        }

        public static void AddEventCardCategory(int eventCardId, int subcategoryId)
        {
            using(YourDayEntities context = new YourDayEntities())
            {
                var eventCard = context.EventCards.Include("EventCardCategories").SingleOrDefault(x => x.Id == eventCardId);
                if (!eventCard.EventCardCategories.Any(x => x.SubcategoryId == subcategoryId))
                {
                    eventCard.EventCardCategories.Add(new POCO.EventCardCategory() { SubcategoryId = subcategoryId });
                    context.SaveChanges();
                }
                if (!BLL.Get.EventCard(eventCardId).EventCardCategories.Any(x => x.SubcategoryId == subcategoryId))
                {
                    UpdateObject<YourDay.POCO.EventCard>(eventCard, new Comparers.EventCardComparer());
                }
            }

           
           // BLL.Get.EventCard(eventCardId).EventCardCategories.Add(ecc);
        }

    }
}
