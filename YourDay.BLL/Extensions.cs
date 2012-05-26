using System.Web.UI;
using System.Web;
using System.Text;
using System;
using YourDay.POCO;
using YourDay.Constants;
using System.Collections.Generic;
using System.Linq;


namespace YourDay.BLL
{
    public static class ExtensionManager
    {
        public static T DeepFindControl<T>(this Control control, string id)
        {
            T result = default(T);
            if (control.Controls.Count > 0)
            {
                foreach (Control c in control.Controls)
                {
                    if (c.ID == id)
                    {
                        result = (T)(object)c;
                        return result;
                    }
                    else
                    {
                        if (c.DeepFindControl<T>(id) != null)
                        {
                            result = c.DeepFindControl<T>(id);
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        public static void SendMessage(this POCO.User receiver, int senderId, string messageTopic, string messageBody)
        {
            string _messageTopic = messageTopic.HtmlEncode();
            string _messageBody = messageBody.HtmlEncode();
        }

        public static string HtmlEncode(this string s)
        {
            return HttpContext.Current.Server.HtmlEncode(s);
        }

        public static string HtmlDecode(this string s)
        {
            return HttpContext.Current.Server.HtmlDecode(s);
        }

        public static string GetPostParameterName(this Control control)
        {
            System.Web.UI.HtmlControls.HtmlForm form = new System.Web.UI.HtmlControls.HtmlForm();
            string result = String.Empty;
            while (!control.GetType().Equals(form.GetType()))
            {
                result = String.Format("{0}${1}", control.ID, result);
                control = control.Parent;
            }
            //TODO: HC
            result = String.Format("{0}${1}", "ctl00", result);
            result = result.Substring(0, result.Length - 1);
            return result;
        }

        public static void StartEventCardContractorSelection(this User user, int eventCardId)
        {
            //TODO: HC
            HttpContext.Current.Session["eventCardSelection"] = eventCardId.ToString();
        }

        public static int AddContractorToSelection(this User user, int subcategoryId, int contractorId, out bool eventCardCategoryExists, bool addEventCategory)
        {
            object o = HttpContext.Current.Session["eventCardSelection"];
            if (o != null)
            {
                if (addEventCategory)
                    Post.AddEventCardCategory((int)o, subcategoryId);

                ICollection<EventCardCategory> eccs = BLL.Get.EventCard((int)o).EventCardCategories;
                eventCardCategoryExists = false;
                foreach (EventCardCategory ecc in eccs)
                {
                    if (ecc.EventCardId == (int)o && ecc.SubcategoryId == subcategoryId)
                    {
                        eventCardCategoryExists = true;
                        break;
                    }
                }
                if (eventCardCategoryExists)
                    Post.AddEventCardCompany((int)o, subcategoryId, contractorId, YourDay.Constants.Enums.EventCardCompanyStatus.Offer);

                return (int)o;
            }
            else
            {
                throw new Exception("Parameter Event Selection in Session is null.");
            }
        }
        public static int RemoveContractorFromSelection(this User user, int subcategoryId, int contractorId)
        {
            object o = HttpContext.Current.Session["eventCardSelection"];
            if (o != null)
            {
                BLL.Del.RemoveEventCardCompany((int)o, contractorId, subcategoryId);
                return (int)o;
            }
            else
            {
                throw new Exception("Parameter Event Selection in Session is null.");
            }
        }

        //TODO: Глянуть формирующийся запрос. Может табличку избранного в отдельный кеш вынести.
        public static void AddFavourites(this User user, int itemId, Enums.FavouriteType type)
        {
            BLL.Post.AddFavourite(user, itemId, type);
        }
        public static IEnumerable<T> GetFavouriteItems<T>(this User user)
        {
            if (typeof(T) == typeof(Contractor))
            {
                var favouriteItems = BLL.Get.FavouriteItems(user.Id).Where(x => x.Type == (int)Enums.FavouriteType.Contractor);
                if (favouriteItems.Count() > 0)
                    return favouriteItems.Select(x => BLL.Get.Contractor(x.ItemId)) as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(EventCard))
            {
                var favouriteItems = BLL.Get.FavouriteItems(user.Id).Where(x => x.Type == (int)Enums.FavouriteType.EventCard);
                if (favouriteItems.Count() > 0)
                    return favouriteItems.Select(x => BLL.Get.EventCard(x.ItemId)) as IEnumerable<T>;
            }
            else if (typeof(T) == typeof(Article))
            {
                // var favouriteItems = BLL.Get.FavouriteItems(user.Id).Where(x => x.Type == (int)Enums.FavouriteType.Article);
                //return favouriteItems.Select(x => BLL.Get.Articles(x.ItemId)) as IEnumerable<T>;
            }
            return null;
        }
        public static string GetAvatarImage(this User user, int Width, int Height = 0)
        {
            if (user.Avatars.Count() == 0)
                return null;

            string result = null;
            if (Height == 0)
            {
                var maxExistedWidth = user.Avatars
                        .Where(xx => xx.Width <= Width)
                        .Max(xx => xx.Width);
                var src = user.Avatars.FirstOrDefault(x => x.Width == x.Height && x.Width == maxExistedWidth);
                if (src != null)
                    result = src.ImageName;
            }
            else
            {
                var avatarsWithDiff = user.Avatars.Where(x => x.Width != x.Height);
                if (avatarsWithDiff.Count() > 0)
                {
                    var first = avatarsWithDiff.First();
                    if (first.Width > first.Height)
                    {
                        result = avatarsWithDiff
                            .Where(x => x.Width <= Width)
                            .OrderBy(x => x.Width)
                            .Last()
                            .ImageName;
                    }
                    else
                    {
                        result = avatarsWithDiff
                             .Where(x => x.Height <= Height)
                             .OrderBy(x => x.Height)
                             .Last()
                             .ImageName;

                    }
                }
            }
            return result.Replace("\\", "/");
        }

        //TODO:Реализовать
        public static bool HasBigPlate(this Contractor contractor)
        {
            return true;
        }
    }
}
