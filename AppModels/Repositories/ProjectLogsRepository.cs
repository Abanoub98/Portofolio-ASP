using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Portofolio.Database;
using Portofolio.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Portofolio.AppModels.Repositories
{
    public class ProjectLogsRepository : BaseRepository
    {
        public ProjectLogsRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectLog> Create(ProjectLog log)
        {
            log.CreatedAt = DateTime.Now;
            await _dbContext.ProjectLogs.AddAsync(log);
            await _dbContext.SaveChangesAsync();
            return log;
        }

        public async Task<ICollection<ProjectLog>> GetAll()
        {
            return await _dbContext.ProjectLogs.OrderByDescending((log) => log.CreatedAt).ToListAsync();
        }


    }
}