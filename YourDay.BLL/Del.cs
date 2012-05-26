using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Web;
using System.IO;
using YourDay.DAL;
using YourDay.POCO;

namespace YourDay.BLL
{
    public class Del
    {

        public static void DeleteObject<T>(T obj, IEqualityComparer<T> comparer)
        {
            string cacheName = Constants.Strings.PocoTypesCacheName.Single(x => x.Key == typeof(T)).Value;
            ((List<T>)System.Web.HttpContext.Current.Cache[cacheName]).RemoveAll(x => comparer.Equals(x, obj));

        }

        public static bool Avatar(string login)
        {
            string host = ConfigurationManager.AppSettings["Images"];
            string folder = HttpContext.Current.Server.MapPath(String.Format(@"{0}/{1}/", host, login));
            if (Directory.Exists(folder))
            {

                foreach (string f in Directory.GetFiles(folder))
                {
                    if (f.Contains("avatar"))
                    {
                        FileInfo fi = new FileInfo(f);
                        lock (fi)
                        {
                            fi.Delete();
                        }
                    }
                }
            }
            return false;
        }

        public static bool RemoveEventCardCompany(int eventCardId, int contractorId, int subcategoryId)
        {
            using (YourDayEntities context = new YourDayEntities())
            {
                var ecc = context.EventCardCompanies.SingleOrDefault(x => x.EventCardId == eventCardId && x.ContractorId == contractorId && x.SubcategoryId == subcategoryId);
                context.EventCardCompanies.DeleteObject(ecc);
                context.SaveChanges();
                DeleteObject<EventCardCompany>(ecc, new Comparers.EventCardCompanyComparer());
            }
            return false;
        }

    }
}
