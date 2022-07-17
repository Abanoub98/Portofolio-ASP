using Portofolio.Database;
using System.Threading.Tasks;
using Portofolio.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Portofolio.AppModels.Repositories
{
    public class UserCertificatesRepository : BaseRepository
    {
        public UserCertificatesRepository(PortofolioDbContext dbContext) : base(dbContext){}

        public async Task<ICollection<UserCertificates>> GetUsersCertificates(int userId)
        {
            return await _dbContext.UsersCertificates.Where((cert) => cert.UserId == userId).ToListAsync();
        }

        public async Task<ICollection<UserCertificates>> DeleteCollection(ICollection<UserCertificates> certificates)
        {
            _dbContext.UsersCertificates.RemoveRange(certificates);
            await _dbContext.SaveChangesAsync();
            return certificates;
        }
    }
}