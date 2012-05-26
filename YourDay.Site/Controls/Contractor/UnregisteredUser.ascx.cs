using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.Constants;

namespace YourDay.Site.Controls.Contractor
{
    public partial class UnregisteredUser : System.Web.UI.UserControl
    {

       
        public string FullName
        { get; set; }
        public Tuple<int, string> City
        {
            get;
            set;
        }
        public string SpecializationLinks
        {
            get;
            set;
        }

        public int EventCardsCount
        { get; set; }
        public string Login
        { get; set; }
        public int PositiveCommentsCount
        { get; set; }
        public int NegativeCommentsCount
        { get; set; }
        public string Phone
        { get; set; }
        public string Site
        { get; set; }
        public string Mail
        { get; set; }
        public string VK
        { get; set; }
        public string Facebook
        { get; set; }
        public string Twitter
        { get; set; }

        public string Description
        { get; set; }

        public string Additional
        { get; set; }

        public int ContractorId
        { get; set; }
        public int SubCategoryId
        { get; set; }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelFullName.Text = FullName;

            LabelCity.Text = YourDay.Constants.Strings.City;
            HyperLinkCity.Text = City.Item2;
            HyperLinkCity.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.Strings.CityLink, City.Item1.ToString());

            LabelEvents.Text = YourDay.Constants.Strings.Events;
            LabelFeedbacks.Text = YourDay.Constants.Strings.Feedbacks;
            LabelRating.Text = YourDay.Constants.Strings.Rating;
            LabelSpecialization.Text = YourDay.Constants.Strings.Specialization;
            LabelSpecializationsLink.Text = SpecializationLinks;

            HyperLinkEvents.Text = EventCardsCount.ToString();

            HyperLinkPositiveFeedbacks.Text = PositiveCommentsCount.ToString();
            HyperLinkNegativeFeedbacks.Text = NegativeCommentsCount.ToString();


            HtmlLinkPlus.InnerText = YourDay.Constants.Strings.AddToEvent;
            HtmlLinkPlus.HRef = "#";
            HtmlLinkPlus.Attributes.Add("onclick", String.Format("JavaScript:{0}({1},{2}, false);return false;", Constants.Strings.JS.AddToEC, ContractorId, SubCategoryId));

            HtmlLinkFavourite.InnerText = YourDay.Constants.Strings.AddToFavourites;
            HtmlLinkFavourite.HRef = "#";
            HtmlLinkFavourite.Attributes.Add("onclick", String.Format("JavaScript:{0}({1},{2});return false;", Constants.Strings.JS.AddToFavourite, ContractorId, (int)Enums.FavouriteType.Contractor));

            HtmlLinkPrice.InnerText = YourDay.Constants.Strings.LoadPrice;
            HtmlLinkPrice.HRef = "#";
            HtmlLinkPrice.Attributes.Add("onclick", String.Format("JavaScript:{0}({1},{2});return false;", Constants.Strings.JS.LoadPrice, ContractorId, SubCategoryId));

            HtmlLinkSend.InnerText = YourDay.Constants.Strings.SendMessage;
            HtmlLinkSend.HRef = "#";
            HtmlLinkSend.Attributes.Add("onclick", String.Format("JavaScript:{0}({1},{2});return false;", Constants.Strings.JS.SendMessage, ContractorId, SubCategoryId));

            LabelContactInfoTitle.Text = YourDay.Constants.Strings.ContactInfoTitle;
            if (!String.IsNullOrEmpty(this.Phone))
            {
                LabelPhone.Text = String.Format("{0}{1}<br />", YourDay.Constants.Strings.Telephone, this.Phone);
            }
            else
            {
                LabelPhone.Visible = false;
            }

            if (this.Mail != String.Empty)
            {
                LabelMail.Text = YourDay.Constants.Strings.Mail;
                HyperLinkMail.NavigateUrl = String.Format("mailto:{0}", this.Mail);
                HyperLinkMail.Text = String.Format("{0}<br />", this.Mail);
            }
            else
            {
                LabelMail.Visible = false;
            }

            SetValueOrMakeUnvisible(LabelSite, HyperLinkSite, YourDay.Constants.Strings.Site, this.Site);

            SetValueOrMakeUnvisible(LabelVK, HyperLinkVK, YourDay.Constants.Strings.VK, this.VK);

            SetValueOrMakeUnvisible(LabelFacebook, HyperLinkFacebook, YourDay.Constants.Strings.Facebook, this.Facebook);

            SetValueOrMakeUnvisible(LabelTwitter, HyperLinkTwitter, YourDay.Constants.Strings.Twitter, this.Twitter);

            LabelDescriptionTitle.Text = YourDay.Constants.Strings.DescriptionTitle;
            LabelDescriptionBody.Text = this.Description;

            AdditionalTitle.Text = YourDay.Constants.Strings.AdditionalTitle;
            AdditionalBody.Text = this.Additional;

            avatar.Src = BLL.Manager.GetUserAvatar(Login, 100);
            avatar.Alt = Login;

        }

        private void SetValueOrMakeUnvisible(Label label, HyperLink hpl, string lValue, string hplValue)
        {
            if (!String.IsNullOrEmpty(hplValue))
            {
                hpl.Text = String.Format("{0}<br />", hplValue);
                hpl.NavigateUrl = hplValue;
                label.Text = lValue;
            }
            else
            {
                label.Visible = false;
                hpl.Visible = false;
            }
        }
    }
}