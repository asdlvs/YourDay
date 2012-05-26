using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor
{
    public partial class ContractorCabinetUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelTitle.Text = Constants.Strings.MyEvents;
            LabelEvent.Text = Constants.Strings.Event;
            LabelSpecialization.Text = Constants.Strings.Specialization;
            LabelPaymentStatus.Text = Constants.Strings.PaymentStatus;
            LabelTime.Text = Constants.Strings.Time;

            List<object> dayFilters = new List<object>();
            DateTime ddt = DateTime.Now;
            dayFilters.Add(new { Year = ddt.Year, Month = ddt.Month, Date = ddt.Day, Count = 1, Title = "на день" });
            dayFilters.Add(new { Year = ddt.Year, Month = ddt.Month, Date = ddt.Day, Count = 3, Title = "на 3 дня" });
            dayFilters.Add(new { Year = ddt.Year, Month = ddt.Month, Date = ddt.Day, Count = 7, Title = "на неделю" });

            RepeaterDayFilter.DataSource = dayFilters;
            RepeaterDayFilter.DataBind();

        }
    }
}