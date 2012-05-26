using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.POCO;

namespace YourDay.Site.Controls.Catalog
{
    public partial class ContractorList : System.Web.UI.UserControl
    {
        public const int TopContractorsCount = 5;
        public const int OtherContractorsCount = 10;

        public int SubCategoryId
        { get; set; }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            SubCategory sc = BLL.Get.SubCategory(SubCategoryId);
            YourDay.POCO.Contractor[] contractors = BLL.Get.Contractors(sc.Id);
            RepeaterTopContactors.DataSource = contractors.Take(TopContractorsCount);
            RepeaterTopContactors.DataBind();

            RepeaterOtherContractors.DataSource = contractors.Skip(TopContractorsCount).Take(OtherContractorsCount);
            RepeaterOtherContractors.DataBind();

        }
    }
}