using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YourDay.Site
{
    public class QueryStringManager
    {
        public static int? GetQueryStringParam(string param)
        {
            int paramId;
            object paramIdObject;

            if ((paramIdObject = HttpContext.Current.Request.QueryString[param]) != null)
            {
                if (Int32.TryParse(paramIdObject.ToString(), out paramId))
                {
                    return paramId;
                }
            }

            return null;
        }
    }
}