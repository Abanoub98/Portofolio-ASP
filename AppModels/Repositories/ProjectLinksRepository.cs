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
    public class ProjectLinksRepository : BaseRepository
    {
        public ProjectLinksRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectLink> Create(ProjectLink link)
        {
            link.CreatedAt = DateTime.Now;
            link.UpdatedAt = DateTime.Now;
            await _dbContext.ProjectLinks.AddAsync(link);
            await _dbContext.SaveChangesAsync();
            return link;
        }

        public async Task<ProjectLink> Edit(int id, ProjectLink newLink)
        {
            var link = await _dbContext.ProjectLinks.FindAsync(id);
            link.Link = newLink.Link;
            link.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return link;
        }

        public async Task CreateFromCollection(int projectId, ICollection<int> linkTypesIds, ICollection<string> links)
        {
            for(int i = 0; i < links.Count; i++)
            {
                var link = new ProjectLink{
                    ProjectId = projectId,
                    TypeId = linkTypesIds.ElementAt(i)
                };
                if(links.ElementAt(i) != default(string))
                {
                    link.Link = links.ElementAt(i);
                }
                await Create(link);
            }
        }

        public async Task EditFromCollection(ICollection<int> linksIds, ICollection<string> links)
        {
            for(int i = 0; i < linksIds.Count; i++)
            {
                await Edit(linksIds.ElementAt(i), new ProjectLink
                {
                    Link = links.ElementAt(i)
                });
            }
        }

        public async Task<ICollection<ProjectLink>> DeleteCollection(ICollection<ProjectLink> links)
        {
            _dbContext.ProjectLinks.RemoveRange(links);
            await _dbContext.SaveChangesAsync();
            return links;
        }

    }
}