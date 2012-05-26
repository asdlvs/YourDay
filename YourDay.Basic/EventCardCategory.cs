using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class EventCardCategory
    {
        public int EventCardId
        { get; set; }
        public int SubcategoryId
        { get; set; }
        public decimal Budjet
        { get; set; }
        public string StartTime
        { get; set; }
        public string EndTime
        { get; set; }
        public EventCard EventCard
        { get; set; }
        public SubCategory SubCategory
        { get; set; }
        public ICollection<EventCardCompany> EventCardCompanies
        { get; set; }
    }
}
