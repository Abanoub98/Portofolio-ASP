using Portofolio.Database;

namespace Portofolio.AppModels.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly PortofolioDbContext _dbContext;

        public BaseRepository(PortofolioDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}