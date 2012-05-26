using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site.Controls.Default
{
    public partial class BestContractor : System.Web.UI.UserControl
    {
        public POCO.Contractor Contractor
        { get; set; }

        public int SubcategoryId
        { get; set; }

        public int No
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelNo.Text = String.Format("{0}.", No);

            HyperLinkName.Text = this.Contractor.FullName;
            HyperLinkName.NavigateUrl = BLL.Manager.GetContractorSubcategoryLink(this.SubcategoryId, this.Contractor.Id);

            //TODO: Везде вынести стандиртный размер аватара
            avatar.Src = Contractor.GetAvatarImage(52);//.AvatarSrc;//BLL.Manager.GetUserAvatar(this.Contractor.Login, 50);
            avatar.Alt = Contractor.FullName;

            //TODO: ПЕревести на Membership
           // LabelOnlineStatus.Text = Constants.String.OnLineStatus;
            //LabelOnlineStatusValue.Text =
            //    this.Contractor.UserActivities.Last().EventStatus == (int)Constants.Enums.ContractorStatus.Online
            //    ? Constants.String.OnLineStatusOnLineWithoutColor : Constants.String.OnLineStatusOffLineWithoutColor;
        
        }

    }
}