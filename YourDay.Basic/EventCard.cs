using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YourDay.POCO
{
    public class EventCard
    {
        public int Id
        { get; set; }
        public string Title
        { get; set; }
        public int Creator
        { get; set; }
        public User User
        { get; set; }

        public ICollection<EventCardCategory> EventCardCategories
        { get; set; }
        public DateTime Date
        { get; set; }
        public int Type
        { get; set; }
        public string StartTime
        { get; set; }
        public string EndTime
        { get; set; }
        public string Description
        { get; set; }
        public decimal Budjet
        { get; set; }
        public int WhoSee
        { get; set; }
        public bool ShowToEventAgency
        { get; set; }
        public bool ShowToContractors
        { get; set; }
        public EventCardType EventCardType
        { get; set; }
    }
}
