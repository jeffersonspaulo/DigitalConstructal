﻿// <auto-generated />
using System;
using DigitalConstructal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DigitalConstructal.Migrations
{
    [DbContext(typeof(DigitalContext))]
    partial class DigitalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DigitalConstructal.Entities.AccessLog", b =>
                {
                    b.Property<int>("AccessLogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccessLogId"));

                    b.Property<DateTime>("AccessTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("AccessType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("AccessLogId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("AccessLogs");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Content", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("Contents");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.ContentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Blog Post"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ebook"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Newsletter"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Page"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Social Post"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Task"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Webinar"
                        });
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("int");

                    b.Property<int>("SellerId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderStatusId");

                    b.HasIndex("SellerId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrdersStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pending"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Processing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Shipped"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Delivered"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cancelled"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Returned"
                        });
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssociatedDomain")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DomainAuthority")
                        .HasColumnType("int");

                    b.Property<int?>("IncomingBacklink")
                        .HasColumnType("int");

                    b.Property<int?>("IndexedPage")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("LinkType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MonthlyEstimatedTraffic")
                        .HasColumnType("int");

                    b.Property<int?>("PageAuthority")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brainstorm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Briefing")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ContentTypeId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.SEOIndex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SEOIndexes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "CF",
                            Name = "CF"
                        },
                        new
                        {
                            Id = 2,
                            Description = "CA",
                            Name = "CA"
                        },
                        new
                        {
                            Id = 3,
                            Description = "DR",
                            Name = "DR"
                        },
                        new
                        {
                            Id = 4,
                            Description = "PA",
                            Name = "PA"
                        },
                        new
                        {
                            Id = 5,
                            Description = "SC",
                            Name = "SC"
                        },
                        new
                        {
                            Id = 6,
                            Description = "TF",
                            Name = "TF"
                        },
                        new
                        {
                            Id = 7,
                            Description = "UR",
                            Name = "UR"
                        });
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserLoginId");

                    b.ToTable("Sellers");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.AccessLog", b =>
                {
                    b.HasOne("DigitalConstructal.Entities.UserLogin", "UserLogin")
                        .WithMany("AccessLogs")
                        .HasForeignKey("UserLoginId");

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Content", b =>
                {
                    b.HasOne("DigitalConstructal.Entities.Project", "Project")
                        .WithMany("Contents")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Order", b =>
                {
                    b.HasOne("DigitalConstructal.Entities.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DigitalConstructal.Entities.Seller", "Seller")
                        .WithMany("Orders")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DigitalConstructal.Entities.UserLogin", "Customer")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("OrderStatus");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Project", b =>
                {
                    b.HasOne("DigitalConstructal.Entities.ContentType", "ContentType")
                        .WithMany("Projects")
                        .HasForeignKey("ContentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContentType");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Seller", b =>
                {
                    b.HasOne("DigitalConstructal.Entities.UserLogin", "UserLogin")
                        .WithMany()
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserLogin");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.ContentType", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Project", b =>
                {
                    b.Navigation("Contents");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.Seller", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("DigitalConstructal.Entities.UserLogin", b =>
                {
                    b.Navigation("AccessLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
