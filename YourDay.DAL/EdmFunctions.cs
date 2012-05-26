using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Objects;

namespace YourDay.DAL
{
    public static class EdmFunctions
    {
        [EdmFunction("YourDayModel.Store", "GetRelationIdFromKey")]
        public static int GetRelationIdFromKey(string key, int type)
        {
            throw new Exception();
           // ObjectQuery<int> result = base.CreateQuery<int>("SELECT VALUE YourDay_v4.dbo.GetRelationIdFromKey('@key', @type)", new ObjectParameter("key", key), new ObjectParameter("type", type));//base.ExecuteFunction<int>("GetRelationIdFromKey", new ObjectParameter("key", key), new ObjectParameter("type", type));
            //return result;
        }
    }
}
