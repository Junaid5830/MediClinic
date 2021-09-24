using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MediClinic.Utility
{
    public static class ExtensionMethods
    {
        private static string base64Initials = "data:image/png;base64,";

        private static string base64InitialsJPEG = "data:image/jpeg;base64,";
        public static string GetImageUrl(this string base64Image,string folderName)
        {
            base64Image = base64Image.Replace(base64Initials, "");
            byte[] imgBytes = Convert.FromBase64String(base64Image);

            Image image_profile;
            using (MemoryStream picStream = new MemoryStream(imgBytes))
            {
                image_profile = Image.FromStream(picStream);
            }
            MemoryStream pic_memStream = new MemoryStream();
            image_profile.Save(pic_memStream, ImageFormat.Png);
            pic_memStream.Seek(0, SeekOrigin.Begin);

            var currentDateWithFilePath = DateTime.UtcNow.ToString("ddMMyyyyhhmmss");
            currentDateWithFilePath = System.IO.Path.GetFileName(currentDateWithFilePath) + ".png";
            var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, currentDateWithFilePath);
            using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
            {
                pic_memStream.CopyTo(fileSteam);
            }
            pic_memStream.Close();

            return currentDateWithFilePath;
        }

        public static string BarCode(this string base64Image, string folderName, string ImageName)
        {
            try
            {
                base64Image = base64Image.Replace(base64InitialsJPEG, "");
                byte[] imgBytes = Convert.FromBase64String(base64Image);

                Image image_profile;
                using (MemoryStream picStream = new MemoryStream(imgBytes))
                {
                    image_profile = Image.FromStream(picStream);
                    image_profile.Save(picStream, ImageFormat.Png);
                    picStream.Seek(0, SeekOrigin.Begin);
                    var currentDateWithFilePath = ImageName;
                    currentDateWithFilePath = System.IO.Path.GetFileName(currentDateWithFilePath) + ".png";
                    var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, currentDateWithFilePath);
                    using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
                    {
                        picStream.CopyTo(fileSteam);
                    }
                    picStream.Close();

                    return currentDateWithFilePath;
                }
                //MemoryStream pic_memStream = new MemoryStream();
                //image_profile.Save(pic_memStream, ImageFormat.Png);
                //pic_memStream.Seek(0, SeekOrigin.Begin);

               
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }
        //public static string BarCodes(this string base64Image, string folderName, string ImageName)
        //{
        //    try
        //    {
        //        byte[] jpgArray;
        //        base64Image = base64Image.Replace(base64InitialsJPEG, "");
        //        byte[] imgBytes = Convert.FromBase64String(base64Image);

        //        //  Image image_profile;
        //        using (MemoryStream picStream = new MemoryStream(imgBytes))
        //        {
        //            //image_profile = Image.FromStream(picStream);
        //            using (Image img = Image.FromStream(picStream))
        //            {
        //                using (MemoryStream msJpeg = new MemoryStream())
        //                {
        //                    img.Save(msJpeg, ImageFormat.Png);
        //                    jpgArray = msJpeg.ToArray();
        //                    var currentDateWithFilePath = ImageName;
        //                    currentDateWithFilePath = System.IO.Path.GetFileName(currentDateWithFilePath) + ".png";
        //                    var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, currentDateWithFilePath);
        //                    using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
        //                    {
        //                        msJpeg.CopyTo(fileSteam);
        //                    }
        //                    msJpeg.Close();

        //                    return currentDateWithFilePath;
        //                }
        //            }
        //        }
        //        //MemoryStream pic_memStream = new MemoryStream();
        //        //image_profile.Save(pic_memStream, ImageFormat.Jpeg);
        //        //pic_memStream.Seek(0, SeekOrigin.Begin);

        //        //var currentDateWithFilePath = ImageName;
        //        //currentDateWithFilePath = System.IO.Path.GetFileName(currentDateWithFilePath) + ".jpeg";
        //        //var ProfileImageFilePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, currentDateWithFilePath);
        //        //using (var fileSteam = new FileStream(ProfileImageFilePath, FileMode.Create))
        //        //{
        //        //    msJpeg.CopyTo(fileSteam);
        //        //}
        //        //msJpeg.Close();

        //        //return currentDateWithFilePath;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}
    }
}
