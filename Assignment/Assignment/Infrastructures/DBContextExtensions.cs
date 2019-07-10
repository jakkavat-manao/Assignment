using Assignment.Infrastructures.DAL;
using Assignment.Infrastructures.DAL.Seeding;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Infrastructures
{
    public static class DBContextExtensions
    {
        public static bool AllMigrationsApplied(this AssignmentDbContext context)
        {
            var applied = context.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = context.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public static void EnsureSeeded(this AssignmentDbContext context)
        {
            MockCustomer.CreateCustomer(context);
        }

    }
}
