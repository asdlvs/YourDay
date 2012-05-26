using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site
{
    public partial class ContractorCabinet : System.Web.UI.Page
    {
        protected void Page_Init()
        { 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MenuSimple1.DataSource = Constants.Strings.ContractorHimselfLeftLinks;
        }
    }
}