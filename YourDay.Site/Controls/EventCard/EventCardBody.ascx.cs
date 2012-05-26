using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.EventCard
{
    public partial class EventCardBody : System.Web.UI.UserControl
    {
        public YourDay.POCO.EventCard EventCard { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ContractorsListConcerned.Title = "Рассматриваемые контрагенты";
            ContractorsListConcerned.DataSource = BLL.Get.EventCardCompanies(this.EventCard.Id, Constants.Enums.EventCardCompanyStatus.Offer);
            ContractorsListAccepted.Title = "Подтвержденные контрагенты";
            ContractorsListAccepted.DataSource = BLL.Get.EventCardCompanies(this.EventCard.Id, Constants.Enums.EventCardCompanyStatus.Order | Constants.Enums.EventCardCompanyStatus.Payed);
            Photoes1.DataSource = BLL.Get.Medias(eventcardId:this.EventCard.Id);
            LabelPhotoes.Text = "Фото";
        }
    }
}