﻿// <auto-generated />
using System;
using Cleanito.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Cleanito.Migrations
{
    [DbContext(typeof(CleanitoContext))]
    [Migration("20220323081650_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdService", b =>
                {
                    b.Property<int>("AdsAdId")
                        .HasColumnType("integer");

                    b.Property<int>("ServicesServiceId")
                        .HasColumnType("integer");

                    b.HasKey("AdsAdId", "ServicesServiceId");

                    b.HasIndex("ServicesServiceId");

                    b.ToTable("AdService");
                });

            modelBuilder.Entity("Cleanito.Models.Ad", b =>
                {
                    b.Property<int>("AdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AdId"));

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AdId");

                    b.HasIndex("UserId");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("Cleanito.Models.Service", b =>
                {
                    b.Property<int>("ServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServiceId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("ServiceId");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("Cleanito.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("ImageName")
                        .HasColumnType("text");

                    b.Property<bool>("IsIndividual")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AdService", b =>
                {
                    b.HasOne("Cleanito.Models.Ad", null)
                        .WithMany()
                        .HasForeignKey("AdsAdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cleanito.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Cleanito.Models.Ad", b =>
                {
                    b.HasOne("Cleanito.Models.User", "User")
                        .WithMany("Ads")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cleanito.Models.User", b =>
                {
                    b.Navigation("Ads");
                });
#pragma warning restore 612, 618
        }
    }
}
