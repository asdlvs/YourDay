using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourDay.POCO;
using YourDay.DAL;

namespace YourDay.BLL
{
    public class MediaHelper
    {
        public static int GetRelationIdFromKey(string key, MediaEventCardCompanySplitterType type)
        {
            return Int32.Parse(key.Split('|')[(int)type]);
        }

        public static bool IsRelated(string key, int id, MediaEventCardCompanySplitterType type)
        {
            return Int32.Parse(key.Split('|')[(int)type]).Equals(id);
        }

    }

    public enum MediaEventCardCompanySplitterType
    { 
        EventCardId = 0,
        ContractorId = 1,
        SubcategoryId = 2
    }
}
