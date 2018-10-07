using Microsoft.EntityFrameworkCore;
using MyNextMatch.Core.Settings;
using MyNextMatch.Entities.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNextMatch.DataAccess.Services
{
    public class MyNextMatchDatabaseContext : DbContext
    {
    // yapının ileride her databas eile çalışabilmesi için.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (ManagerSettings.ContextDbType)
            {
                //case "MsSql":
                //    optionsBuilder.UseSqlServer(ManagerSettings.ContexConnectionString);
                //    break;

                case "SqLite":
                    optionsBuilder.UseSqlite(ManagerSettings.ContexConnectionString);
                    break;

                //case "MySql":
                //    optionsBuilder.UseMySql(ManagerSettings.ContexConnectionString);
                //    break;
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

    }
}
