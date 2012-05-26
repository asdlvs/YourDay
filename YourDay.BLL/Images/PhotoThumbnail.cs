using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace YourDay.BLL.Images
{
    public class PhotoThumbnail : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string login = context.Request.QueryString["login"];
            string photoname = context.Request.QueryString["photoname"];
            string widthStr = context.Request.QueryString["width"];
            string heightStr = context.Request.QueryString["height"];

            int width, height;

            if (
                login != null && 
                photoname != null &&
                widthStr != null &&
                heightStr != null &&
                Int32.TryParse(widthStr, out width) &&
                Int32.TryParse(heightStr, out height))
            {
                string host = ConfigurationManager.AppSettings["Images"];
                string file = context.Server.MapPath(String.Format(@"{0}/{1}/{2}_{3}_{4}.png",host, login, photoname, width, height));
                if (File.Exists(file))
                {
                    using (FileStream fs = File.OpenRead(file))
                    {
                        byte[] img = new byte[fs.Length];
                        fs.Read(img, 0, img.Length);
                        context.Response.BinaryWrite(img);
                    }
                }
                else
                {
                    string fileFull = context.Server.MapPath(String.Format(@"{0}/{1}/{2}.png", host, login, photoname));
                    if (File.Exists(fileFull))
                    {
                        using (Image img = Image.FromFile(fileFull))
                        {
                            using (Bitmap bmp = new Bitmap(width, height))
                            {
                                using (Graphics graph = Graphics.FromImage(bmp))
                                {
                                    //TODO: Тупое место - двойной Save
                                    int size = img.Width > img.Height ? img.Height : img.Width;
                                    Rectangle srcRectangle = new Rectangle(0, 0, size, size);
                                    Rectangle destRectangle = new Rectangle(0, 0, width, height);
                                    graph.DrawImage(img, destRectangle, srcRectangle, GraphicsUnit.Pixel);
                                    bmp.Save(file);
                                    MemoryStream ms = new MemoryStream();
                                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    context.Response.BinaryWrite(ms.ToArray());
                                }

                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
