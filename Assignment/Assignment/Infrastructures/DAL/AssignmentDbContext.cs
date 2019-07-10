using Assignment.Core.Domain.Base;
using Assignment.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures.DAL
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext()
        {

        }

        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options)
        {
           
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.MapCustomer();
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            AddEntityData();
            var result = base.SaveChanges();
            return result;
        }

        private void AddEntityData()
        {
            if (this.ChangeTracker != null && this.ChangeTracker.Entries() != null)
            {
                var entities = this.ChangeTracker.Entries().Where(x => x.Entity is EntityBase<int> && (x.State == EntityState.Added || x.State == EntityState.Modified)).ToList();

                foreach (var entity in entities)
                {
                    if (entity.State == EntityState.Added)
                    {
                        ((EntityBase<int>)entity.Entity).CreatedDate = DateTime.UtcNow;
                        ((EntityBase<int>)entity.Entity).UpdatedDate = DateTime.UtcNow;
                    }
                    else
                        ((EntityBase<int>)entity.Entity).UpdatedDate = DateTime.UtcNow;
                }
            }
        }


    }
}
