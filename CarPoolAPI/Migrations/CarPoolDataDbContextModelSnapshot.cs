﻿// <auto-generated />
using System;
using CarPoolDbContext.CarpoolData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarPoolAPI.Migrations
{
    [DbContext(typeof(CarPoolDataDbContext))]
    partial class CarPoolDataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarPoolModels.Models.BookedRide", b =>
                {
                    b.Property<Guid>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BookedSeats")
                        .HasColumnType("int");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OfferedRideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BookingId");

                    b.HasIndex("OfferedRideId");

                    b.HasIndex("UserId");

                    b.ToTable("BookedRides");
                });

            modelBuilder.Entity("CarPoolModels.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LocationId"));

                    b.Property<string>("LocationName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("CarPoolModels.Models.OfferedRide", b =>
                {
                    b.Property<Guid>("OfferedRideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destination")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OfferedRideId");

                    b.HasIndex("UserId");

                    b.ToTable("OfferedRides");
                });

            modelBuilder.Entity("CarPoolModels.Models.Stoppage", b =>
                {
                    b.Property<int>("StoppageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoppageId"));

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<Guid>("OfferedRideId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StoppageNo")
                        .HasColumnType("int");

                    b.HasKey("StoppageId");

                    b.HasIndex("LocationId");

                    b.HasIndex("OfferedRideId");

                    b.ToTable("Stoppages");
                });

            modelBuilder.Entity("CarPoolModels.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CarPoolModels.Models.BookedRide", b =>
                {
                    b.HasOne("CarPoolModels.Models.OfferedRide", "OfferedRide")
                        .WithMany("BookedRids")
                        .HasForeignKey("OfferedRideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolModels.Models.User", "User")
                        .WithMany("BookedRides")
                        .HasForeignKey("UserId");

                    b.Navigation("OfferedRide");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarPoolModels.Models.OfferedRide", b =>
                {
                    b.HasOne("CarPoolModels.Models.User", "User")
                        .WithMany("OfferedRides")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarPoolModels.Models.Stoppage", b =>
                {
                    b.HasOne("CarPoolModels.Models.Location", "Locations")
                        .WithMany("Stoppage")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPoolModels.Models.OfferedRide", "OfferedRides")
                        .WithMany("Stoppages")
                        .HasForeignKey("OfferedRideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locations");

                    b.Navigation("OfferedRides");
                });

            modelBuilder.Entity("CarPoolModels.Models.Location", b =>
                {
                    b.Navigation("Stoppage");
                });

            modelBuilder.Entity("CarPoolModels.Models.OfferedRide", b =>
                {
                    b.Navigation("BookedRids");

                    b.Navigation("Stoppages");
                });

            modelBuilder.Entity("CarPoolModels.Models.User", b =>
                {
                    b.Navigation("BookedRides");

                    b.Navigation("OfferedRides");
                });
#pragma warning restore 612, 618
        }
    }
}
