using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using YourDay.BLL;


namespace YourDay.Site.Controls.Contractor
{
    public partial class OneDay : System.Web.UI.UserControl
    {
        public ContractorsDay Today
        {
            get;
            set;
        }
        YourDay.POCO.EventCardCompany[] eventCardCompanies;
        //TODO:Убрать хардкод
        protected void Page_Load(object sender, EventArgs e)
        {

            TodayBlock.Attributes.Add("onclick", String.Format("getevents({0},{1},{2},{3});return false;", Today.Date.Year, Today.Date.Month, Today.Date.Day, 1));

            eventCardCompanies = (YourDay.POCO.EventCardCompany[])Context.Items["ContractorsEventCardCompanies"];

            Literal LiteralDayName = TodayBlock.DeepFindControl<Literal>("LiteralDayName");
            LiteralDayName.Text = this.Today.ShortTitle;
            Literal LiteralDayDate = TodayBlock.DeepFindControl<Literal>("LiteralDayDate");
            LiteralDayDate.Text = this.Today.Date.Day.ToString();

            HtmlGenericControl eventsBottomDiv = new HtmlGenericControl("div");

                       

            HtmlGenericControl morningShiftDiv = new HtmlGenericControl("div");
            morningShiftDiv.Attributes.Add("class", "shift");
            CheckEventcards(Today.MorningShift, morningShiftDiv);

            HtmlGenericControl dayShiftDiv = new HtmlGenericControl("div");
            dayShiftDiv.Attributes.Add("class", "shift");
            CheckEventcards(Today.DayShift, dayShiftDiv);

            HtmlGenericControl nigthShiftDiv = new HtmlGenericControl("div");
            nigthShiftDiv.Attributes.Add("class", "shift");
            CheckEventcards(Today.NigthShift, nigthShiftDiv);

           
            eventsBottomDiv.Controls.Add(morningShiftDiv);
            eventsBottomDiv.Controls.Add(dayShiftDiv);
            eventsBottomDiv.Controls.Add(nigthShiftDiv);

            TodayBlock.Controls.Add(eventsBottomDiv);

            
            if (Today.IsPast)
            {
                TodayBlock.Attributes.Add("class", "oneday closed");
            }
            else if (Today.IsBlock)
            {
                Image img = new Image();
                img.ImageUrl = "/Pict/Contractor/block.png";
                HtmlGenericControl centralBlock = TodayBlock.DeepFindControl<HtmlGenericControl>("CentralBlock");
                centralBlock.Controls.Add(img);
                
            }
            else if (Today.MessagesCount > 0)
            {
                HtmlAnchor lettersAnchor = new HtmlAnchor();
                lettersAnchor.HRef = "/1/";
                

                Image img = new Image();
                img.ImageUrl = "/Pict/Contractor/letter.png";
                img.Style.Add(HtmlTextWriterStyle.Position, "relative");
                img.Style.Add(HtmlTextWriterStyle.Top, "5px");
                img.Style.Add(HtmlTextWriterStyle.BorderWidth, "0px");
                img.Style.Add(HtmlTextWriterStyle.ZIndex, "100");
                HtmlGenericControl centralBlock = TodayBlock.DeepFindControl<HtmlGenericControl>("CentralBlock");
                lettersAnchor.Controls.Add(img);

                Label mCount = new Label();
                mCount.Text = Today.MessagesCount.ToString();
                mCount.Style.Add(HtmlTextWriterStyle.Position, "absolute");
                mCount.Style.Add(HtmlTextWriterStyle.Top, "0");
                lettersAnchor.Controls.Add(mCount);

                centralBlock.Controls.Add(lettersAnchor);
            }
            else if (Today.IsToday)
            {
                Label l = new Label();
                l.Text = Today.ShortTitle;
                //TODO: этот размер тоже вынести
                l.Font.Size = FontUnit.XLarge;
                HtmlGenericControl centralBlock = TodayBlock.DeepFindControl<HtmlGenericControl>("CentralBlock");
                centralBlock.Controls.Add(l);
                LiteralDayName.Visible = false;

            }
            else if (Today.IsEmpty)
            {
                TodayBlock.Attributes.Add("class", "oneday empty");
            }
            
        }

        private void CheckEventcards(List<POCO.EventCard> ecList, HtmlGenericControl h)
        {
            var query = ecList.Join(eventCardCompanies, x => x.Id, x => x.EventCardId, (x, y) => new {y.State});

            //TODO: ХК
            if (query.Any(x => x.State == (int)Constants.Enums.EventCardCompanyStatus.Offer || x.State == (int)Constants.Enums.EventCardCompanyStatus.Order || x.State == (int)Constants.Enums.EventCardCompanyStatus.ContractorCancel))
            {
                SetDivColor(h, "#876980");
            }
            else if (query.Count() > 0 && query.All(x => x.State == (int)Constants.Enums.EventCardCompanyStatus.Payed))
            {
                SetDivColor(h, "#402339");
            }
        }

        private void SetDivColor(HtmlGenericControl h, string color)
        {
            h.Style.Add(HtmlTextWriterStyle.BackgroundColor, color);
        }
        
    }
}