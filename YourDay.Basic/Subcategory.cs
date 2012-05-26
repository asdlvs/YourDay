using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class SubCategory
    {
        public int Id
        { get; set; }

        public string Title
        { get; set; }

        public int CategoryId
        { get; set; }

        public decimal Weight
        { get; set; }

        public Category Category
        {
            get;
            set;
        }
        public string Persons
        { get; set; }

        public ICollection<ContractorCategory> ContractorCategories
        { get; set; }

        public ICollection<EventCardCategory> EventCardCategories
        { get; set; }

    }
}
