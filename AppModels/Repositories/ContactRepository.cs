using Portofolio.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Portofolio.Database;
using System.Linq;
using System;
using static Portofolio.AppModels.Utils.Constants;
namespace Portofolio.AppModels.Repositories
{
    public class ContactRepository : BaseRepository
    {
        public ContactRepository(PortofolioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Contact> Create(Contact contact)
        {
            var pendingId = await _dbContext.ContactStatuses.Where((cs) => cs.Status == ContactStatuses.Pending.ToString()).Select((cs) => cs.Id).FirstOrDefaultAsync();
            if(pendingId != default(int))
            {
                contact.StatusId = pendingId;
            }
            contact.CreatedAt = DateTime.Now;
            contact.UpdatedAt = DateTime.Now;
            await _dbContext.Contacts.AddAsync(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> GetById(int id)
        {
            return await _dbContext.Contacts.Include(con => con.RequestedServices).ThenInclude(reqService => reqService.AssociatedService).Where(con => con.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> PendingContactsCount()
        {
            var pendingContacts = await _dbContext.Contacts.Where((contact) => contact.Status.Status == ContactStatuses.Pending.ToString()).ToListAsync();
            return pendingContacts.Count;
        }

        public async Task<Contact> Edit(int id, int statusId)
        {
            var oldContact = await _dbContext.Contacts.FindAsync(id);
            oldContact.StatusId = statusId;
            oldContact.UpdatedAt = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return oldContact;
        }

        public async Task<Contact> Delete(Contact contact)
        {
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
            return contact;
        }

        public async Task<ICollection<Contact>> GetAll()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task<ICollection<Contact>> GetAllOrderedByUpdateTime()
        {
            return await _dbContext.Contacts.Include((con) => con.Status).OrderByDescending((con)=>con.UpdatedAt).ToListAsync();
        }

        


    }
}