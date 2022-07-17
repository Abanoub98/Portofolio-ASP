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
    public class UserRoleInProjectRepository : BaseRepository
    {
        public UserRoleInProjectRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<UserRoleInProject>> GetAll()
        {
            return await _dbContext.UserProjectRoles.ToListAsync();
        }

        public async Task<UserRoleInProject> GetTeamLeaderRole()
        {
            return await _dbContext.UserProjectRoles.Where((urip) => urip.Role == TeamLeaderRole).FirstOrDefaultAsync();
        }

        
    }
}