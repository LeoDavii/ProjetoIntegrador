﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Source.Context;
using Source.Dtos;

#nullable disable

namespace Source.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20241115194114_ChangerColumn_ImageData_string")]
    partial class ChangerColumn_ImageData_string
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Source.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<AddressDto>("Address")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<IEnumerable<ProductDto>>("Products")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<double>("TotalValue")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Source.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageData")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Source.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<IEnumerable<AddressDto>>("Adresses")
                        .HasColumnType("jsonb");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47888747-800c-4c56-857e-81b2a73d66dc"),
                            Email = "johnC@test.com.br",
                            Name = "John Customer",
                            Password = "test",
                            Role = 0
                        },
                        new
                        {
                            Id = new Guid("8db8dc50-16cc-47ed-9b83-5ca536f01a6e"),
                            Email = "johnM@test.com.br",
                            Name = "John Manager",
                            Password = "test",
                            Role = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
