﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Podium.Data;

namespace Podium.Data.Migrations
{
    [DbContext(typeof(PodiumDbContext))]
    [Migration("20200825202053_ChangedIDs")]
    partial class ChangedIDs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Podium.Data.Primitives.Entities.LoanCalculation", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PropertyDetailsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UserDetailsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyDetailsId");

                    b.HasIndex("UserDetailsId");

                    b.ToTable("LoanCalculations");
                });

            modelBuilder.Entity("Podium.Data.Primitives.Entities.Product", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("InterestRate")
                        .HasColumnType("float");

                    b.Property<string>("Lender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanCalculationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("LoanToValue")
                        .HasColumnType("float");

                    b.Property<int>("LoanType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LoanCalculationId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Podium.Data.Primitives.Entities.PropertyDetails", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("DepositAmount")
                        .HasColumnType("float");

                    b.Property<double>("PropertyValue")
                        .HasColumnType("float");

                    b.Property<string>("UserDetailsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserDetailsId");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("Podium.Data.Primitives.Entities.UserDetails", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Podium.Data.Primitives.Entities.LoanCalculation", b =>
                {
                    b.HasOne("Podium.Data.Primitives.Entities.PropertyDetails", "PropertyDetails")
                        .WithMany()
                        .HasForeignKey("PropertyDetailsId");

                    b.HasOne("Podium.Data.Primitives.Entities.UserDetails", "UserDetails")
                        .WithMany()
                        .HasForeignKey("UserDetailsId");
                });

            modelBuilder.Entity("Podium.Data.Primitives.Entities.Product", b =>
                {
                    b.HasOne("Podium.Data.Primitives.Entities.LoanCalculation", null)
                        .WithMany("Products")
                        .HasForeignKey("LoanCalculationId");
                });

            modelBuilder.Entity("Podium.Data.Primitives.Entities.PropertyDetails", b =>
                {
                    b.HasOne("Podium.Data.Primitives.Entities.UserDetails", null)
                        .WithMany("PropertyDetailses")
                        .HasForeignKey("UserDetailsId");
                });
#pragma warning restore 612, 618
        }
    }
}
