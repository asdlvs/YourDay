using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.POCO;
using System.Configuration;

namespace YourDay.Site.Controls.Contractor
{
    public partial class EventCardPromo : System.Web.UI.UserControl
    {

        public POCO.EventCard EventCard
        { get; set; }
        public int ContractorId
        { get; set; }
        public int SubcategoryId
        { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            LabelDateTime.Text = EventCard.Date.ToShortDateString();
            HyperLinkTitle.Text = EventCard.Title;
            HyperLinkTitle.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.Strings.EventCardLink, EventCard.Id.ToString());

            //TODO:Подумать, как вынести
            //List<string> photoes = EventCard.EventCardCompanies.Single(x => x.ContractorId == ContractorId && x.SubcategoryId == SubcategoryId).EventCardCompanyMedia.Where(x => x.Type == (int)MediaType.Photo).Select(x => x.PhotoName).ToList();
            //List<string> videos = EventCard.EventCardCompanies.Single(x => x.ContractorId == ContractorId && x.SubcategoryId == SubcategoryId).EventCardCompanyMedia.Where(x => x.Type == (int)MediaType.Video).Select(x => x.PhotoName).ToList();

            var photoes = BLL.Get.Medias(ContractorId, SubcategoryId, EventCard.Id,YourDay.Constants.Enums.MediaType.Photo);
            var videos = BLL.Get.Medias(ContractorId, SubcategoryId, EventCard.Id, YourDay.Constants.Enums.MediaType.Video);

            //TODO:COmments
           // int commentsCount = EventCard.EventCardCompanies.Single(x => x.ContractorId == ContractorId && x.SubcategoryId == SubcategoryId).EventCardCompanyMedia.Sum(x => x.EventCardCompanyMediaComments.Count);
            //int commentsCount = BLL.Get.Medias(ContractorId, SubcategoryId, EventCard.Id, MediaType.Photo).SelectMany(x => x.EventCardCompanyMediaComments).Count() +
            //    BLL.Get.Medias(ContractorId, SubcategoryId, EventCard.Id, MediaType.Video).SelectMany(x => x.EventCardCompanyMediaComments).Count();
            // commentsCount = commentsCount - ((commentsCount / 10) * 10);
            //string commentsCountLinkText = String.Empty;
            //if (commentsCount == 1)
            //        commentsCountLinkText = "{0} комментарий";
            //    else if (commentsCount > 1 && commentsCount <= 4)
            //        commentsCountLinkText = "{0} комментария";
            //    else
            //        commentsCountLinkText = "{0} комментариев";


            //HyperLinkCommentsCount.Text = String.Format(commentsCountLinkText, commentsCount);
            //HyperLinkCommentsCount.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.String.EventCardCommentsLink, EventCard.Id.ToString());

            int photoCount = photoes.Length;
            if (photoCount > 0)
            {
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
                HyperLinkPhotoesCount.Text = String.Format(photoCountLinkText, photoes.Length);
                HyperLinkPhotoesCount.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.Strings.EventCardPhotoesLink, EventCard.Id.ToString());
                Photoes1.DataSource = photoes;
            }
            else
            {
                divEventCardPromo.Visible = false;
                //Photoes1.Visible = false;
            }

            int videoCount = videos.Length;
            HyperLinkVideoCount.Text = String.Format("{0} видео", videoCount);
            HyperLinkVideoCount.NavigateUrl = YourDay.Constants.Config.GetLink(Constants.Strings.EventCardVideosLink, EventCard.Id.ToString());

            
            
            //photoes.Select(x => new { Path = BLL.Manager.GetContractorThumbPhoto(ContractorName, x.Name, 100, 100), Alt = x.Name });
            //RepeaterPhotoes.DataSource = 
            //RepeaterPhotoes.DataBind();

        }
    }
}