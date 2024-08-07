﻿// <auto-generated />
using System;
using DayaAcces.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DayaAcces.Migrations
{
    [DbContext(typeof(ModelContext))]
    [Migration("20240804193737_ssk")]
    partial class ssk
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DayaAcces.Model.Notes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notess");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dc3a0147-b895-48dd-82f4-420c4611a4c9"),
                            Date = new DateTime(2024, 7, 20, 18, 30, 25, 0, DateTimeKind.Unspecified),
                            Info = "Pashka Info1",
                            UserId = new Guid("54f2f515-54a1-454a-9585-54a1454a9585")
                        });
                });

            modelBuilder.Entity("DayaAcces.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("54f2f515-54a1-454a-9585-54a1454a9585"),
                            Login = "login",
                            Name = "Dimon",
                            Password = "password"
                        });
                });

            modelBuilder.Entity("DayaAcces.Model.Notes", b =>
                {
                    b.HasOne("DayaAcces.Model.User", "User")
                        .WithMany("Note")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DayaAcces.Model.User", b =>
                {
                    b.Navigation("Note");
                });
#pragma warning restore 612, 618
        }
    }
}