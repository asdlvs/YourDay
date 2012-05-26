using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace YourDay.Site.Controls.Contractor
{
    public partial class UCContractor : System.Web.UI.UserControl
    {

        public YourDay.POCO.Contractor CurrentContractor
        { get; set; }

        public int SubcategoryId
        { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            UnregisteredUser.FullName = CurrentContractor.FullName;
            UnregisteredUser.City = new Tuple<int, string>(CurrentContractor.CityId, CurrentContractor.City.Title);
            UnregisteredUser.SpecializationLinks = UIManager.CreateLinks(CurrentContractor);
            UnregisteredUser.EventCardsCount = BLL.Get.EventCards(CurrentContractor.Id, SubcategoryId).Length;
            //TODO:Comments
            //UnregisteredUser.PositiveCommentsCount = CurrentContractor.ContractorCategories.Single(x => x.SubcategoryId == SubcategoryId).ContractorSubcategoryComments.Where(x => x.StarsCount > 3).Count();
            //UnregisteredUser.NegativeCommentsCount = CurrentContractor.ContractorCategories.Single(x => x.SubcategoryId == SubcategoryId).ContractorSubcategoryComments.Where(x => x.StarsCount <= 3).Count();
            UnregisteredUser.Site = CurrentContractor.Site;
            UnregisteredUser.Mail = CurrentContractor.EMail;
            UnregisteredUser.VK = CurrentContractor.VK;
            UnregisteredUser.Facebook = CurrentContractor.Facebook;
            UnregisteredUser.Twitter = CurrentContractor.Twitter;
            UnregisteredUser.Login = CurrentContractor.Login;
            UnregisteredUser.Description = CurrentContractor.Description;
            UnregisteredUser.Additional = CurrentContractor.Additional;

            UnregisteredUser.ContractorId = CurrentContractor.Id;
            UnregisteredUser.SubCategoryId = SubcategoryId;



            EventCardsPromoListItem.EventCards = BLL.Get.EventCards(this.CurrentContractor.Id, SubcategoryId);
            EventCardsPromoListItem.ContractorId = this.CurrentContractor.Id;
            EventCardsPromoListItem.SubcategoryId = SubcategoryId;
            EventCardsPromoListItem.ContractorName = this.CurrentContractor.Login;
        }

        
    }
}