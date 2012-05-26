using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Drawing;

namespace YourDay.BLL.Images
{
    public class Article : IHttpHandler
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
            HttpRequest request = context.Request;
            string article = request.QueryString["id"];
            string isShort = request.QueryString["isShort"];

            int articleId;
            bool IsShort = String.Equals(isShort, "1");

            if (article != null &&
                isShort != null &&
                Int32.TryParse(article, out articleId)
                )
            {
                //TODO: Вынести нах
                int width, height;

                if (IsShort)
                {
                    width = 163;
                    height = 108;
                }
                else
                {
                    width = 327;
                    height = 216;
                }

                string host = ConfigurationManager.AppSettings["Images"];
                string file = context.Server.MapPath(String.Format(@"{0}/{1}/{2}_{3}_{4}.png", host, "Articles", articleId, width, height));

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
                    string fileFull = context.Server.MapPath(String.Format(@"{0}/{1}/{2}.png", host, "Articles", articleId));
                    if (File.Exists(fileFull))
                    {
                        using (Image img = Image.FromFile(fileFull))
                        {
                            using (Bitmap bmp = new Bitmap(width, height))
                            {
                                using (Graphics graph = Graphics.FromImage(bmp))
                                {
                                    //TODO: Тупое место - двойной Save - да и работает неправильно
                                    //int size = img.Width > img.Height ? img.Height : img.Width;
                                    Rectangle srcRectangle = new Rectangle(0, 0, img.Width, img.Height);
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

        #endregion
        }
    }
}

