using Assignment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures.DAL.Seeding
{
    public static class MockCustomer
    {
        public static void CreateCustomer(AssignmentDbContext context)
        {
            var customer1 = new Customer()
            {
                Email = "test@test.com",
                Mobile = "0912224212",
                Name = "test test",
                Transactions = new List<Transaction>()
            };

            context.Add(customer1);
            context.SaveChanges();
        }
    }
}
