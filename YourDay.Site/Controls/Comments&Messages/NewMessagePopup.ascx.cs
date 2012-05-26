using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace YourDay.Site.Controls.Comments_Messages
{
    public partial class NewMessagePopup : System.Web.UI.UserControl
    {

        public int LinkId
        { get; set; }
        public int RelationId
        { get; set; }
        public int ReceiverId
        { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            anchorSendMessage.Attributes.Add("onclick", String.Format("sendmessage({0},{1},this, true, 1);return false;", RelationId, ReceiverId));
        }
    }
}