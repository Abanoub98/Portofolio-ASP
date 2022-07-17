using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Portofolio.Database;
using Portofolio.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Portofolio.AppModels.Services;
using static Portofolio.AppModels.Utils.Constants;

namespace Portofolio.AppModels.Repositories
{
    public class ProjectImagesRepository : BaseRepository
    {

        public ProjectImagesRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectImage> Create(ProjectImage image)
        {
            image.CreatedAt = DateTime.Now;
            image.UpdatedAt = DateTime.Now;
            await _dbContext.ProjectImages.AddAsync(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }

        public async Task CreateFromCollection(int projectId, IFormFileCollection images, IImageServices imageService)
        {
            foreach(IFormFile image in images)
            {
                imageService.ValidateImgExtension(image);
                string imagePath = await imageService.UploadImgAsync(image);
                await Create(new ProjectImage{
                    ProjectId = projectId,
                    ImagePath = imagePath
                });
                await imageService.ResizeImg(imagePath, ProjectImageSize);
            }
        }

        public async Task<ICollection<ProjectImage>> DeleteCollection(ICollection<ProjectImage> projectImages)
        {
            _dbContext.ProjectImages.RemoveRange(projectImages);
            await _dbContext.SaveChangesAsync();
            return projectImages;
        }

        public async Task<ProjectImage> GetById(int id)
        {
            return await _dbContext.ProjectImages.FindAsync(id);
        }

        public async Task<ProjectImage> Delete(int id)
        {
            var image = await _dbContext.ProjectImages.FindAsync(id);
            _dbContext.ProjectImages.Remove(image);
            await _dbContext.SaveChangesAsync();
            return image;
        }

    }
}