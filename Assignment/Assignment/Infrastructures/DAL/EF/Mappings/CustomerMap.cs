using Assignment.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures.DAL.EF.Mappings
{
    public static class CustomerMap
    {
        public static ModelBuilder MapCustomer(this ModelBuilder modelBuilder)
        {
            var entity = modelBuilder.Entity<Customer>();
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasMaxLength(10);
            entity.Property(c => c.CreatedDate);
            entity.Property(c => c.UpdatedDate);

            entity.Property(c => c.Name).HasMaxLength(30);
            entity.Property(c => c.Email).HasMaxLength(25);
            entity.Property(c => c.Mobile).HasMaxLength(10);

            return modelBuilder;
        }
    }
}
