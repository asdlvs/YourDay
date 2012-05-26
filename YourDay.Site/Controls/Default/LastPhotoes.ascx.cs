using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.BLL;

namespace YourDay.Site.Controls.Default
{
    public partial class LastPhotoes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //TODO: Hardcode
            RepeaterPhotoesPromo.DataSource = BLL.Manager.GetEventPhotoes(BLL.Admin.DefaultEventCardForMainPhotoes())
                .Select(x => new { 
                    Path = BLL.Manager.GetContractorPhoto(MediaHelper.GetRelationIdFromKey(x.RelationId, MediaEventCardCompanySplitterType.ContractorId), x.Name, 460,265),
                    Title = x.Name,
                    Alt = String.Format("{0} {1}", BLL.Get.Contractor(MediaHelper.GetRelationIdFromKey(x.RelationId, MediaEventCardCompanySplitterType.ContractorId)).FullName, x.Name),
                    Description = x.Description
                });
            RepeaterPhotoesPromo.DataBind();

            RepeaterPhotoesThumbs.DataSource = BLL.Manager.GetEventPhotoes(BLL.Admin.DefaultEventCardForMainPhotoes())
                .Select((x, index) => new {
                    Path = BLL.Manager.GetContractorThumbPhoto(MediaHelper.GetRelationIdFromKey(x.RelationId, MediaEventCardCompanySplitterType.ContractorId), x.Name, 50, 50),
                    No = String.Format("#{0}", index + 1)
                });
            RepeaterPhotoesThumbs.DataBind();

        }
    }
}