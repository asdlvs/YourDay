using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using YourDay.POCO;
using System.Data.Objects.DataClasses;

namespace YourDay.DAL
{
    public partial class YourDayEntities : ObjectContext, IDisposable
    {
        public YourDayEntities()
            : base("name=YourDayEntities", "YourDayEntities")
        {
        }
        public ObjectSet<User> Users
        {
            get { return base.CreateObjectSet<User>("Users"); }
        }

        public ObjectSet<Category> Categories
        {
            get { return base.CreateObjectSet<Category>("Categories"); }
        }

        public ObjectSet<SubCategory> SubCategories
        {
            get { return base.CreateObjectSet<SubCategory>("SubCategories"); }
        }

        public ObjectSet<EventCard> EventCards
        {
            get { return base.CreateObjectSet<EventCard>("EventCards"); }
        }

        public ObjectSet<EventCardCompany> EventCardCompanies
        {
            get { return base.CreateObjectSet<EventCardCompany>("EventCardCompanies"); }
        }

        public ObjectSet<Article> Articles
        {
            get { return base.CreateObjectSet<Article>("Articles"); }
        }

        public ObjectSet<News> News
        {
            get { return base.CreateObjectSet<News>("News"); }
        }

        public ObjectSet<EventCardType> EventCardTypes
        {
            get { return base.CreateObjectSet<EventCardType>("EventCardTypes"); }
        }

        public ObjectSet<Comment> Comments
        {
            get { return base.CreateObjectSet<Comment>("Comments"); }
        }

        public ObjectSet<Media> Medias
        {
            get { return base.CreateObjectSet<Media>("Medias"); }
        }

        public ObjectSet<FavouriteItem> FavouriteItems
        {
            get { return base.CreateObjectSet<FavouriteItem>("FavouriteItems"); }
        }

        public ObjectSet<Avatar> Avatars
        {
            get { return base.CreateObjectSet<Avatar>("Avatars"); }
        }

        //public ObjectQuery<object> GetRelationIdFromKey(string key, int type)
        //{
        //    //base.ExecuteFunction<object>("YourDayModel.Store.GetRelationIdFromKey", new ObjectParameter("key", key), new ObjectParameter("type", type));\
        //    ObjectQuery<object> result = base.CreateQuery<object>("SELECT VALUE YourDayModel.Store.GetRelationIdFromKey(@key, @type) FROM {1}", new ObjectParameter("key", key), new ObjectParameter("type", type));//base.ExecuteFunction<int>("GetRelationIdFromKey", new ObjectParameter("key", key), new ObjectParameter("type", type));
        //    return result;
        //}
    }

    
}
