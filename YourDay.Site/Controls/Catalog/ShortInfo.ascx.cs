using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site.Controls.Catalog
{
    public partial class ShortInfo : System.Web.UI.UserControl
    {
        public POCO.Contractor Contractor
        { get; set; }

        public int SubcategoryId
        { get; set; }

        private bool isShort = true;

        public bool IsShort
        {
            get { return isShort; }
            set { isShort = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            int? s;
            if ((s = QueryStringManager.GetQueryStringParam("subcategory")) != null)
            {
                SubcategoryId = (int)s;
                FillContractorData();
            }

        }

        private void FillContractorData()
        {
            if (isShort)
            {
                shortInfoDiv.Attributes["class"] = "addinfo shortinfo";
                shortInfoContentDiv.Attributes["class"] = "shortInfoContentDiv";
            }
            else
                shortInfoDiv.Attributes["class"] = "addinfo";

            avatar.Src = this.Contractor.GetAvatarImage(52);//.AvatarSrc;;

            HyperLinkName.Text = this.Contractor.FullName;
            HyperLinkName.NavigateUrl = BLL.Manager.GetContractorSubcategoryLink(this.SubcategoryId, this.Contractor.Id);
            LabelSpecialization.Text = Constants.Strings.Specialization;
            LabelSpecializationsLink.Text = UIManager.CreateLinks(Contractor);

            LabelOnlineStatus.Text = Constants.Strings.OnLineStatus;
            //LabelOnlineStatusValue.Text =
            //    this.Contractor.UserActivities.Last().EventStatus == (int)Constants.Enums.ContractorStatus.Online
            //    ? Constants.String.OnLineStatusOnLine : Constants.String.OnLineStatusOffLine;

            LabelFeedbacks.Text = Constants.Strings.Feedbacks;
            //TODO:Comments
            //HyperLinkPositiveFeedbacks.Text = this.Contractor.ContractorCategories.Single(x => x.SubcategoryId == SubcategoryId).ContractorSubcategoryComments.Where(x => x.StarsCount > 3).Count().ToString();
            //HyperLinkNegativeFeedbacks.Text = this.Contractor.ContractorCategories.Single(x => x.SubcategoryId == SubcategoryId).ContractorSubcategoryComments.Where(x => x.StarsCount <= 3).Count().ToString();

            LabelEvents.Text = Constants.Strings.Events;
            HyperLinkEvents.Text = BLL.Get.EventCards(this.Contractor.Id, SubcategoryId).Length.ToString();

            LabelCity.Text = Constants.Strings.City;
            HyperLinkCity.Text = this.Contractor.City.Title;
            HyperLinkCity.NavigateUrl = HyperLinkCity.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.Strings.CityLink, this.Contractor.City.Id.ToString());

            LabelRating.Text = Constants.Strings.Rating;
        }
    }
}
