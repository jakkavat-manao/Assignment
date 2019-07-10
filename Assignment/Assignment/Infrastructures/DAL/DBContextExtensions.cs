using Assignment.Infrastructures.DAL;
using Assignment.Infrastructures.DAL.Seeding;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures.DAL
{
    public static class DBContextExtensions
    {
        public static void EnsureSeeded(this AssignmentDbContext context)
        {
            MockCustomer.CreateCustomer(context);
            MockTransaction.CreateTransaction(context);
        }

    }
}
