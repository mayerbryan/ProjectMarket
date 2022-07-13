﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectMarket.Api.Data;

#nullable disable

namespace ProjectMarket.Api.Migrations
{
    [DbContext(typeof(ProjectMarketDbContext))]
    [Migration("20220713165610_UserDbModelSetupUpdate")]
    partial class UserDbModelSetupUpdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectMarket.Application.Models.UserModel", b =>
                {
                    b.Property<int>("SystemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SystemId"), 1L, 1);

                    b.Property<string>("UserAddress")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("UserAddress");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("UserEmail");

                    b.Property<int>("UserId")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserPassword");

                    b.Property<int>("UserPhone")
                        .HasMaxLength(15)
                        .HasColumnType("int")
                        .HasColumnName("UserPhone");

                    b.HasKey("SystemId");

                    b.ToTable("UserClient", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
