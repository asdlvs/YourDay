using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class ClosedDay
    {
        public int Id
        { get; set; }
        public int ContractorId
        { get; set; }
        public DateTime Date
        { get; set; }
        public Contractor Contractor
        { get; set; }
    }
}
