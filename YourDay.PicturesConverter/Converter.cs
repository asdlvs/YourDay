using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Web;
using YourDay.Configuration;

namespace YourDay.Pictures
{
    public partial class Converter : IDisposable
    {
        private Image fullImg;
        private string folderUserName;
        private Dictionary<string, Point> fileNames = new Dictionary<string, Point>();
        private string uniqFileName;
        public Dictionary<string, Point> FileNames
        {
            get { return fileNames; }
            set { fileNames = value; }
        }

        public Converter(Stream loadingImage, string userName)
        {
            string host = ConfigurationManager.AppSettings["Images"];
            string folder = HttpContext.Current.Server.MapPath(String.Format(@"{0}/{1}/", host, userName));
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            folderUserName = userName;
            BLL.Del.Avatar(userName);// TODO: Переписать
            fullImg = Image.FromStream(loadingImage);
            uniqFileName = Guid.NewGuid().ToString().Replace("-", String.Empty);
           
        }

        public Converter(string imagePath, string userName)
        {
            if (File.Exists(imagePath))
            {
                fullImg = Image.FromFile(imagePath);
                folderUserName = userName;
                uniqFileName = Guid.NewGuid().ToString().Replace("-", String.Empty);
            }
        }
        public void SaveAll()
        {
            foreach (int size in GetSizes(fullImg.Width > fullImg.Height))
            {
                using (Image image = Cut(fullImg, size, fullImg.Width > fullImg.Height))
                {
                    KeyValuePair<string, Point> saveImageData = Save(image, folderUserName);
                    fileNames.Add(saveImageData.Key, saveImageData.Value);
                }
            }
        }
        private IEnumerable<int> GetSizes(bool isWidth)
        {
            ProcessingImageSizeConfigurationSection sizes = (ProcessingImageSizeConfigurationSection)ConfigurationManager.GetSection("processingImageSizes");
            foreach (YourDay.Configuration.Size size in sizes.Sizes)
            {
                if (isWidth)
                    yield return size.Width;
                else
                    yield return size.Height;
            }
        }
        private IEnumerable<int> GetAvatarSizes()
        {
            ProcessingImageSizeConfigurationSection sizes = (ProcessingImageSizeConfigurationSection)ConfigurationManager.GetSection("processingImageSizes");
            foreach (AvatarSize size in sizes.AvatarSizes)
            {
               yield return size.Width;
            }
        }
        private Image Cut(Image img, int targetSize, bool isWidth)
        {
            int W = img.Width;
            int H = img.Height;
            int w = 0;
            int h = 0;
            if (isWidth)
            {
                w = targetSize;
                h = (H * w) / W;
            }
            else
            {
                h = targetSize;
                w = (W * h) / H;
            }
            Bitmap bmp = new Bitmap(w, h);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                graph.DrawImage(img, 0, 0, w, h);
                return bmp;
            }
        }
        private KeyValuePair<string, Point> Save(Image img, string folderUserName)
        {
            string host = ConfigurationManager.AppSettings["Images"];
           
            string resultFileName = String.Format(
                ConfigurationManager.AppSettings["imageNameTemplate"],
                uniqFileName, 
                img.Width, 
                img.Height
                );
            string savePath = HttpContext.Current.Server.MapPath(String.Format(@"{0}/{1}/{2}", host, folderUserName, resultFileName));
            img.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            string relativePath = savePath.Replace(HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"], String.Empty);
            return new KeyValuePair<string, Point>("\\"+relativePath, new Point(img.Width, img.Height));;

        }
        public KeyValuePair<string, Point> Crop(string fileAdress, int left, int top, int right, int bottom, string imageName = null)
        {
            if (String.IsNullOrEmpty(imageName))
                imageName = folderUserName;
            if (FileNames.Any(x => x.Key.Equals(fileAdress)))
            {
                using (Image img = Image.FromFile(HttpContext.Current.Server.MapPath(fileAdress)))
                {
                    using (Bitmap bmpImage = new Bitmap(img))
                    {
                        Rectangle cropArea = new Rectangle(left, top, right - left, bottom - top);
                        using (Bitmap bmpCrop = bmpImage.Clone(cropArea,
                        bmpImage.PixelFormat))
                        {
                            foreach (int width in GetAvatarSizes())
                            {
                                var cutAvatar = Cut(bmpCrop, width, true);
                                KeyValuePair<string, Point> result = Save(cutAvatar, imageName);
                                FileNames.Add(result.Key, result.Value);
                            }
                            return Save(bmpCrop, imageName);
                        }
                    }
                }
            }
            else
                throw new Exception("Заданное имя файло не найдено.");
        }
        public string GetNearestFileName(int width, int height)
        {
            string result = null; ;
            if (fullImg.Width > fullImg.Height)
            {
                foreach (var fileElement in FileNames.OrderBy(x => x.Value.X))
                {
                    if (fileElement.Value.X <= width)
                        result = fileElement.Key;
                    else
                        return result;
                }
            }
            else
            {
                foreach (var fileElement in FileNames.OrderBy(x => x.Value.Y))
                {
                    if (fileElement.Value.Y <= height)
                        result = fileElement.Key;
                    else
                        return result;
                }
            }
            return result;
        }
        public void Dispose()
        {
            fullImg.Dispose();
            //image.Dispose();
        }
    }
}

