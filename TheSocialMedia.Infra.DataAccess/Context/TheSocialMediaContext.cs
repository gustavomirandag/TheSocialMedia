using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheSocialMedia.Domain.AggregatesModel.ProfileAggregate;

namespace TheSocialMedia.Infra.DataAccess.Context
{
    public class TheSocialMediaContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public TheSocialMediaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TheSocialMediaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
