using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
   public class City
    {
       public int Id
       { get; set; }
       public string Title
       { get; set; }
       public ICollection<Contractor> Contractors
       { get; set; }
      
    }
}
