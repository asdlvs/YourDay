using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Navigate
{
    public partial class LeftMenuHeader : System.Web.UI.UserControl, ITemplate
    {

        public string Title
        { get; set; }
        public string Href
        { get; set; }

        private bool withSubcategories = true;

        public bool WithSubcategories
        {
            get { return withSubcategories; }
            set { withSubcategories = value; }
        }


        private string varClass = "header";
        public string Class
        {
            get { return varClass; }
            set { varClass = value;}
        }


        public void Page_Load(object sender, EventArgs e)
        {
            if (!withSubcategories)
            {
                HyperLink hpl = new HyperLink();
                hpl.Text = Title;
                hpl.NavigateUrl = Href;
                hpl.Width = Unit.Percentage(100);
                hpl.Height = Unit.Percentage(100);
                DivHeader.Controls.Add(hpl);
                DivHeader.Attributes.Add("class", varClass);
            }
        }

        public void InstantiateIn(Control container)
        {
            if (withSubcategories)
            {
                Label LabelTitle = new Label();
                LabelTitle.Text = Title;
                DivHeader.Controls.Add(LabelTitle);
                DivHeader.Attributes.Add("class", Class);
                foreach (Control c in this.Controls)
                {
                    container.Controls.Add(c);
                }
            }
        }
    }
}