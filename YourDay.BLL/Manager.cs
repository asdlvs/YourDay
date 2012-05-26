using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Web;
using YourDay.Configuration;

namespace YourDay.BLL
{
    public class Manager
    {
        public static void ClearCache()
        {
            string cacheItem;
            IDictionaryEnumerator CacheEnum = System.Web.HttpContext.Current.Cache.GetEnumerator();
            while (CacheEnum.MoveNext())
            {
                cacheItem = System.Web.HttpContext.Current.Server.HtmlEncode(((DictionaryEntry)CacheEnum.Current).Key.ToString());
                System.Web.HttpContext.Current.Cache.Remove(cacheItem);
            }
            System.Web.HttpContext.Current.Response.Redirect(System.Web.HttpContext.Current.Request.RawUrl);
        }

        private static string GetLinkUrl(string key, params object[] items)
        {
            MasquaradueRulesConfigSection rulesCS = (MasquaradueRulesConfigSection)ConfigurationManager.GetSection("masquaradueRules");
            string link = String.Empty;
            Rule rule = rulesCS.Rules.GetByKey(key);
            link = String.Format(rule.Request, items);
            return link;
        }

        public static string GetEventCardLink(int eventcardId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("eventCardLink", host, eventcardId);
        }

        public static string GetSubcategoryLink(int categoryId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("subcategoryLink", host, categoryId);
        }

        public static string GetCategoryLink(int categoryId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            var subcategoryId = Get.SubCategories(categoryId).First().Id;
            return GetLinkUrl("subcategoryLink", host, subcategoryId);
        }

        public static string GetContractorSubcategoryLink(int categoryId, int contractorId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contractorsCategoryLink", host, categoryId, contractorId);
        }

        public static string GetUserAvatar(string login, int size)
        {
             string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
             if (size != 0)
                 return String.Format("{0}?rnd={1}", GetLinkUrl("contractorAvatar", host, login, size), (new Random()).Next(0, 99999999));
             else
                 return String.Format("{0}/Images/{1}/avatar.png", host, login);
        }

        public static string GetUserAvatar(int userId, int size)
        {

            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contractorAvatar", host, GetUser(userId).Login, size);
        }
        public static string GetContractorThumbPhoto(string login, string photoName, int width, int height)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contactorThumbPhotoes", host, login, photoName, width, height);
        }
        public static string GetContractorThumbPhoto(int contractorId, string photoName, int width, int height)
        {
            string login = BLL.Get.Contractor(contractorId).Login;
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contactorThumbPhotoes", host, login, photoName, width, height);
        }
        public static string GetContractorPhoto(string login, string photoName, int width, int height)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contactorPhotoes", host, login, photoName, width, height);
        }
        public static string GetContractorPhoto(int contractorId, string photoName, int width, int height)
        {
            string login = BLL.Get.Contractor(contractorId).Login;
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contactorPhotoes", host, login, photoName, width, height);
        }

        public static string GetArticleThumbImg(int articleId, bool isShort)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("articleImage", host, isShort ? 1 : 0, articleId);
        }

        public static string GetArticleLink(int articleId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("article", host, articleId);
        }

        public static string GetNewsLink(int newsId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("news", host, newsId);
        }

        public static string GetReportWithSubcategoryLink(int scId)
        {
            string host = String.Format("http://{0}", HttpContext.Current.Request.Url.Authority);
            return GetLinkUrl("contractorReportsWithSubcategoryId", host, scId);
        }

        public static POCO.User GetUser(string username)
        {
            return (POCO.User)BLL.Get.SimpleUsers().FirstOrDefault(x => x.Login.Equals(username)) ??
                (POCO.User)BLL.Get.Contractors().FirstOrDefault(x => x.Login.Equals(username));
        }

        public static POCO.User GetUser(int userId)
        {
            return (POCO.User)BLL.Get.SimpleUsers().FirstOrDefault(x => x.Id.Equals(userId)) ??
                (POCO.User)BLL.Get.Contractors().FirstOrDefault(x => x.Id.Equals(userId));
        }

        public static string GetShortContent(string content, int wordsCount)
        {
            string[] contentArray = content.Split(' ');
            StringBuilder sb = new StringBuilder();
            int max = Math.Min(wordsCount, contentArray.Length);//contentArray.Length < wordsCount ? contentArray.Length : wordsCount;
            for (int i = 0; i < max; i++)
                sb.AppendFormat("{0} ", contentArray[i]);

            
            
            return String.Format("{0}...", sb.ToString().Trim());
        }


        public static string GetBestsTitle(int subcategoryId)
        {
            POCO.SubCategory sc = Get.SubCategory(subcategoryId);
            return String.Format("Лучшие {0}", sc.Persons ?? sc.Title);
        }

        public static POCO.Contractor[] GetTopSixOnMain(int subcategoryId)
        {
            return Get.Contractors(subcategoryId).Take(6).ToArray();
        }

        public static POCO.Media[] GetEventPhotoes(int eventId)
        {
            
            //TODO: Подумать над оптимизацией
            return Get.Medias(eventId, true, YourDay.Constants.Enums.MediaType.Photo).OrderBy(x => x.MediaRates.Where(xx => xx.IsPositive == true).Count()).Take(8).ToArray();
        }


       

    }
}
