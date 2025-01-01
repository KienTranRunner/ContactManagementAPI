using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using CleanArchitectureWithCQRS.Domain.Repository;
using CleanArchitectureWithCQRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithCQRS.Infrastructure.Repository
{
    public class ContactInfoRepository : Repository<ContactInfo>, IContactInfoRepository
    {
        private readonly AppDbContext appDbContext;
        public ContactInfoRepository(AppDbContext context) : base(context)
        {
            this.appDbContext = context;
        }

        public async Task<IEnumerable<ContactInfo>> GetByContactEmailAsync(string email)
        {
            return await appDbContext.ContactInfo
            .Where(e => e.Email.Contains(email))
            .ToListAsync();
        }

        public async Task<IEnumerable<ContactInfo>> GetByContactNameAsync(string contactName)
        {
            
            return await appDbContext.ContactInfo
                .Where(c => c.ContactName.Contains(contactName))
                .ToListAsync();
        }
    }
}