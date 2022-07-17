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
    public class UserLinksRepository : BaseRepository
    {
        public UserLinksRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserLink> Edit(int id, UserLink newLink)
        {
            var link = await _dbContext.UserLinks.FindAsync(id);
            link.UpdatedAt = DateTime.Now;
            link.Link = newLink.Link;
            await _dbContext.SaveChangesAsync();
            return link;
        }

        public async Task<UserLink> Create(UserLink newLink)
        {
            newLink.CreatedAt = DateTime.Now;
            newLink.UpdatedAt = DateTime.Now;
            await _dbContext.UserLinks.AddAsync(newLink);
            await _dbContext.SaveChangesAsync();
            return newLink;
        }

        public async Task CreateUserLinks(ICollection<string> links, ICollection<int> linkTypeIds, int userId)
        {
            for (int i = 0; i < links.Count; i++)
            {
                var newUserLink = new UserLink
                {
                    UserId = userId,
                    TypeId = linkTypeIds.ElementAt(i),
                };
                if(links.ElementAt(i) != default(string))
                {
                    newUserLink.Link = links.ElementAt(i);
                }
                await Create(newUserLink);
            }
        }

        public async Task EditUserLinks(ICollection<string> links, ICollection<int> ids)
        {
            for (int i = 0; i < links.Count; i++)
            {
                var newUserLink = new UserLink
                {
                    Link = links.ElementAt(i),
                    Id = ids.ElementAt(i)
                };
                await Edit(ids.ElementAt(i), newUserLink);
            }
        }

        public async Task<ICollection<UserLink>> GetUserLinks(int userId)
        {
            return await _dbContext.UserLinks.Include((link) => link.Type).Where((link) => link.UserId == userId).ToListAsync();
        }

        public async Task<ICollection<UserLink>> DeleteCollection(ICollection<UserLink> userLinks)
        {
            _dbContext.UserLinks.RemoveRange(userLinks);
            await _dbContext.SaveChangesAsync();
            return userLinks;
        }

    }
}