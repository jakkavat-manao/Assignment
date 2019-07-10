using Assignment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures.DAL.EF.Seeding
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

            var customer2 = new Customer()
            {
                Email = "jakkavat@test.com",
                Mobile = "0914356894",
                Name = "jakkavat manao",
                Transactions = new List<Transaction>()
            };

            var customer3 = new Customer()
            {
                Email = "jakkavat_test@test.com",
                Mobile = "0914356895",
                Name = "jakkavat manao2",
                Transactions = new List<Transaction>()
            };


            context.Add(customer1);
            context.Add(customer2);
            context.Add(customer3);
            context.SaveChanges();
        }
    }
}
