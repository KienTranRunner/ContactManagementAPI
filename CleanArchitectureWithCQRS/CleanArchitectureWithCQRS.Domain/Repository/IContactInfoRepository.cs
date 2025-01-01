using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;

namespace CleanArchitectureWithCQRS.Domain.Repository
{
    public interface IContactInfoRepository : IRepository<ContactInfo>
    {
        Task<IEnumerable<ContactInfo>> GetByContactNameAsync(string contactName);
        Task<IEnumerable<ContactInfo>> GetByContactEmailAsync(string email);
    }
}