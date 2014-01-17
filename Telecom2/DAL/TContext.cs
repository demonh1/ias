using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Telecom2.Models;

namespace Telecom2.DAL
{
    public class TContext : DbContext
    {
        public DbSet<Request> Requests { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<OpenCode> OpenCodes { get; set; }
        public DbSet<DamageCode> DamageCodes { get; set; }
        public DbSet<CloseCode> CloseCodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}