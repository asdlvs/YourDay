using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site
{
    public partial class EventCardPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ecId;
            if(!Int32.TryParse(Request.QueryString["id"], out ecId))
                return;
            YourDay.POCO.EventCard currentEventCard = Get.EventCard(ecId);
            EventCardHeader1.EventCard = currentEventCard;
            EventCardBody1.EventCard = currentEventCard;

        }
    }
}