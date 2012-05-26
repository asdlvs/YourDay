using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site.Controls.EventCard
{
    public partial class EventCardCreator : System.Web.UI.UserControl
    {
        List<string> times;
        protected void Page_Init()
        {
            DropDownListEventCardType.DataSource = BLL.Get.EventCardTypes();
            DropDownListEventCardType.DataBind();

            times = new List<string>();
            for (int t = 0; t <= 23; t++)
            {
                times.Add(String.Format("{0}:{1}", t.ToString().PadLeft(2, '0'), "00"));
                times.Add(String.Format("{0}:{1}", t.ToString().PadLeft(2, '0'), "30"));
            }
            
            DropDownListFromTime.DataSource = times;
            DropDownListFromTime.DataBind();
            DropDownListToTime.DataSource = times;
            DropDownListToTime.DataBind();
            DropDownListToTimeCategory.DataSource = times;
            DropDownListToTimeCategory.DataBind();
            DropDownListFromTimeCategory.DataSource = times;
            DropDownListFromTimeCategory.DataBind();
            

            DropDownListWhoSee.DataSource = Constants.Strings.WhoSeeDictionary;
            DropDownListWhoSee.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //TODO:hardcode со стилями
        protected void ImageButtonReady_Click(object sender, ImageClickEventArgs e)
        {
            string s = selectedcategories.Value;

            bool ok = true;
            
            string title = TextBoxTitle.Text;
            if (String.IsNullOrEmpty(title.Trim()) || title.Length < 5)
            {
                ectitleerror.InnerHtml = Constants.Errors.EventCardTitleEmpty;
                ectitleerror.Style.Add(HtmlTextWriterStyle.Color, "#FF0000");
                ectitleerror.Style.Add(HtmlTextWriterStyle.FontSize, "8pt");
                TextBoxTitle.Style.Add(HtmlTextWriterStyle.BorderColor, "#FF0000");
                ok = false;
            }
            string description = TextBoxDescription.Text;
            if (String.IsNullOrEmpty(description.Trim()) || description.Length < 25)
            {
                descriptionerror.InnerHtml = Constants.Errors.EventCardDescriptionEmpty;
                descriptionerror.Style.Add(HtmlTextWriterStyle.Color, "#FF0000");
                descriptionerror.Style.Add(HtmlTextWriterStyle.FontSize, "8pt");
                TextBoxDescription.Style.Add(HtmlTextWriterStyle.BorderColor, "#FF0000");
                ok = false;
            }

            int type;
            if (!Int32.TryParse(DropDownListEventCardType.SelectedValue, out type) || !BLL.Get.EventCardTypes().Select(x => x.Id).Contains(type))
            {
                ok = false;
            }

            int whoSee;

            if (!Int32.TryParse(DropDownListWhoSee.SelectedValue, out whoSee) || !Constants.Strings.WhoSeeDictionary.Select(x => x.Key).Contains(whoSee))
            {
                ok = false;
            }

            string date = datepicker.Value;
            DateTime datetime = new DateTime();
            if (String.IsNullOrEmpty(date) || !DateTime.TryParse(date, out datetime))
            {
                datepicker.Style.Add(HtmlTextWriterStyle.BorderColor, "#FF0000");
                ok = false;
            }


            string startTime = DropDownListFromTime.Text;
            if (String.IsNullOrEmpty(startTime))
            {
                DropDownListFromTime.Style.Add(HtmlTextWriterStyle.BorderColor, "#FF0000");
                ok = false;
            }

            string endTime = DropDownListToTime.Text;
            if (String.IsNullOrEmpty(endTime))
            {
                DropDownListToTime.Style.Add(HtmlTextWriterStyle.BorderColor, "#FF0000");
                ok = false;
            }


            decimal budjet;
            if (!Decimal.TryParse(TextBoxBudjet.Text, out budjet) || budjet <= 0)
            {
                TextBoxBudjet.Style.Add(HtmlTextWriterStyle.BorderColor, "#FF0000");
                ok = false;
            }

            //int[] sc = null;
            List<Tuple<int, string, string>> sc = new List<Tuple<int, string, string>>();
            //TODO:Hardcode
            if (whoSee != 1)
            {
                string[] subcategories = s.Split(';');
                
                string[] fromTimes = Request.Form[DropDownListFromTimeCategory.GetPostParameterName()].Split(',');
                string[] toTimes = Request.Form[DropDownListToTimeCategory.GetPostParameterName()].Split(',');
                if (subcategories.Length > fromTimes.Length || subcategories.Length > toTimes.Length || fromTimes.Length != toTimes.Length)
                    ok = false;
                else
                {
                    for (int i = 0; i < subcategories.Length; i++)
                    {
                        int h;
                        if (Int32.TryParse(subcategories[i], out h))
                        {
                            sc.Add(new Tuple<int, string, string>(h, fromTimes[i], toTimes[i]));
                        }
                    }
                }
            }

            bool showFromEc = CheckBoxEA.Checked;
            bool showFromC = CheckBoxC.Checked;


            if (ok)
            {
                POCO.EventCard eventCard = new POCO.EventCard();
                eventCard.Title = title;
                eventCard.Description = description;
                eventCard.Type = type;
                eventCard.Date = datetime;
                eventCard.StartTime = startTime;
                eventCard.EndTime = endTime;
                eventCard.WhoSee = whoSee;
                eventCard.Budjet = budjet;
                eventCard.Creator = YourDay.Security.MembershipUser.CurrentUser.Id;
                eventCard.ShowToContractors = showFromC;
                eventCard.ShowToEventAgency = showFromEc;

                eventCard.EventCardCategories = new System.Collections.ObjectModel.Collection<POCO.EventCardCategory>();
                foreach(Tuple<int,string, string> scItem in sc)
                {
                    eventCard.EventCardCategories.Add(new POCO.EventCardCategory() { EventCard = eventCard, SubcategoryId = scItem.Item1, StartTime = scItem.Item2, EndTime = scItem.Item3 });
                }
                int createdECId = BLL.Post.EventCard(eventCard);
                Response.Redirect(BLL.Manager.GetEventCardLink(createdECId));
            }
        }

    }
}