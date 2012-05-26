using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Navigate
{
    public partial class LeftMenuBody : System.Web.UI.UserControl, ITemplate
    {
        public Dictionary<string, string> Items
        { get; set; }
      
       
        public void InstantiateIn(Control container)
        {
            RepeaterLinks.DataSource = Items;
            RepeaterLinks.DataBind();
            foreach (Control c in this.Controls)
            {
                container.Controls.Add(c);
            }
        }
    }
}