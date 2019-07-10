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

        public DbSet<Customer> CustomersDbSet { get; set; }
        public DbSet<Transaction> TransactionsDbSet { get; set; }

    }
}
