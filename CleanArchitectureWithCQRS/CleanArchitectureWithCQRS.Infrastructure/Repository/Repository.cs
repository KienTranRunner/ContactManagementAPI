using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Repository;
using CleanArchitectureWithCQRS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithCQRS.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly AppDbContext appdbcontext;
        private readonly DbSet<T> enities;

        public Repository(AppDbContext context)
        {
            this.appdbcontext = context;
            enities = appdbcontext.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            await enities.AddAsync(entity);
            return entity;
        }


        public void DeleteAsync(T entity)
        {
            enities.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await enities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await enities.FindAsync(id);

            if (entity == null)
            {
                return null!;
            }
            return entity;
        }

        public async Task SaveChangesAsync()
        {
            await appdbcontext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            enities.Update(entity);

            return entity;
        }


    }
}