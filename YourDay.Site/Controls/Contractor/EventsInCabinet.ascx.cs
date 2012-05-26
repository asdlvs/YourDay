using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace YourDay.Site.Controls.Contractor
{
    public partial class EventsInCabinet : System.Web.UI.UserControl
    {

        public POCO.Contractor Contractor
        { get; set; }

        public DateTime? DateTime
        { get; set; }

        private int daysCount;
        public int DaysCount
        { 
            get { return daysCount; }
            set { daysCount = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Contractor != null ||
                (this.Contractor = (POCO.Contractor)YourDay.Security.MembershipUser.CurrentUser) != null)
            {
                var query = BLL.Get.EventCardsWithCompanies(this.Contractor.Id).SelectMany(x => x.EventCardCategories).Where(x => x.EventCardCompanies.Count > 0);

                DateTime dt = this.DateTime.HasValue ? this.DateTime.Value : System.DateTime.Now;
                daysCount = daysCount == 0 ? /*System.DateTime.DaysInMonth(dt.Year, dt.Month)*/ 1 : daysCount;

                    List<DateTime> dtList = new List<System.DateTime>();
                    dtList.Add(dt);
                    for(int i = 1; i < DaysCount; i++)
                    {
                        dt = dt.AddDays(1);
                        dtList.Add(dt.Date);
                    }
                    query = query.Where(x => dtList.Contains(x.EventCard.Date));

                RepeaterEventsInCabinet.DataSource = query;
                RepeaterEventsInCabinet.DataBind();
                DateTime Tomorrow = dt.AddDays(1);
                AnchorTomorrow.Attributes.Add("onclick", String.Format("getevents({0},{1},{2},{3});return false;", Tomorrow.Date.Year, Tomorrow.Date.Month, Tomorrow.Date.Day, 1));
                DateTime Yesterday = dt.AddDays(-1);
                AnchorYesterday.Attributes.Add("onclick", String.Format("getevents({0},{1},{2},{3});return false;", Yesterday.Date.Year, Yesterday.Date.Month, Yesterday.Date.Day, 1));

            }
        }
    }
}