﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDo.DAL.ClickHouse.Logs.Persistence;

#nullable disable

namespace ToDo.DAL.ClickHouse.Logs.Migrations
{
    [DbContext(typeof(LogsDbContext))]
    [Migration("20250623101425_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.17");

            modelBuilder.Entity("ToDo.Domain.Entities.LogEntry", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("UUID")
                        .HasColumnName("ID");

                    b.Property<string>("Exception")
                        .HasColumnType("String");

                    b.Property<int>("LogLevel")
                        .HasColumnType("Int32");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("String");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("DateTime")
                        .HasColumnName("Timestamp");

                    b.HasKey("ID");

                    b.ToTable("Logs", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
