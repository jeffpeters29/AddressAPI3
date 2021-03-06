﻿// <auto-generated />
using System;
using AddressAPI3.EFData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressAPI3.EFData.Migrations
{
    [DbContext(typeof(AddressContext))]
    [Migration("20180914134643_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressAPI3.EFData.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Number");

                    b.Property<string>("Organisation")
                        .HasMaxLength(100);

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("UDPRN")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });
#pragma warning restore 612, 618
        }
    }
}
