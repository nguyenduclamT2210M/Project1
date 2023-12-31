﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project1.Entities;

#nullable disable

namespace Project1.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20231124173052_h2")]
    partial class h2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Project1.Entities.Bills", b =>
                {
                    b.Property<int>("IdBill")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBill"));

                    b.Property<string>("GoodsCondition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdGoods")
                        .HasColumnType("int");

                    b.Property<int>("IdGoodsProperties")
                        .HasColumnType("int");

                    b.Property<int>("IdReceiver")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int>("Payment")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdBill");

                    b.HasIndex("IdGoods")
                        .IsUnique();

                    b.HasIndex("IdGoodsProperties");

                    b.HasIndex("IdReceiver");

                    b.HasIndex("IdUser");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Project1.Entities.Goods", b =>
                {
                    b.Property<int>("IdGoods")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGoods"));

                    b.Property<int>("IdBill")
                        .HasColumnType("int");

                    b.Property<int>("IdServiceType")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("IdGoods");

                    b.HasIndex("IdServiceType");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Project1.Entities.GoodsProperties", b =>
                {
                    b.Property<int>("IdGoodsProperties")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGoodsProperties"));

                    b.Property<string>("Nature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGoodsProperties");

                    b.ToTable("GoodsProperties");
                });

            modelBuilder.Entity("Project1.Entities.Receivers", b =>
                {
                    b.Property<int>("IdReceiver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdReceiver"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tel")
                        .HasColumnType("int");

                    b.HasKey("IdReceiver");

                    b.ToTable("Receivers");
                });

            modelBuilder.Entity("Project1.Entities.SericeTypes", b =>
                {
                    b.Property<int>("IdServiceType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdServiceType"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdServiceType");

                    b.ToTable("SericeTypes");
                });

            modelBuilder.Entity("Project1.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
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

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Project1.Entities.Bills", b =>
                {
                    b.HasOne("Project1.Entities.Goods", "Good")
                        .WithOne("Bill")
                        .HasForeignKey("Project1.Entities.Bills", "IdGoods")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project1.Entities.GoodsProperties", "Properties")
                        .WithMany()
                        .HasForeignKey("IdGoodsProperties")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project1.Entities.Receivers", "Receiver")
                        .WithMany()
                        .HasForeignKey("IdReceiver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project1.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Good");

                    b.Navigation("Properties");

                    b.Navigation("Receiver");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Project1.Entities.Goods", b =>
                {
                    b.HasOne("Project1.Entities.SericeTypes", "ServiceType")
                        .WithMany()
                        .HasForeignKey("IdServiceType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("Project1.Entities.Goods", b =>
                {
                    b.Navigation("Bill")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
