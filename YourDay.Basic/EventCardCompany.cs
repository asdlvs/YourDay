using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class EventCardCompany
    {
        public int EventCardId
        { get; set; }

        public int ContractorId
        { get; set; }

        public int SubcategoryId
        { get; set; }

        public int State
        { get; set; }

        public ContractorCategory ContractorCategory
        { get; set; }

        public EventCard EventCard
        { get; set; }

        List<Media> media = new List<Media>();
        public ICollection<Media> Medias
        { 
            get { return media; } 
            //set { media = value; } 
        }

        public EventCardCategory EventCardCategory
        { get; set; }

        public string RelationKey
        { get; set; }

        
    }
}
