using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site.Controls.Contractor
{
    public partial class OfferEventCardCatalog : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            POCO.Contractor c = BLL.Get.Contractor(YourDay.Security.MembershipUser.CurrentUser.Id);

            List<POCO.EventCard> ds = new List<POCO.EventCard>();
            string scQs = Request.QueryString["sc"];
            int scId;
            if (!String.IsNullOrEmpty(scQs) && Int32.TryParse(scQs, out scId))
            {
                foreach (POCO.ContractorCategory cc in c.ContractorCategories.Where(x => x.SubcategoryId.Equals(scId)).Take(10))
                {
                    ds.AddRange(BLL.Get.EventCards(cc.SubcategoryId));
                }
            }
            else
            {
                foreach (POCO.ContractorCategory cc in c.ContractorCategories)
                {
                    ds.AddRange(BLL.Get.EventCards(cc.SubcategoryId));
                }
            }
            var dataSource = ds.Distinct()
                .Select(x => new
                {
                    Title = x.Title,
                    Price = String.Format("{0} руб.", x.Budjet),
                    Description = x.Description,
                    PublishedDate = x.Date,
                    Requests = 0,
                    Link = Manager.GetEventCardLink(x.Id)

                });
            RepeaterOfferEventCards.DataSource = dataSource;
            hiddenFieldEventsCurrentCount.Value = dataSource.Count().ToString();
            RepeaterOfferEventCards.DataBind();
        }
    }
}