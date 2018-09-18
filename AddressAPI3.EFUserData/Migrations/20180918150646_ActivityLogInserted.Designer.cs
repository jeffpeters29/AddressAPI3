﻿// <auto-generated />
using System;
using AddressAPI3.EFUserData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AddressAPI3.EFUserData.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20180918150646_ActivityLogInserted")]
    partial class ActivityLogInserted
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-preview2-35157")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AddressAPI3.EFUserData.Entities.ActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ElapsedTime");

                    b.Property<DateTime>("Inserted");

                    b.Property<string>("Referer")
                        .IsRequired();

                    b.Property<string>("SearchTerm")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("ActivityLogs");
                });

            modelBuilder.Entity("AddressAPI3.EFUserData.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<DateTime>("Inserted")
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<DateTime>("Updated");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, FirstName = "Eddie", Inserted = new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), LastName = "Eagle", PasswordHash = "Da21ROPBNsSb3f3CzxgoxWX2YkMmLh8QmqeBiIZ4fXs=", Updated = new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), Username = "EE" },
                        new { Id = 2, FirstName = "Freddie", Inserted = new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), LastName = "Flintoff", PasswordHash = "B9tplMn7jIAnRdZseqRCvzGko0ZHFj7+B1IDQ4u1k/8=", Updated = new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), Username = "FF" },
                        new { Id = 3, FirstName = "Graham", Inserted = new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), LastName = "Gooch", PasswordHash = "/21TLJ9cxwyebxIAz2R92sxLU3beXJ4Jyihjdxsxu0E=", Updated = new DateTime(2018, 9, 18, 15, 6, 46, 442, DateTimeKind.Utc), Username = "GG" }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
