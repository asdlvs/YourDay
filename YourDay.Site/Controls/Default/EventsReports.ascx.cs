using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Default
{
    public partial class EventsReports : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelTitle.Text = Constants.Strings.EventReports;
            LabelArticles.Text = Constants.Strings.Article;
            LabelNews.Text = Constants.Strings.News;
        }
    }
}