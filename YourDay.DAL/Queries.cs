using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using YourDay.POCO;
using YourDay.Constants;

namespace YourDay.DAL
{
    public class Queries
    {
        #region Compiled Queries
        public static Func<YourDayEntities, IQueryable<Contractor>> GetContractorsList =
            CompiledQuery.Compile<YourDayEntities, IQueryable<Contractor>>(ctx => ctx.Users.OfType<Contractor>()
                .Include("ContractorCategories")
                .Include("City")
                .Include("ClosedDays")
                .Include("Avatars")
                .Where(x => x.Activate == true)
                );

        public static Func<YourDayEntities, IQueryable<SimpleUser>> GetSimpleUsersList =
            CompiledQuery.Compile<YourDayEntities, IQueryable<SimpleUser>>(ctx => ctx.Users.OfType<SimpleUser>()
                 .Include("Avatars")
            );

        private static Func<YourDayEntities, IQueryable<Category>> GetCategoriesListWithCategories =
            CompiledQuery.Compile<YourDayEntities, IQueryable<Category>>(ctx => ctx.Categories
                .Include("SubCategories")
                .Include("SubCategories.ContractorCategories")
                );

        private static Func<YourDayEntities, IQueryable<Category>> GetCategoriesListWithoutCategories =
            CompiledQuery.Compile<YourDayEntities, IQueryable<Category>>(ctx => ctx.Categories);

        public static Func<YourDayEntities, IQueryable<EventCard>> GetEventCards =
            CompiledQuery.Compile<YourDayEntities, IQueryable<EventCard>>(ctx => ctx.EventCards
                .Include("EventCardCategories")
                .Include("EventCardType")
                //.Include("EventCardCategories.EventCardCompanies")
                //.Include("EventCardCompanies.EventCardCompanyMedia")
                //.Include("EventCardCompanies.EventCardCompanyMedia.EventCardCompanyMediaComments")
                );

        public static Func<YourDayEntities, IQueryable<EventCardCompany>> GetEventCardCompanies =
            CompiledQuery.Compile<YourDayEntities, IQueryable<EventCardCompany>>(ctx => ctx.EventCardCompanies
                //.Include("Media")
                //.Include("Media.MediaRates")
            );

        public static Func<YourDayEntities, IQueryable<Article>> GetArticles =
            CompiledQuery.Compile<YourDayEntities, IQueryable<Article>>(ctx => ctx.Articles
                .Include("ArticleRates")
                .OrderByDescending(x => x.DateTime)
            );

        public static Func<YourDayEntities, IQueryable<News>> GetNews =
            CompiledQuery.Compile<YourDayEntities, IQueryable<News>>(ctx => ctx.News
            .Include("NewsRates")
            .OrderByDescending(x => x.DateTime)
            );

        public static Func<YourDayEntities, IQueryable<FavouriteItem>> GetFavouriteItems =
            CompiledQuery.Compile<YourDayEntities, IQueryable<FavouriteItem>>(ctx => ctx.FavouriteItems);
            

        public static Func<YourDayEntities, IQueryable<EventCardType>> GetEventCartTypes =
            CompiledQuery.Compile<YourDayEntities, IQueryable<EventCardType>>(ctx => ctx.EventCardTypes
                .OrderBy(x => x.Title)
            );



        public static Func<YourDayEntities, int, Enums.CommentsType, int, int, IQueryable<Comment>> GetCommentsByUser =
           CompiledQuery.Compile<YourDayEntities, int, Enums.CommentsType, int, int, IQueryable<Comment>>((ctx, user, type, skip, take) => ctx.Comments
           .Where(x => (x.ReceiverId == user || x.AuthorId == user) && ((x.Type & (int)type) != 0))
           .OrderByDescending(x => x.DateTime)
           .Skip(skip)
           .Take(take)
           );

        public static Func<YourDayEntities, int, Enums.CommentsType, int, Enums.CommentFilter, int, int, IQueryable<Comment>> GetCommentsByItem =
           CompiledQuery.Compile<YourDayEntities, int, Enums.CommentsType, int, Enums.CommentFilter, int, int, IQueryable<Comment>>((ctx, user, type, param, paramType, skip, take) => ctx.Comments
                               .Where(x => (x.ReceiverId == user || x.AuthorId == user) && ((x.Type & (int)type) != 0) && x.RelationId == param)
                               .OrderByDescending(x => x.DateTime)
                               .Skip(skip)
                               .Take(take));

        public static Func<YourDayEntities, int, Enums.CommentsType, DateTime, Enums.CommentFilter, int, int, IQueryable<Comment>> GetCommentsByDate =
          CompiledQuery.Compile<YourDayEntities, int, Enums.CommentsType, DateTime, Enums.CommentFilter, int, int, IQueryable<Comment>>((ctx, user, type, param, paramType, skip, take) => ctx.Comments
                               .Where(x => (x.ReceiverId == user || x.AuthorId == user) && ((x.Type & (int)type) != 0) && x.DateTime.Year == param.Year && x.DateTime.Month == param.Month && x.DateTime.Day == param.Day)
                               .OrderByDescending(x => x.DateTime)
                               .Skip(skip)
                               .Take(take));

        public static Func<YourDayEntities, int, Enums.CommentsType, int, Enums.CommentFilter, int, int, IQueryable<Comment>> GetCommentsByOpponent =
          CompiledQuery.Compile<YourDayEntities, int, Enums.CommentsType, int, Enums.CommentFilter, int, int, IQueryable<Comment>>((ctx, user, type, param, paramType, skip, take) => ctx.Comments
                               .Where(x => ((x.ReceiverId == user && x.AuthorId == param) || (x.AuthorId == user && x.ReceiverId == param)) && ((x.Type & (int)type) != 0))
                               .OrderByDescending(x => x.DateTime)
                               .Skip(skip)
                               .Take(take));




        public static Func<YourDayEntities, int, DateTime, int> GetNewMessagesCount =
           CompiledQuery.Compile<YourDayEntities, int, DateTime,  int>((ctx, user, dt) => ctx.Comments
           .Where(x => !x.AlreadyRead && x.ReceiverId == user && x.DateTime.Year == dt.Year && x.DateTime.Month == dt.Month && x.DateTime.Day == dt.Day)
           .Count());


        public static IQueryable<Media> GetMedia(YourDayEntities ctx, Func<Media, Boolean> f)
        {
            return ctx.Medias
                 .Include("MediaRates")
                 .Where(x => f(x));
        }
        #endregion

        #region Logic Queries
        public static IQueryable<Category> GetCategoriesList(YourDayEntities context, bool include)
        {
            return include ?
                GetCategoriesListWithCategories(context) :
                GetCategoriesListWithoutCategories(context);
        }

        public static IQueryable<Comment> GetCommentsByUserAndParam(YourDayEntities ctx, int user, Enums.CommentsType type, string param, Enums.CommentFilter paramType, int skip, int take)
        {
            IQueryable<Comment> result = null;
            switch (paramType)
            {
                case Enums.CommentFilter.Item:
                    int item = Int32.Parse(param);
                    result = GetCommentsByItem(ctx, user, type, item, paramType, skip, take);
                    break;
                case Enums.CommentFilter.Date:
                    DateTime dt = DateTime.Parse(param);
                    result = GetCommentsByDate(ctx, user, type, dt, paramType, skip, take);
                    break;
                case Enums.CommentFilter.Opponent:
                    int opponent = Int32.Parse(param);
                    result = GetCommentsByOpponent(ctx, user, type, opponent, paramType, skip, take);
                    break;

            }
            return result;
        }

        #endregion

        #region PreLoad
        public static void Compile(YourDayEntities context)
        {
            context.Users.MergeOption = MergeOption.NoTracking;
            GetContractorsList(context);
            GetSimpleUsersList(context);
            context.Categories.MergeOption = MergeOption.NoTracking;
            GetCategoriesList(context, true);
            GetCategoriesList(context, false);

        }
        #endregion
    }
}
