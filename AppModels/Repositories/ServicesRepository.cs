using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Portofolio.Database;
using Portofolio.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Portofolio.AppModels.Services;

namespace Portofolio.AppModels.Repositories
{
    public class ServicesRepository : BaseRepository
    {
        public ServicesRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Service>> GetLatestServices(int numOfServices)
        {
            return await _dbContext.Services.OrderByDescending((serv)=>serv.CreatedAt).Take(numOfServices).ToListAsync();
        }

        public async Task<Service> GetById(int id)
        {
            return await _dbContext.Services.FindAsync(id);
        }

        public async Task<ICollection<Service>> GetAll()
        {
            return await _dbContext.Services.ToListAsync();
        }

        public async Task<Service> Create(Service service)
        {
            service.CreatedAt = DateTime.Now;
            service.UpdatedAt = DateTime.Now;
            await _dbContext.Services.AddAsync(service);
            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task<Service> Delete(int serviceId)
        {
            var service = await _dbContext.Services.FindAsync(serviceId);
            _dbContext.Services.Remove(service);
            await _dbContext.SaveChangesAsync();
            return service;
        }

        public async Task<Service> EditWithoutImage(int serviceId, Service service)
        {
            var oldService = await _dbContext.Services.FindAsync(serviceId);
            oldService.ServiceName = service.ServiceName;
            oldService.ServiceDescription = service.ServiceDescription;
            oldService.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return oldService;
        }

        public async Task<Service> EditWithImage(int serviceId, Service service)
        {
            var oldService = await _dbContext.Services.FindAsync(serviceId);
            oldService.ServiceName = service.ServiceName;
            oldService.ServiceDescription = service.ServiceDescription;
            oldService.UpdatedAt = DateTime.Now;
            oldService.ServiceImage = service.ServiceImage;
            await _dbContext.SaveChangesAsync();
            return oldService;
        }



        // public async override Task<Service> GetById(int id)
        // {
        //     return await _dbContext.Services.Include(service => service.Requests).FirstOrDefaultAsync(service => service.Id == id);
        // }

    }
}