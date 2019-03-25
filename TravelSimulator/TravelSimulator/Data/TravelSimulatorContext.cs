using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TravelSimulator.Data.Models;
using TravelSimulator.Models;

namespace TravelSimulator.Data
{
    public class TravelSimulatorContext : DbContext
    {
        public TravelSimulatorContext()
        { }

        public TravelSimulatorContext(DbContextOptions options)
            :base(options)
        { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString).UseLazyLoadingProxies();
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
