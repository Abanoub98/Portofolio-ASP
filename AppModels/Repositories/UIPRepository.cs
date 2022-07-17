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
    public class UIPRepository : BaseRepository
    {
        public UIPRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UsersInProject> Create(UsersInProject usersInProject)
        {
            usersInProject.CreatedAt = DateTime.Now;
            usersInProject.UpdatedAt = DateTime.Now;
            await _dbContext.UsersInProjects.AddAsync(usersInProject);
            await _dbContext.SaveChangesAsync();
            return usersInProject;
        }

        public async Task<UsersInProject> Edit(int id, UsersInProject newUsersInProject)
        {
            var uip = await _dbContext.UsersInProjects.FindAsync(id);
            uip.UpdatedAt = DateTime.Now;
            uip.UserId = newUsersInProject.UserId;
            uip.RoleId = newUsersInProject.RoleId;
            await _dbContext.SaveChangesAsync();
            return uip;
        }

        public async Task CreateFromCollection(int projectId, ICollection<string> usersNRolesIds, char delimiter)
        {
            foreach (var str in usersNRolesIds)
            {
                string[] splitStr = str.Split(delimiter);
                await Create(new UsersInProject
                {
                    ProjectId = projectId,
                    UserId = Convert.ToInt32(splitStr[1]),
                    RoleId = Convert.ToInt32(splitStr[0])
                });
            }
        }

        public async Task EditFromCollection(ICollection<UsersInProject> usersInProjects, ICollection<string> usersNRolesIds, char delimiter)
        {
            for (int i = 0; i < usersNRolesIds.Count; i++)
            {
                string[] splitStr = usersNRolesIds.ElementAt(i).Split(delimiter);
                await Edit(usersInProjects.ElementAt(i).Id, new UsersInProject
                {
                    UserId = Convert.ToInt32(splitStr[1]),
                    RoleId = Convert.ToInt32(splitStr[0])
                });
            }
        }

        public async Task<ICollection<UsersInProject>> GetUsersProjects(int userId)
        {
            return await _dbContext.UsersInProjects.Where((uip) => uip.UserId == userId).ToListAsync();
        }

        public async Task<ICollection<UsersInProject>> GetUsersProjectsWithIncludes(int userId)
        {
            return await _dbContext.UsersInProjects.Include((uip) => uip.Project).Include((uip) => uip.Role)
            .Where((uip) => uip.UserId == userId).ToListAsync();
        }

        public async Task<ICollection<UsersInProject>> GetProjectUips(int projectId)
        {
            return await _dbContext.UsersInProjects.Include((uip) => uip.Role).Include((uip) => uip.Project).Where((uip) => uip.ProjectId == projectId).ToListAsync();
        }
        public async Task<ICollection<UsersInProject>> DeleteCollection(ICollection<UsersInProject> uips)
        {
            _dbContext.UsersInProjects.RemoveRange(uips);
            await _dbContext.SaveChangesAsync();
            return uips;
        }

        public async Task<UsersInProject> Delete(int id)
        {
            var uip = await _dbContext.UsersInProjects.FindAsync(id);
            _dbContext.UsersInProjects.Remove(uip);
            await _dbContext.SaveChangesAsync();
            return uip;
        }

        


    }
}