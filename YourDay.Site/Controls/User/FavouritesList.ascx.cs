using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.POCO;
using YourDay.Security;
using YourDay.BLL;

namespace YourDay.Site.Controls.User
{
    public partial class FavouritesList : System.Web.UI.UserControl
    {
        public POCO.User User
        { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (User == null)
                this.User = MembershipUser.CurrentUser;

            var favCons = this.User.GetFavouriteItems<POCO.Contractor>();
            if(favCons != null)
            {
            RepeaterFavouriteContractors.DataSource =
                favCons
                .Select(x => new { 
                    Avatar = x.AvatarSrc,
                    Title = x.FullName,
                    State = String.Empty,
                    City = String.Empty,
                    Specializations = "",
                    Photoes = "",
                    Videos = ""
                });
            }
            RepeaterFavouriteContractors.DataBind();

            RepeaterFavouriteEventCards.DataSource = this.User.GetFavouriteItems<POCO.EventCard>();
            RepeaterFavouriteEventCards.DataBind();

            RepeaterFavouriteArticles.DataSource = this.User.GetFavouriteItems<POCO.Article>();
            RepeaterFavouriteArticles.DataBind();
        }
    }
}