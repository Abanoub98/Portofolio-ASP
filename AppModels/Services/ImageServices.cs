
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;
using Portofolio.AppModels.Exceptions;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Portofolio.AppModels.Services
{
    public class ImageServices : IImageServices
    {
        protected List<string> imageExtensions;
        protected string rootPath;

        public ImageServices(IWebHostEnvironment env)
        {
            imageExtensions = new List<string>();
            imageExtensions.Add(".jpg");
            imageExtensions.Add(".jpeg");
            imageExtensions.Add(".png");
            imageExtensions.Add(".webp");
            imageExtensions.Add(".bmp");
            rootPath = env.WebRootPath;
        }
        public void DeleteImg(string imagePath)
        {
            string path = Path.Combine(rootPath, imagePath);
            if(File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task ResizeImg(string imagePath, Size size)
        {
            string srcImgPath = Path.Combine(rootPath, imagePath);
            Image srcImg = Image.FromFile(srcImgPath);
            int srcWidth = srcImg.Width;
            int srcHeight = srcImg.Height;
            int resultWidth = (int)size.Width;
            int resultHeight = (int)size.Height;
            Bitmap bits = new Bitmap(resultWidth, resultHeight);
            using (Graphics graphics = Graphics.FromImage(bits))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                await Task.Run(() => graphics.DrawImage(srcImg, 0, 0, resultWidth, resultHeight));
            }
            srcImg.Dispose();
            bits.Save(srcImgPath);
        }

        public async Task<string> UploadImgAsync(IFormFile file)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), file.FileName);
            string fullPath = Path.Combine(rootPath, "images", fileName);
            using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write, FileShare.Write))
            {
                await file.CopyToAsync(fs);
            }
            return Path.Combine("images", fileName);
        }

        public void ValidateImgExtension(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            if (!imageExtensions.Contains(fileInfo.Extension.ToLower()))
            {
                string supportedExtensions = string.Empty;
                foreach (string ext in imageExtensions)
                {
                    supportedExtensions = string.Concat(supportedExtensions, ext, "\n");
                }
                throw new CustomException($"Image extension not supported.\nSupported extensions:\n{supportedExtensions}");
            }
        }
    }
}