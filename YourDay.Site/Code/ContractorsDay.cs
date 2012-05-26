using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace YourDay.Site
{
    public partial class ContractorsDay
    {
        public ContractorsDay(POCO.Contractor contractor, DateTime date)
        {
            this.Contractor = contractor;
            this.Date = date;
            IsToday = date.Date.Equals(DateTime.Today);
            int dayOfWeek = (int)date.DayOfWeek;
            Tuple<int, string, string> dayTuple = Constants.Strings.Days.First(x => x.Item1 == dayOfWeek);
            this.ShortTitle = dayTuple.Item3;
            this.FullTitle = dayTuple.Item2;
            this.IsPast = (DateTime.Today - date.Date) > TimeSpan.Zero;

            this.IsBlock = contractor.ClosedDays.Any(x => x.Date.Equals(date.Date));

            if (!this.IsBlock)
            {
                this.MorningShift = GetShiftsEventCard(contractor.Id, date.Date, (int)Constants.Enums.Shifts.Morning);
                this.DayShift = GetShiftsEventCard(contractor.Id, date.Date, (int)Constants.Enums.Shifts.Day);
                this.NigthShift = GetShiftsEventCard(contractor.Id, date.Date, (int)Constants.Enums.Shifts.Night);
                 
            }

            var holeDayEcs = this.NigthShift.Intersect(this.MorningShift);
            this.DayShift.AddRange(holeDayEcs);

            this.IsEmpty = (NigthShift.Count + MorningShift.Count + DayShift.Count) == 0;
            MessagesCount = BLL.Get.NewMessagesCount(contractor, date);
           /* var newMessages = ((POCO.Comment[])HttpContext.Current.Items["NewMessages"])
                 .Where(x => x.Type == (int)Constants.Enums.CommentsType.PrivateMessageToContractor)
                 .Select(x => x.RelationId);

           var eventCards = ((POCO.EventCard[])HttpContext.Current.Items["contractorEcs"]).Where(x => x.Date.Equals(date)).Select(x => x.Id);
          foreach(var m in newMessages)
              if (eventCards.Any(x => x.Equals(m)))
                    this.MessagesCount++;*/
        }

        #region Properties
        public POCO.Contractor Contractor
        { get; set; }
        public DateTime Date
        { get; set; }
        public string FullTitle
        { get; set; }
        public string ShortTitle
        { get; set; }
        public bool IsToday
        { get; set; }
        public List<POCO.EventCard> NigthShift //19 - 02 -> 0
        { get; set; }
        public List<POCO.EventCard> MorningShift //2 - 10 -> 1
        { get; set; }
        public List<POCO.EventCard> DayShift // 10 - 19 -> 2
        { get; set; }
        public bool IsPast
        { get; set; }
        public bool IsBlock
        { get; set; }
        public int MessagesCount
        { get; set; }
        public bool IsEmpty
        { get; set; }
        #endregion


        //TODO: Убрать хардкод
        private bool CheckEventCardDayPeriod(POCO.EventCard ec, int period)
        {
            TimeSpan startDate = TimeSpan.Parse(ec.StartTime);
            TimeSpan endDate = TimeSpan.Parse(ec.EndTime);

            TimeSpan startPeriodDate = new TimeSpan();
            TimeSpan endPeriodDate = new TimeSpan();

            switch (period)
            { 
                
                case 0:
                    startPeriodDate = TimeSpan.Parse("00:00");
                    endPeriodDate = TimeSpan.Parse("07:59");
                    break;
                case 1:
                    startPeriodDate = TimeSpan.Parse("08:00");
                    endPeriodDate = TimeSpan.Parse("16:59");
                    break;
                case 2:
                    startPeriodDate = TimeSpan.Parse("17:00");
                    endPeriodDate = TimeSpan.Parse("23:59");
                    break;
            }

            return 
                (startPeriodDate <= startDate && endPeriodDate >= startDate) 
                || 
                (startPeriodDate <= endDate && endPeriodDate >= endDate);

        }

        private List<POCO.EventCard> GetShiftsEventCard(int contractorId, DateTime date, int shiftId)
        {
            if (HttpContext.Current.Items["contractorEcs"] == null)
                HttpContext.Current.Items["contractorEcs"] = BLL.Get.EventCardsWithCompanies(contractorId);
            return ((POCO.EventCard[])HttpContext.Current.Items["contractorEcs"])
                    .Where(x => x.Date.Equals(date) && CheckEventCardDayPeriod(x, shiftId))
                    .ToList();
        }
    }


}