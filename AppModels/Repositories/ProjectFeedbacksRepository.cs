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
    public class ProjectFeedbacksRepository : BaseRepository
    {
        public ProjectFeedbacksRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ProjectFeedback> Create(ProjectFeedback feedback)
        {
            feedback.CreatedAt = DateTime.Now;
            await _dbContext.ProjectFeedbacks.AddAsync(feedback);
            await _dbContext.SaveChangesAsync();
            return feedback;
        }

        public async Task<ICollection<ProjectFeedback>> DeleteCollection(ICollection<ProjectFeedback> feedbacks)
        {
            _dbContext.ProjectFeedbacks.RemoveRange(feedbacks);
            await _dbContext.SaveChangesAsync();
            return feedbacks;
        }

    }
}