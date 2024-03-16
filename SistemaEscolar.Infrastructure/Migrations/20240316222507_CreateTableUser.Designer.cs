﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaEscolar.Infrastructure.Persistence.Contexts;

#nullable disable

namespace SistemaEscolar.Infrastructure.Migrations
{
    [DbContext(typeof(SistemaEscolarContext))]
    [Migration("20240316222507_CreateTableUser")]
    partial class CreateTableUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Modern_Spanish_CI_AS")
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditDeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AuditDeleteUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Image")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}