﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sda2.Masterdata.Persistance;

#nullable disable

namespace Sda2.Masterdata.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241104104818_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeInfoStore", b =>
                {
                    b.Property<int>("EmployeeInfosEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("StoresSID")
                        .HasColumnType("int");

                    b.HasKey("EmployeeInfosEmployeeId", "StoresSID");

                    b.HasIndex("StoresSID");

                    b.ToTable("EmployeeInfoStore");
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.CustomerInfo", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("PhoneNumber")
                        .HasColumnType("float");

                    b.Property<float>("Rewards")
                        .HasColumnType("real");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("CustomerInfos");
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<double>("PhoneNumber")
                        .HasColumnType("float");

                    b.Property<int>("PinNumber")
                        .HasColumnType("int");

                    b.Property<double>("Snn")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("UserId")
                        .HasColumnType("float");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId");

                    b.ToTable("EmployeeInfos");
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.RegistersTable", b =>
                {
                    b.Property<int>("RegisterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RegisterId"));

                    b.Property<int?>("CloseEmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CloseTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("CloseTotal")
                        .HasColumnType("real");

                    b.Property<int?>("DropEmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DropTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("DropTotal")
                        .HasColumnType("real");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("OpenEmpId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenTime")
                        .HasColumnType("datetime2");

                    b.Property<float>("OpenTotal")
                        .HasColumnType("real");

                    b.Property<int>("RegisterNum")
                        .HasColumnType("int");

                    b.HasKey("RegisterId");

                    b.HasIndex("CloseEmpId");

                    b.HasIndex("DropEmpId");

                    b.HasIndex("OpenEmpId");

                    b.ToTable("RegistersTables");
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.Store", b =>
                {
                    b.Property<int>("SID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SID"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SID");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("EmployeeInfoStore", b =>
                {
                    b.HasOne("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", null)
                        .WithMany()
                        .HasForeignKey("EmployeeInfosEmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sda2.Masterdata.Persistance.Entities.Store", null)
                        .WithMany()
                        .HasForeignKey("StoresSID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.CustomerInfo", b =>
                {
                    b.HasOne("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", "EmployeeInfo")
                        .WithMany("Customers")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeInfo");
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.RegistersTable", b =>
                {
                    b.HasOne("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", "CloseEmployee")
                        .WithMany("CloseRegisters")
                        .HasForeignKey("CloseEmpId");

                    b.HasOne("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", "DropEmployee")
                        .WithMany("DropRegisters")
                        .HasForeignKey("DropEmpId");

                    b.HasOne("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", "OpenEmployee")
                        .WithMany("OpenRegisters")
                        .HasForeignKey("OpenEmpId");

                    b.Navigation("CloseEmployee");

                    b.Navigation("DropEmployee");

                    b.Navigation("OpenEmployee");
                });

            modelBuilder.Entity("Sda2.Masterdata.Persistance.Entities.EmployeeInfo", b =>
                {
                    b.Navigation("CloseRegisters");

                    b.Navigation("Customers");

                    b.Navigation("DropRegisters");

                    b.Navigation("OpenRegisters");
                });
#pragma warning restore 612, 618
        }
    }
}
