using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor
{
    public partial class EventInCabinet : System.Web.UI.UserControl
    {

        public POCO.EventCardCategory EventCardCategory
        {
            get;
            set;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (this.EventCardCategory != null)
            {
                int contractorId = YourDay.Security.MembershipUser.CurrentUser.Id;
                POCO.EventCard ec = this.EventCardCategory.EventCard;
                POCO.EventCardCompany ecCompany = this.EventCardCategory.EventCardCompanies.First(x => x.ContractorId == contractorId);
                
                HyperLinkTitle.Text = ec.Title;
                HyperLinkTitle.NavigateUrl = "#";//BLL.Manager.GetEventCardLink(ec.Id);

                LabelSpecialization.Text = BLL.Get.SubCategory(this.EventCardCategory.SubcategoryId).Title;//this.EventCardCategory.SubCategory.Title;//UIManager.CreateLinks((POCO.Contractor)BLL.Manager.CurrentUser, this.EventCardCategory.EventCard);

                DropDownListStatus.Attributes.Add("onchange", String.Format("changeecstatus({0},{1},{2}, this);", contractorId, ec.Id, this.EventCardCategory.SubcategoryId));
                DropDownListStatus.DataSource = Constants.Strings.EventCardCompanyStatuses;
                DropDownListStatus.DataBind();
               
                DropDownListStatus
                    .Items
                    .FindByValue(ecCompany.State.ToString()).Selected = true;

                LabelTime.Text = String.Format("{0} - {1}", ec.StartTime, ec.EndTime);

                LiteralAuthor.Text = Constants.Strings.Orderer;
                POCO.User usr = BLL.Get.User(ec.Creator);
                HyperlinkAuthor.Text = usr.FullName;
                if (usr.GetType() == typeof(POCO.Contractor))
                    HyperlinkAuthor.NavigateUrl = BLL.Manager.GetContractorSubcategoryLink(this.EventCardCategory.SubcategoryId, usr.Id);

                LiteralCity.Text = String.Format("{0}{1}", Constants.Strings.City, "");
                LiteralCity.Visible = false;

                LiteralDescription.Text = ec.Description;

                RepeaterMessages.DataSource = BLL.Get.PrivateEventCardMessages(contractorId, ec.Id, 2).Select(x => new
                {
                    Author = BLL.Get.User(x.AuthorId).FullName,
                    Url = String.Empty,
                    Message = x.Text,
                    Time = x.DateTime.ToShortTimeString()

                });
                RepeaterMessages.DataBind();

                anchorSendMessage.Attributes.Add("onclick", String.Format("sendmessage({0},{1}, this, false,2);return false;", ec.Id, ec.Creator));
            }
        }
    }
}