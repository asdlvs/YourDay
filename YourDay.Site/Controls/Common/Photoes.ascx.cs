using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.POCO;

namespace YourDay.Site.Controls.Common
{
    public partial class Photoes : System.Web.UI.UserControl
    {
        public POCO.Media[] DataSource
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (DataSource != null)
            {
                RepeaterPhotoes.DataSource = this.DataSource.Select(x => new { Path = BLL.Manager.GetContractorThumbPhoto(BLL.Get.Contractor(Int32.Parse(x.RelationId.Split('|')[1])).Login, x.Name, 100, 100), Alt = x.Name });
                RepeaterPhotoes.DataBind();
            }
        }
    }
}