using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Default
{
    public partial class LastVideo : System.Web.UI.UserControl
    {
        public POCO.Media Video
        { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}