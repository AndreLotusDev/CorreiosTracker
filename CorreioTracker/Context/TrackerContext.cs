using CorreioTracker.Context.DbSchemas;
using CorreioTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.Context
{
    public class TrackerContext : DbContext
    {
        public TrackerContext(DbContextOptions<TrackerContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            OnConfigure configure = new OnConfigure(optionsBuilder);

            configure.Start();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelConfiguring modeling = new OnModelConfiguring(modelBuilder);

            modeling.Start();

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserPackage> UserPackages { get; set; }
    }
}
