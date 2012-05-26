using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class Media
    {
        public int Id
        { get; set; }
        public string Name
        { get; set; }
        public string RelationId
        { get; set; }
        public /*MediaRelationType*/ int RelationType
        { get; set; }
        public int Type
        { get; set; }
        public string Description
        { get; set; }

        public EventCardCompany EventCardCompany
        { get; set; }

       
        public ICollection<MediaRate> MediaRates
        { get; set; }
    }
}
