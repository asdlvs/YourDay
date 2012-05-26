using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace YourDay.Site.Controls.Navigate
{
    public partial class CategoriesMenuSimple : System.Web.UI.UserControl
    {

        private Dictionary<string, string> dataSource = new Dictionary<string, string>();
        public Dictionary<string, string>DataSource
        {
            get { return dataSource; }
            set { dataSource = value; dataSourceCount = dataSource.Count; }
        }
        private int dataSourceCount;
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterItems.ItemDataBound += new RepeaterItemEventHandler(RepeaterCategories_ItemDataBound);
            RepeaterItems.DataSource = DataSource;
            RepeaterItems.DataBind();
        }

        void RepeaterCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                LeftMenuHeader header = (LeftMenuHeader)e.Item.FindControl("LeftMenuHeaderItem");
                header.Class = "header top";
            }
            if (e.Item.ItemIndex == dataSourceCount - 1)
            {
                LeftMenuHeader header = (LeftMenuHeader)e.Item.FindControl("LeftMenuHeaderItem");
                header.Class = "header bottom";
            }
        }
    }
}