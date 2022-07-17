using Portofolio.Database;
using Portofolio.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Portofolio.AppModels.Repositories
{
    public class ProjectTypeRepository : BaseRepository
    {
        public ProjectTypeRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<ProjectType>> GetAll()
        {
            return await _dbContext.ProjectTypes.ToListAsync();
        }


        // public async override Task<ProjectType> GetById(int id)
        // {
        //     return await _dbContext.ProjectTypes.Include(pt => pt.Projects).FirstOrDefaultAsync(pt => pt.Id == id);
        // }
    }
}