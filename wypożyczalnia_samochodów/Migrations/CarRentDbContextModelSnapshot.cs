﻿// <auto-generated />
using System;
using CarRent.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRent.Migrations
{
    [DbContext(typeof(CarRentDbContext))]
    partial class CarRentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarRent.Entites.Car", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CarRentalid")
                        .HasColumnType("int");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("combustion")
                        .HasColumnType("real");

                    b.Property<bool>("isCar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("localization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("id");

                    b.HasIndex("CarRentalid");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarRent.Entites.CarRental", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.HasKey("id");

                    b.ToTable("CarRents");
                });

            modelBuilder.Entity("CarRent.Entites.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("postalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CarRent.Entites.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int?>("CarRentalid")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("id");

                    b.HasIndex("CarRentalid");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CarRent.Entites.Rent", b =>
                {
                    b.Property<int>("carId")
                        .HasColumnType("int");

                    b.Property<int>("customerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("from")
                        .HasColumnType("datetime2");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<DateTime>("to")
                        .HasColumnType("datetime2");

                    b.HasKey("carId", "customerId");

                    b.HasIndex("customerId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("CarRent.Entites.Car", b =>
                {
                    b.HasOne("CarRent.Entites.CarRental", null)
                        .WithMany("cars")
                        .HasForeignKey("CarRentalid");
                });

            modelBuilder.Entity("CarRent.Entites.Customer", b =>
                {
                    b.HasOne("CarRent.Entites.Employee", "employee")
                        .WithMany("customers")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("CarRent.Entites.Employee", b =>
                {
                    b.HasOne("CarRent.Entites.CarRental", null)
                        .WithMany("employees")
                        .HasForeignKey("CarRentalid");
                });

            modelBuilder.Entity("CarRent.Entites.Rent", b =>
                {
                    b.HasOne("CarRent.Entites.Car", "car")
                        .WithMany()
                        .HasForeignKey("carId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarRent.Entites.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("car");

                    b.Navigation("customer");
                });

            modelBuilder.Entity("CarRent.Entites.CarRental", b =>
                {
                    b.Navigation("cars");

                    b.Navigation("employees");
                });

            modelBuilder.Entity("CarRent.Entites.Employee", b =>
                {
                    b.Navigation("customers");
                });
#pragma warning restore 612, 618
        }
    }
}
