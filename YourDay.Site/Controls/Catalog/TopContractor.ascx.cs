using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using YourDay.POCO;
using YourDay.Constants;

namespace YourDay.Site.Controls.Catalog
{
    public partial class TopContractor : System.Web.UI.UserControl
    {

        public POCO.Contractor Contractor
        { get; set; }

        private int SubcategoryId
        { get; set; }

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
            ShortInfoContractor.Contractor = this.Contractor;
            ShortInfoContractor.IsShort = false;

            RepeaterPromoPhotoes.DataSource = BLL.Get.Medias(this.Contractor.Id, SubcategoryId, YourDay.Constants.Enums.MediaType.Photo)
                .Take(3)
                .Select(x => new { Path = BLL.Manager.GetContractorThumbPhoto(this.Contractor.Login, x.Name, 212, 212), Alt = x.Name });
            RepeaterPromoPhotoes.DataBind();

            HtmlLinkFavourite.InnerText = YourDay.Constants.Strings.AddToFavourites;
            HtmlLinkFavourite.HRef = "#";
            HtmlLinkFavourite.Attributes.Add("onclick", String.Format("JavaScript:{0}({1},{2});return false;", Constants.Strings.JS.AddToFavourite, this.Contractor.Id, (int)Enums.FavouriteType.Contractor));

            int photoCount = BLL.Get.Medias(this.Contractor.Id, SubcategoryId, YourDay.Constants.Enums.MediaType.Photo).Count();
            photoCount = photoCount - ((photoCount / 10) * 10);
            string photoCountLinkText = String.Empty;
            {
                if (photoCount == 1)
                    photoCountLinkText = "{0} фотография";
                else if (photoCount > 1 && photoCount <= 4)
                    photoCountLinkText = "{0} фотографии";
                else
                    photoCountLinkText = "{0} фотографий";
            }
            HyperLinkPhotoesCount.Text = String.Format(photoCountLinkText, photoCount);
            //HyperLinkPhotoesCount.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.String.EventCardPhotoesLink, EventCard.Id.ToString());

            int videoCount = BLL.Get.Medias(this.Contractor.Id, SubcategoryId, YourDay.Constants.Enums.MediaType.Video).Count();
            HyperLinkVideoCount.Text = String.Format("{0} видео", videoCount);
            //HyperLinkVideoCount.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.String.EventCardVideosLink, EventCard.Id.ToString());


        }

       
    }
}