using Assignment.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures.DAL.EF.Mappings
{
    public static class TransactionMap
    {
        public static ModelBuilder MapTransaction(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Transaction>();
            entity.Property(c => c.Id).ValueGeneratedOnAdd();
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);

            entity.Property(c => c.Date);
            entity.Property(c => c.Amount);
            entity.Property(c => c.Currency);
            entity.Property(c => c.Status);

            entity.HasOne(c => c.Customer).WithMany(x => x.Transactions).HasForeignKey(c => c.CustomerId);
            return modelBuilder;
        }
    }
}
