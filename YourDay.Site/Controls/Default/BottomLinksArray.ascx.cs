using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Default
{
    public partial class BottomLinksArray : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var MapItemsList = BLL.Get.Categories().Select(x => new { Link = BLL.Manager.GetCategoryLink(x.Id), Title = x.Title }).OrderBy(x => x.Title).ToList();
            //MapItemsList.AddRange(Constants.Strings.ContractorHeaderLinkDictionary.Select(x => new { Text = x.Key, Url = x.Value }));
            RepeaterCategoriesLinkArray.ItemDataBound += new RepeaterItemEventHandler(RepeaterCategoriesLinkArray_ItemDataBound);
            RepeaterCategoriesLinkArray.DataSource = MapItemsList;
            RepeaterCategoriesLinkArray.DataBind();

            if (YourDay.Security.MembershipUser.CurrentUser != null)
            {
                RepeaterLKLinkArray.DataSource = Constants.Strings.ContractorHeaderLinkDictionary.Select(x => new { Title = x.Key, Link = x.Value });
                RepeaterLKLinkArray.DataBind();
            }

            RepeaterProjectLinkArray.DataSource = Constants.Strings.BottomProjectLinks.Select(x => new { Title = x.Key, Link = x.Value});
            RepeaterProjectLinkArray.DataBind();

        }

        void RepeaterCategoriesLinkArray_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if ((e.Item.ItemIndex + 2) % 11 == 0)
            {
                Literal l = new Literal();
                l.Text = "</div><div style=\"float:left; padding-right:30px;\">";
                e.Item.Controls.Add(l);
            }
        }
    }
}