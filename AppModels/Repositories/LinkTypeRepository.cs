using System.Threading.Tasks;
using System.Collections.Generic;
using Portofolio.Models;
using Portofolio.Database;
using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
namespace Portofolio.AppModels.Repositories
{
    public class LinkTypesRepository : BaseRepository
    {
        public LinkTypesRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<LinkType>> GetAll()
        {
            return await _dbContext.LinkTypes.ToListAsync();
        }
    }
}