using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Default
{
    public partial class BestContractors : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lobsterTitle.InnerHtml = BLL.Manager.GetBestsTitle(BLL.Admin.DefaultSubcategoryForTopSix());
            DataListBestContractors.ItemDataBound += new DataListItemEventHandler(DataListBestContractors_ItemDataBound);
            DataListBestContractors.DataSource = BLL.Manager.GetTopSixOnMain(BLL.Admin.DefaultSubcategoryForTopSix());
            DataListBestContractors.DataBind();
        }

        void DataListBestContractors_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            switch (e.Item.ItemType)
            {
                case ListItemType.Item:
                case ListItemType.AlternatingItem:
                    BestContractor one = (BestContractor)e.Item.FindControl("BestContractorsItem");
                    one.No = e.Item.ItemIndex + 1;
                    one.Contractor = (POCO.Contractor)e.Item.DataItem;
                    one.SubcategoryId = BLL.Admin.DefaultSubcategoryForTopSix();
                    break;
            }


        }
    }
}