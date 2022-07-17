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
    public class ProjectsRepository : BaseRepository
    {
        public ProjectsRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Project>> GetLatestProjects(int numOfProjects)
        {
            return await _dbContext.Projects.Include(project => project.Creator).OrderByDescending((proj) => proj.CreatedAt).Take(numOfProjects).ToListAsync();
        }

        public async Task<ICollection<Project>> GetAll()
        {
            return await _dbContext.Projects.Include(project => project.Creator).OrderByDescending((proj) => proj.CreatedAt).ToListAsync();
        }

        public async Task<Project> GetByIdWithInclude(int id)
        {
            return await _dbContext.Projects.Include(project => project.Type)
            .Include(project => project.ProjectFeedbacks)
            .Include(project => project.ProjectLinks).ThenInclude(projectLink => projectLink.Type)
            .Include(project => project.ProjectImages)
            .Include(Project => Project.UsersInProjects).ThenInclude(usersInProject => usersInProject.User)
            .Include(project => project.UsersInProjects).ThenInclude(usersInProject => usersInProject.Role)
            .OrderByDescending(project => project.CreatedAt).FirstOrDefaultAsync(project => project.Id == id);
        }

        public async Task<Project> GetByIdNoInclude(int id)
        {
            return await _dbContext.Projects.FindAsync(id);
        }

        public async Task<Project> Create(Project project)
        {
            project.CreatedAt = DateTime.Now;
            project.UpdatedAt = DateTime.Now;
            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> AddThumbnail(int projectId, string path)
        {
            var project = await _dbContext.Projects.FindAsync(projectId);
            project.Thumbnail = path;
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<Project> Delete(int projectId)
        {
            var project = await _dbContext.Projects.FindAsync(projectId);
            _dbContext.Projects.Remove(project);
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<ICollection<Project>> DeleteCollection(ICollection<Project> projects)
        {
            _dbContext.Projects.RemoveRange(projects);
            await _dbContext.SaveChangesAsync();
            return projects;
        }

        public async Task<Project> Edit(int projectId, Project newProject)
        {
            var project = await _dbContext.Projects.FindAsync(projectId);
            project.TypeId = newProject.TypeId;
            project.Title = newProject.Title;
            project.UpdatedAt = DateTime.Now;
            project.ToolsUsed = newProject.ToolsUsed;
            project.Description = newProject.Description;
            await _dbContext.SaveChangesAsync();
            return project;
        }

        public async Task<ICollection<Project>> GetUserCreatedProjects(int userId)
        {
            return await _dbContext.Projects.Include(project => project.Creator).Where((project) => project.CreatorId == userId).ToListAsync();
        }

    }
}