﻿// <auto-generated />
using System;
using Cigirci.Budgeteer.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cigirci.Budgeteer.DbContext.Migrations
{
    [DbContext(typeof(BudgeteerContext))]
    [Migration("20221104182540_FixProfileTableName")]
    partial class FixProfileTableName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cigirci.Budgeteer.Models.Entities.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<Guid>("Account")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("account_id");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(19,4)")
                        .HasColumnName("balance");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<int?>("Sex")
                        .HasColumnType("int")
                        .HasColumnName("sex");

                    b.HasKey("Id");

                    b.ToTable("profile");
                });

            modelBuilder.Entity("Cigirci.Budgeteer.Models.Entities.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(19,4)")
                        .HasColumnName("amount");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("transaction");
                });

            modelBuilder.Entity("Cigirci.Budgeteer.Models.Entities.Profile", b =>
                {
                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Profile.Types.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("First")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("first_name");

                            b1.Property<string>("Last")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("last_name");

                            b1.HasKey("ProfileId");

                            b1.ToTable("profile");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Created", "Created", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("By")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("On")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("datetime2")
                                .HasColumnName("created_on");

                            b1.HasKey("ProfileId");

                            b1.ToTable("profile");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Modified", "Modified", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("By")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("modified_by");

                            b1.Property<DateTime>("On")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("datetime2")
                                .HasColumnName("modified_on");

                            b1.HasKey("ProfileId");

                            b1.ToTable("profile");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Owner", "Owner", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("owner_id");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("owner_type");

                            b1.HasKey("ProfileId");

                            b1.ToTable("profile");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Status", "Status", b1 =>
                        {
                            b1.Property<Guid>("ProfileId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Reason")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("status");

                            b1.Property<int>("State")
                                .HasColumnType("int")
                                .HasColumnName("state");

                            b1.HasKey("ProfileId");

                            b1.ToTable("profile");

                            b1.WithOwner()
                                .HasForeignKey("ProfileId");
                        });

                    b.Navigation("Created")
                        .IsRequired();

                    b.Navigation("Modified")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();

                    b.Navigation("Owner")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });

            modelBuilder.Entity("Cigirci.Budgeteer.Models.Entities.Transaction", b =>
                {
                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Created", "Created", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("By")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("On")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("datetime2")
                                .HasColumnName("created_on");

                            b1.HasKey("TransactionId");

                            b1.ToTable("transaction");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Modified", "Modified", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("By")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("modified_by");

                            b1.Property<DateTime>("On")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("datetime2")
                                .HasColumnName("modified_on");

                            b1.HasKey("TransactionId");

                            b1.ToTable("transaction");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Owner", "Owner", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("owner_id");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("owner_type");

                            b1.HasKey("TransactionId");

                            b1.ToTable("transaction");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.OwnsOne("Cigirci.Budgeteer.Interfaces.Metadata.Record.Types.Status", "Status", b1 =>
                        {
                            b1.Property<Guid>("TransactionId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Reason")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("status");

                            b1.Property<int>("State")
                                .HasColumnType("int")
                                .HasColumnName("state");

                            b1.HasKey("TransactionId");

                            b1.ToTable("transaction");

                            b1.WithOwner()
                                .HasForeignKey("TransactionId");
                        });

                    b.Navigation("Created")
                        .IsRequired();

                    b.Navigation("Modified")
                        .IsRequired();

                    b.Navigation("Owner")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
