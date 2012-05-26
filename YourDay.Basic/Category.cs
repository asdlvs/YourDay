using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class Category
    {
        public int Id
        { get; set; }

        public string Title
        { get; set; }

        public decimal Weight
        { get; set; }

        public ICollection<SubCategory> SubCategories
        { get; set; }
    }
}
