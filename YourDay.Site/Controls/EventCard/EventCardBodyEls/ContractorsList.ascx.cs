using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace YourDay.Site.Controls.EventCard
{
    public partial class ContractorsList : System.Web.UI.UserControl
    {

        public YourDay.POCO.EventCardCompany[] DataSource
        { get; set; }
        public string Title
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelTitle.Text = this.Title;
            DataListContractors.DataSource = 
                this.DataSource.Select(x => new { 
                    Avatar = BLL.Manager.GetUserAvatar(x.ContractorId, 50), 
                    Alt = String.Format("{0} - {1}", BLL.Get.SubCategory(x.SubcategoryId), BLL.Get.Contractor(x.ContractorId).FullName),
                    Link = BLL.Manager.GetContractorSubcategoryLink(x.SubcategoryId, x.ContractorId),
                    FullName = BLL.Get.Contractor(x.ContractorId).FullName,
                    scId = x.SubcategoryId,
                    Specialization = BLL.Get.SubCategory(x.SubcategoryId).Title
                });
            DataListContractors.DataBind();
        }
    }
}