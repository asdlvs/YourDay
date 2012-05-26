using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Default
{
    public partial class News : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterNews.DataSource = BLL.Get.News().Take(4).Select(x => new { 
                Title = x.Title,
                Content = BLL.Manager.GetShortContent(x.Content, 25),
                Url = BLL.Manager.GetNewsLink(x.Id)
            });
            RepeaterNews.DataBind();

        }
    }
}