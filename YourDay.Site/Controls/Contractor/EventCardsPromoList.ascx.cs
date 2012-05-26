using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.POCO;

namespace YourDay.Site.Controls.Contractor
{
    public partial class EventCardsPromoList : System.Web.UI.UserControl
    {
        public ICollection<POCO.EventCard> EventCards
        { get; set; }
        public int ContractorId
        { get; set; }
        public string ContractorName
        { get; set; }
        public int SubcategoryId
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterEventCardPromoList.DataSource = EventCards;
            RepeaterEventCardPromoList.DataBind();
        }


        
    }
}