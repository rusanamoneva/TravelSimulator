﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelSimulator.Data;

namespace TravelSimulator.Migrations
{
    [DbContext(typeof(TravelSimulatorContext))]
    partial class TravelSimulatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelSimulator.Data.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelName");

                    b.Property<decimal>("PricePerNight");

                    b.Property<int>("Stars");

                    b.Property<int>("TownId");

                    b.HasKey("Id");

                    b.HasIndex("TownId");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("TravelSimulator.Data.Models.Voucher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CancellationPeriod");

                    b.Property<int>("DaysOfTrip");

                    b.Property<DateTime>("EndDate");

                    b.Property<int>("HotelId");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("TouristId");

                    b.Property<decimal>("TripPrice");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("TouristId");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("TravelSimulator.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("TravelSimulator.Models.Tourist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age");

                    b.Property<string>("CountryName");

                    b.Property<string>("TouristFirstName");

                    b.Property<string>("TouristLastName");

                    b.HasKey("Id");

                    b.ToTable("Tourists");
                });

            modelBuilder.Entity("TravelSimulator.Models.Town", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId");

                    b.Property<string>("TownName");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Towns");
                });

            modelBuilder.Entity("TravelSimulator.Data.Models.Hotel", b =>
                {
                    b.HasOne("TravelSimulator.Models.Town", "Town")
                        .WithMany("Hotels")
                        .HasForeignKey("TownId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelSimulator.Data.Models.Voucher", b =>
                {
                    b.HasOne("TravelSimulator.Data.Models.Hotel", "Hotel")
                        .WithMany("Vouchers")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelSimulator.Models.Tourist", "Tourist")
                        .WithMany("Vouchers")
                        .HasForeignKey("TouristId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelSimulator.Models.Town", b =>
                {
                    b.HasOne("TravelSimulator.Models.Country", "Country")
                        .WithMany("Towns")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
