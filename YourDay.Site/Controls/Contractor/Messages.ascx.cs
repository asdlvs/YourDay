using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Contractor
{
    public partial class Messages : System.Web.UI.UserControl
    {
        public string EventCardId;
        public string UserId;
        public string Date;
        public string Type;
        protected void Page_Init(object sender, EventArgs e)
        {
            EventCardId = Request.QueryString["ec"];
            UserId = Request.QueryString["u"];
            Type = Request.QueryString["t"];
            Date = Request.QueryString["d"];

            POCO.Comment[] result = BLL.Get.Messages(YourDay.Security.MembershipUser.CurrentUser, ref Type, EventCardId, UserId, Date);
           

            RepeaterMessages.DataSource = result
                .Take(10)
                .Select(x => new 
                { 
                    ID = x.Id,
                    ImageSrc = BLL.Manager.GetUserAvatar(x.AuthorId, 70), 
                    ImageAlt = BLL.Manager.GetUser(x.AuthorId).FullName,
                    AuthorLink = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, Type, null, x.AuthorId, null, 0, Int32.MaxValue),
                    Author = BLL.Manager.GetUser(x.AuthorId).FullName,
                    DateTime = String.Format("{0} в {1}", x.DateTime.ToShortDateString(), x.DateTime.ToShortTimeString()),
                    DateLink = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, Type, null, null, String.Format("{0}-{1}-{2}", x.DateTime.Year, x.DateTime.Month, x.DateTime.Day), 0, Int32.MaxValue),
                    MessageLink = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, Type, x.RelationId, null, null, 0, Int32.MaxValue),
                    MessageTitle = BLL.Get.EventCard(x.RelationId).Title,
                    Annotation = x.Text,//Annotation = BLL.Manager.GetShortContent(x.Text, 30),
                    From = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id,
                    Already = x.AlreadyRead,
                    Checked = x.AlreadyRead ? "" : "checked=\"checked\"",
                    Disabled = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id ? "disabled=\"disabled\"" : "",
                    RelationId = x.RelationId,
                    ReceiverId = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id ? x.ReceiverId : x.AuthorId
                    
                });
            RepeaterMessages.DataBind();
        }
    }
}