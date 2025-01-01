using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureWithCQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureWithCQRS.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ContactInfo> ContactInfo { get; set; }
    }
}