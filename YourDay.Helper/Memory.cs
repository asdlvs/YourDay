using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Collections;

namespace YourDay.Helper
{
    public class Memory
    {
        public static IEnumerable<object> ShowCache()
        {
            Cache cache = HttpContext.Current.Cache;
            IDictionaryEnumerator e = cache.GetEnumerator();
            while (e.MoveNext())
            {
                yield return e.Current;
            }
        }
    }
}
