using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using YourDay.BLL;
using System.Configuration;

namespace YourDay.Site.Controls.Navigate
{
    public partial class CategoriesMenu : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            AccordionCategories.HeaderSelectedCssClass = "selected";
            AccordionCategories.RequireOpenedPane = false;


            var categories = Get.Categories();
            int i = 0;
            int? selected = null;
            foreach (var category in categories)
            {
                LeftMenuHeader header = (LeftMenuHeader)LoadControl("LeftMenuHeader.ascx");
                if (i == 0)
                {
                    header.Class = "header top";
                }
                else if (i == categories.Length - 1)
                {
                    header.Class = "header bottom";
                }
                header.ID = Guid.NewGuid().ToString();
                header.Title = category.Title;


                LeftMenuBody body = (LeftMenuBody)LoadControl("LeftMenuBody.ascx");
                body.ID = Guid.NewGuid().ToString();
                Dictionary<string, string> subcategories = category.SubCategories.ToDictionary(x => BLL.Manager.GetSubcategoryLink(x.Id), x => x.Title);

                int selectedCategoryId;
                if (Request.QueryString["subcategory"] != null && Int32.TryParse(Request.QueryString["subcategory"].ToString(), out selectedCategoryId))
                {
                    if (subcategories.Keys.Contains(BLL.Manager.GetSubcategoryLink(selectedCategoryId)))
                    {
                        selected = i;
                    }
                }

                body.Items = subcategories;


                AccordionPane pane = new AccordionPane();
                pane.ID = Guid.NewGuid().ToString();
                pane.Header = (ITemplate)header;
                pane.Content = (ITemplate)body;

                AccordionCategories.Panes.Add(pane);

                i++;
            }
            if (selected != null)
                AccordionCategories.SelectedIndex = (int)selected;
        }

    }

}