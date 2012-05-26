using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Default
{
    public partial class LastArticles : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterArticles.DataSource = BLL.Get.Articles()
                .Take(2)
                .Select(x => new { 
                    Path = BLL.Manager.GetArticleThumbImg(x.Id, true),
                    Alt = x.Title,
                    Title = x.Title,
                    Url = BLL.Manager.GetArticleLink(x.Id),
                    Content = BLL.Manager.GetShortContent(x.Content, 50)
                });
            RepeaterArticles.DataBind();
            
        }
    }
}