using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site.Controls.EventCard
{
    public partial class EventCardHeader : System.Web.UI.UserControl
    {
        public YourDay.POCO.EventCard EventCard { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.EventCard == null)
                return;

            HyperLinkCreator.Text = Get.User(EventCard.Creator).FullName;
            HyperLinkEventType.Text = EventCard.EventCardType.Title;
            HyperLinkDate.Text = EventCard.Date.ToShortDateString();
            LiteralTime.Text = String.Format("с {0} до {1}", EventCard.StartTime, EventCard.EndTime);
            HyperLinkCity.Text = "Санкт-Петербург";
            LabelBudjet.Text = String.Format("{0} руб.", ((int)EventCard.Budjet).ToString());

            LabelEventName.Text = EventCard.Title;
            LiteralDescription.Text = EventCard.Description;

            RepeaterCategories.DataSource = EventCard.EventCardCategories.Select(x => new { Id = x.SubcategoryId, Title = Get.SubCategory(x.SubcategoryId).Title });
            RepeaterCategories.DataBind();
        }

        protected void LinkButtonBeginContractorsSelection_Click(object sender, EventArgs e)
        {
            Session["eventCardSelection"] = this.EventCard.Id;
            int firstSc = this.EventCard.EventCardCategories.First().SubcategoryId;
            Response.Redirect(BLL.Manager.GetSubcategoryLink(firstSc));
        }
    }
}