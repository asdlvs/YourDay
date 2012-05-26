using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.EventCard
{
    public partial class ContractorsSelection : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object o = HttpContext.Current.Session["eventCardSelection"];
            object scategory = Request.QueryString["subcategory"];
            if (o != null && scategory != null)
            {
                int sc = Int32.Parse(scategory.ToString());
                RepeaterSelectedContractors.DataSource = BLL.Get.EventCardCompanies((int)o, sc)
                    .Select(
                    x => new
                    {
                        Name = BLL.Get.Contractor(x.ContractorId).FullName,
                        Avatar = BLL.Manager.GetUserAvatar(BLL.Get.Contractor(x.ContractorId).Login, 30),
                        Link = "123",
                        Specialization = BLL.Get.SubCategory(sc).Title,
                        Id = x.ContractorId,
                        Sc = sc

                    });
                RepeaterSelectedContractors.DataBind();
            }
            else
            {
                divContractorSelection.Visible = false;
            }
        }
    }
}