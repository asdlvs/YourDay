using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor
{
    public partial class CalendarShort : System.Web.UI.UserControl
    {
        public POCO.Contractor Contractor
        { get; set; }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Contractor != null ||
                (this.Contractor = (POCO.Contractor)YourDay.Security.MembershipUser.CurrentUser) != null)
            {
                //TODO: ХК
                Context.Items["ContractorsEventCardCompanies"] = BLL.Get.EventCardCompanies(this.Contractor.Id);

                

                var dates = Enumerable.Range
                (
                 1, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).
                 Select(tempDay => new DateTime(
                    DateTime.Now.Year, DateTime.Now.Month, tempDay)
                );

                List<ContractorsDay> month = new List<ContractorsDay>();
               
                foreach (var date in dates)
                    month.Add(new ContractorsDay(this.Contractor, date));

                RepeaterCalendar.DataSource = month;
                RepeaterCalendar.DataBind();

            }
        }
    }
}