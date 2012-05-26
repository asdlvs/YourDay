using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YourDay.Security;
using YourDay.Pictures;
using System.Configuration;
using System.IO;
using YourDay.Security;
using YourDay.BLL;
using System.Collections.ObjectModel;

namespace YourDay.Site.Controls.Common
{
    public partial class CutImage : System.Web.UI.UserControl
    {
        int clientWidth = 500;
        int clientHeight = 720;
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageCurrentAvatar.ImageUrl = MembershipUser.CurrentUser.GetAvatarImage(clientWidth, clientHeight);//MembershipUser.CurrentUser.AvatarSrc;
            PanelCropFile.Visible = false;
        }
        protected void LinkButtonLoadImage_Click(object sender, EventArgs e)
        {

            //string hfWidth = HiddenFieldClientWidth.Value;
            //string hfHeight = HiddenFieldClientHeight.Value;
            //TODO: HC
           
            //if (Int32.TryParse(hfWidth, out clientWidth) && Int32.TryParse(hfHeight, out clientHeight))
            {
                Converter converter = new Converter(FileUploader.FileContent, MembershipUser.CurrentUser.Login);
                converter.SaveAll();

                string appropriateImageSource = converter.GetNearestFileName(clientWidth, clientHeight);
                //TODO:HC
                string appropriateUrl = String.Format("http://{0}{1}", Request.Url.Authority, appropriateImageSource.Replace("\\", "/"));
                PanelLoadFile.Visible = false;

                PanelCropFile.Visible = true;
                target.ImageUrl = appropriateUrl;

                Session["converter"] = converter;
                Session["appropriateImageSource"] = appropriateImageSource;

            }
            
        }

        protected void LinkButtonCropImage_Click(object sender, EventArgs e)
        {
            Converter converter = (Converter)Session["converter"];
            string appropriateImageSource = (string)Session["appropriateImageSource"];

            string coords = HiddenFieldCoords.Value;
            if (!String.IsNullOrEmpty(coords))
            {
                string[] coordsArray = coords.Split(',');
                int x, y, x2, y2;
                if (Int32.TryParse(coordsArray[0], out x) && Int32.TryParse(coordsArray[1], out y) && Int32.TryParse(coordsArray[2], out x2) && Int32.TryParse(coordsArray[3], out y2))
                {
                    string avatar = converter.Crop(appropriateImageSource, x, y, x2, y2).Key;
                    POCO.User u = YourDay.Security.MembershipUser.CurrentUser;
                    u.AvatarSrc = avatar.Replace("\\", "/");
                    u.Avatars.Clear();
                    foreach(var fileName in converter.FileNames)
                    {
                        POCO.Avatar ava = new POCO.Avatar();
                        ava.ImageName = fileName.Key;
                        ava.Width = fileName.Value.X;
                        ava.Height = fileName.Value.Y;
                        u.Avatars.Add(ava);
                    }
                    BLL.Post.UpdateUser(u);
                    //TODO: HC
                    Response.Redirect("/preferences/img/");
                }
            }
        }

       

       
    }
}