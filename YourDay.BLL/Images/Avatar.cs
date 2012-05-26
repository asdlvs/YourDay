using System;
using System.Web;
using System.IO;
using System.Configuration;
using System.Drawing;

namespace YourDay.BLL.Images
{
    public class Avatar : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            string login = context.Request.QueryString["login"];
            string size = context.Request.QueryString["size"];

            if (login != null && size != null && size != "0")
            {
                string host = ConfigurationManager.AppSettings["Images"];
                string file = context.Server.MapPath(String.Format(@"{0}/{1}/avatar_{2}.png", host, login, size));
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
                    string fileFull = context.Server.MapPath(String.Format(@"{0}/{1}/avatar.png", host, login));
                    if (File.Exists(fileFull))
                    {
                        using (Image img = Image.FromFile(fileFull))
                        {
                            int s = Int32.Parse(size);
                            using (Bitmap bmp = new Bitmap(s, s))
                            {
                                using (Graphics graph = Graphics.FromImage(bmp))
                                {
                                    //TODO: Тупое место - двойной Save
                                    graph.DrawImage(img, 0, 0, s, s);
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
    }
}
