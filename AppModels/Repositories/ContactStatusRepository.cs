using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Portofolio.Database;
using Portofolio.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using static Portofolio.AppModels.Utils.Constants;
namespace Portofolio.AppModels.Repositories
{
    public class ContactStatusRepository : BaseRepository
    {
        public ContactStatusRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<ContactStatus>> GetAll()
        {
            return await _dbContext.ContactStatuses.ToListAsync();
        }

    }
}