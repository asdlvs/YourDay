using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Security;
using YourDay.BLL;
using System.Web.UI;
using YourDay.Site.Controls.Comments_Messages;
using YourDay.Constants;

namespace YourDay.Site.WS
{
    /// <summary>
    /// Summary description for WS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WS : System.Web.Services.WebService
    {
        [WebMethod]
        public void CheckLoginForExistance(string login)
        {
            if (BLL.Get.Contractors().Any(x => x.Login.ToUpper() == login.Trim().ToUpper()))
                throw new Exception();
            if (BLL.Get.SimpleUsers().Any(x => x.Login.ToUpper() == login.Trim().ToUpper()))
                throw new Exception();
        }

        [WebMethod]
        public void SendMessage(string receiverIds, string topicTheme, string message)
        {
            POCO.User receiver = BLL.Get.User(Membership.GetUser().UserName);
            int receiverId;
            if (Int32.TryParse(receiverIds, out receiverId))
            {
                receiver.SendMessage(receiverId, topicTheme, message);
            }
        }

        [WebMethod]
        public bool Login(string login, string pwd, string chb)
        {

            if (Membership.ValidateUser(login, pwd))
            {
                FormsAuthentication.SetAuthCookie(login, bool.Parse(chb));
                return true;
            }
            return false;
        }

        [WebMethod]
        public void ChangeEventCardCompanyState(int contractorId, int eventCardId, int subcategoryId, int newState)
        {
            if (YourDay.Security.MembershipUser.CurrentUser.Id == contractorId)
            {
                BLL.Post.UpdateEventCardCompanyStatus(contractorId, eventCardId, subcategoryId, newState);
            }
        }
        [WebMethod]
        public object WritePrivateMessageToEcFromContractor(int e, int r, string ty, int ctr = 2)
        {
            POCO.EventCard ec = BLL.Get.EventCard(e);
            //TODO: Проблемы с подгрузкой команий. При возможности решить.
            if (YourDay.Security.MembershipUser.CurrentUser == null || ec.Creator != r /*|| !ec.EventCardCategories.SelectMany(x => x.EventCardCompanies).Any(x => x.ContractorId == BLL.Manager.CurrentUser.Id)*/)
                throw new Exception("Несанкционированный доступ.");
            else
            {

                BLL.Post.AddMessageToEcFromContractor(YourDay.Security.MembershipUser.CurrentUser.Id, r, e, ty.HtmlEncode());
                return BLL.Get.PrivateEventCardMessages(YourDay.Security.MembershipUser.CurrentUser.Id, e, ctr).Select(x => new
                {
                    A = BLL.Get.User(x.AuthorId).FullName,
                    U = String.Empty,
                    M = x.Text,
                    T = x.DateTime.ToShortTimeString(),
                    ID = x.Id,
                    IS = BLL.Manager.GetUserAvatar(x.AuthorId, 70),
                    IA = BLL.Manager.GetUser(x.AuthorId).FullName,
                    AL = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, ty, null, x.AuthorId, null, 0, Int32.MaxValue),
                    DT = String.Format("{0} в {1}", x.DateTime.ToShortDateString(), x.DateTime.ToShortTimeString()),
                    DL = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, ty, null, null, String.Format("{0}-{1}-{2}", x.DateTime.Year, x.DateTime.Month, x.DateTime.Day), 0, Int32.MaxValue),
                    ML = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, ty, x.RelationId, null, null, 0, Int32.MaxValue),
                    MT = BLL.Get.EventCard(x.RelationId).Title,
                    F = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id,
                    AR = x.AlreadyRead,
                    C = x.AlreadyRead ? "" : "checked=\"checked\"",
                    D = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id ? "disabled=\"disabled\"" : "",
                    CR = RenderNewMessagePopup(x.Id, x.RelationId, x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id ? x.ReceiverId : x.AuthorId)

                });
               
            }
        }

        [WebMethod]
        public string GetECList(int y, int m, int d, int c)
        {
            DateTime dt = DateTime.Now;
            if(y != 0)
                dt = new DateTime(y,m,d);
            return UIManager.RenderControl(
                "YourDay.Site.Controls.Contractor.EventsInCabinet", 
                new Dictionary<string, object>() { { "DateTime", dt }, { "DaysCount", c } }, 
                "~/Controls/Contractor/EventsInCabinet.ascx");
        
        }

        [WebMethod]
        public object[] GetMessages(int u, string ty, string e = null, string op = null, string dt = null, int s = 0, int ta = Int32.MaxValue)
        {

            var result = BLL.Get.Messages(BLL.Get.User(u), ref ty, e, op, dt, s, ta);
            /*if (e < 0 && ty < 0)
                result = BLL.Get.Messages(u, s, ta);
            else if (e < 0 && ty > 0)
                result = BLL.Get.Messages(u, (Constants.Enums.CommentsType)ty, s, ta);
            else if (e > 0 && ty < 0)
                result = BLL.Get.Messages(u, e, s, ta);
            else if (e > 0 && ty > 0)
                result = BLL.Get.Messages(u, e, (Constants.Enums.CommentsType)ty, s, ta);*/



            return result.Select(x => new 
            {
                ID = x.Id,
                IS = BLL.Manager.GetUserAvatar(x.AuthorId, 70),
                IA = BLL.Manager.GetUser(x.AuthorId).FullName,
                AL = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, ty, null, x.AuthorId, null, 0, Int32.MaxValue),
                A = BLL.Manager.GetUser(x.AuthorId).FullName,
                DT = String.Format("{0} в {1}", x.DateTime.ToShortDateString(), x.DateTime.ToShortTimeString()),
                DL = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, ty, null, null, String.Format("{0}-{1}-{2}", x.DateTime.Year, x.DateTime.Month, x.DateTime.Day), 0, Int32.MaxValue),
                ML = String.Format("getMessages('{0}','{1}','{2}','{3}','{4}','{5}','{6}', this);return false;", YourDay.Security.MembershipUser.CurrentUser.Id, ty, x.RelationId, null, null, 0, Int32.MaxValue),
                MT = BLL.Get.EventCard(x.RelationId).Title,
                M = x.Text,
                F = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id,
                AR = x.AlreadyRead,
                C = x.AlreadyRead ? "" : "checked=\"checked\"",
                D = x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id ? "disabled=\"disabled\"" : "",
                CR = RenderNewMessagePopup(x.Id, x.RelationId, x.AuthorId == YourDay.Security.MembershipUser.CurrentUser.Id ? x.ReceiverId : x.AuthorId)

            }).ToArray();
        }

        private string RenderNewMessagePopup(int LinkId, int RelationId, int ReceiverId)
        {

            return UIManager.RenderControl(
                "YourDay.Site.Controls.Comments_Messages.NewMessagePopup",
                new Dictionary<string, object>() { { "LinkId", LinkId }, { "RelationId", RelationId }, { "ReceiverId", ReceiverId } },
                "~/Controls/Comments&Messages/NewMessagePopup.ascx");
        }

        [WebMethod]
        public void SetMessagesAsAR(string[] messages)
        {
            List<int> ids = new List<int>();
            foreach (string m in messages)
            { 
                int id;
                if (Int32.TryParse(m.Replace("message_", ""), out id)) 
                {
                    ids.Add(id);
                }
            }
            BLL.Post.MarkMessagesAsAR(ids.ToArray());
        }

        [WebMethod(EnableSession=true)]
        public object CreateEventCardCompany(int cId, int scId, bool addEventCardCategory)
        {
          

            bool eventCardCategoryExists;
            int eventCardId = YourDay.Security.MembershipUser.CurrentUser.AddContractorToSelection(scId, cId, out eventCardCategoryExists, addEventCardCategory);
            if (eventCardCategoryExists)
            {
                return GetEventCardCompanies(cId, scId, eventCardId);
            }
            else
            {
                return new { Error = "Данная категория не назначена текущей карточке событий", Code = "1" };
            }
        }

        private static object GetEventCardCompanies(int cId, int scId, int eventCardId)
        {
            POCO.Contractor r = BLL.Get.Contractor(cId);
            var cs = BLL.Get.EventCardCompanies(eventCardId, scId)
                .Select(
                x => new
                {
                    FullName = BLL.Get.Contractor(x.ContractorId).FullName,
                    Image = BLL.Manager.GetUserAvatar(BLL.Get.Contractor(x.ContractorId).Login, 30),
                    Specialization = BLL.Get.SubCategory(scId).Title,
                    Id = x.ContractorId,
                    Sc = scId

                });
            return new { Cs = cs };
        }

        [WebMethod(EnableSession = true)]
        public object RemoveEventCardCompany(int cId, int scId)
        {
            int ecId = YourDay.Security.MembershipUser.CurrentUser.RemoveContractorFromSelection(scId, cId);
            return GetEventCardCompanies(cId, scId, ecId);
        }

        [WebMethod]
        public string GetTopMenuHtml()
        {
            POCO.User currentUser = YourDay.Security.MembershipUser.CurrentUser;
            if (currentUser != null)
            {
                //if (currentUser.GetType() == typeof(POCO.Contractor))
                {
                    string result = UIManager.RenderControl(
                    "YourDay.Site.Controls.Auth.HeaderLinks",
                    /*new Dictionary<string, object>() { { "DateTime", dt }, { "DaysCount", c } }*/ null,
                    "~/Controls/Auth/HeaderLinks.ascx");
                    return result;
                }
            }
            else
            {
                return null;
            }
            return null;
        }

        [WebMethod]
        public void SendApprovedMail()
        {
            BLL.Mail.Send(YourDay.Security.MembershipUser.CurrentUser, Constants.Enums.MailType.ApproveRegistration);
        }

        [WebMethod]
        public void SendChangePwdMail(string login)
        {
            var user = BLL.Get.User(login);
            if (user != null)
            {
                BLL.Mail.Send(user, Constants.Enums.MailType.ChangePassword);
            }
            else
            {
                throw new Exception();
            }
        }

        [WebMethod]
        public void AddFavourites(int itemId, int type)
        {
            YourDay.Security.MembershipUser.CurrentUser.AddFavourites(itemId, (Enums.FavouriteType)type);
        }

    }
}
