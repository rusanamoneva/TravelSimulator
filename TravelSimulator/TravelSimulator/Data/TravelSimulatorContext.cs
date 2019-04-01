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

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<Tourist> Tourists { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString).UseLazyLoadingProxies();
                //optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
