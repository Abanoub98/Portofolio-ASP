using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Portofolio.AppModels.Models;
using System.Drawing;
namespace Portofolio.AppModels.Services
{
    public interface IImageServices
    {
        void ValidateImgExtension(IFormFile file);

        Task<string> UploadImgAsync(IFormFile file);

        void DeleteImg(string imagePath);

        Task ResizeImg(string imagePath, Size size);
    }
}