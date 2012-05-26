using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class Contractor : User
    {
       
        public string Site
        { get; set; }

        public string VK
        { get; set; }

        public string Facebook
        { get; set; }

        public string Twitter
        { get; set; }

        public string Description
        { get; set; }

        public string Additional
        { get; set; }

        public ICollection<ContractorCategory> ContractorCategories
        { get; set; }

        public int CityId
        { get; set; }

        public City City
        { get; set; }

        
        public bool Activate
        { get; set; }

        public string Phone
        { get; set; }

        
        public ICollection<Article> Articles
        { get; set; }

        public ICollection<ClosedDay> ClosedDays
        { get; set; }


       
    }
}
