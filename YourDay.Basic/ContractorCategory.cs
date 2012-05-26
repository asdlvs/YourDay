using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class ContractorCategory
    {
        public int ContractorId
        { get; set; }
        public int SubcategoryId
        { get; set; }
        public int OurLevel
        { get; set; }
        public int CommonLevel
        { get; set; }
        public Contractor Contractor
        { get; set; }
        public SubCategory SubCategory
        { get; set; }
        public ICollection<EventCard> EventCards
        { get; set; }
        public ICollection<EventCardCompany> EventCardCompanies
        { get; set; }
       
    }
}
