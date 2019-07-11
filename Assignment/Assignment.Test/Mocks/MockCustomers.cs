using Assignment.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Test.Mocks
{
    public static class MockCustomers
    {
        public static List<Customer> CreateCustomers()
        {
            List<Customer> items = new List<Customer>();
            for (int i = 1; i <= 5; i++)
            {
                var item = new Customer()
                {
                    Id = 20+i,
                    Name = $"mock{i}",
                    Email = $"mock{i}@gmail.com",
                    Mobile = $"09763132{i}",
                    Transactions = new List<Transaction>()
                };
                items.Add(item);
            }
            return items;
        }

        public static List<Customer> CreateCustomersAndTransactions()
        {
            Random random = new Random();
            List<Customer> items = new List<Customer>();
            for (int i = 1; i <= 5; i++)
            {
                var item = new Customer()
                {
                    Id = i,
                    Name = $"mockcustomertransaction{i}",
                    Email = $"mockcustomertransaction{i}@gmail.com",
                    Mobile = $"09761132{i}"
                };

                var transactionList = new List<Transaction>
                {
                    new Transaction()
                    {
                        CustomerId = item.Id,
                        Customer = item,
                        Date = DateTime.Now.AddDays(-1),
                        Amount = (decimal)1234.56 + (1 * random.Next(10, 50)),
                        Currency = "USD",
                        Status = TransactionStatus.Success
                    },
                    new Transaction()
                    {
                        CustomerId = item.Id,
                        Customer = item,
                        Date = DateTime.Now.AddDays(-2).AddHours(-5),
                        Amount = (decimal)14.16 + (2 * random.Next(10, 50)),
                        Currency = "THB",
                        Status = TransactionStatus.Failed
                    },
                    new Transaction()
                    {
                        CustomerId = item.Id,
                        Customer = item,
                        Date = DateTime.Now.AddDays(-3).AddHours(-3),
                        Amount = (decimal)109.07 + (3 * random.Next(10, 50)),
                        Currency = "JPY",
                        Status = TransactionStatus.Canceled
                    }
                };
                item.Transactions = transactionList;

                items.Add(item);
            }
            return items;
        }
    }

}
