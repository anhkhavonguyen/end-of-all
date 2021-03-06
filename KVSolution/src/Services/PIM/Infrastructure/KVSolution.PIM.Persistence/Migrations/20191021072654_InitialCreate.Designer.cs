﻿// <auto-generated />
using System;
using KVSolution.PIM.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KVSolution.PIM.Persistence.Migrations
{
    [DbContext(typeof(KVDbContext))]
    [Migration("20191021072654_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("KVSolution.PIM.Domain.Entities.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryId");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Link");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("KVSolution.PIM.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KVSolution.PIM.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<string>("POCode");

                    b.Property<string>("Phone");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("KVSolution.PIM.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DoB");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<Guid>("RoleId");

                    b.Property<Guid?>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KVSolution.PIM.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("KVSolution.PIM.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("KVSolution.PIM.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
