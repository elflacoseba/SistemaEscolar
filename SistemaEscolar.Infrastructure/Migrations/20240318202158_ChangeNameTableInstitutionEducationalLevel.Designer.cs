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
    [Migration("20240318202158_ChangeNameTableInstitutionEducationalLevel")]
    partial class ChangeNameTableInstitutionEducationalLevel
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

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.EducationalLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EducationalLevels");
                });

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.Institution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Institutions");
                });

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.InstitutionEducationalLevel", b =>
                {
                    b.Property<int>("InstitutionId")
                        .HasColumnType("int");

                    b.Property<int>("EducationalLevelId")
                        .HasColumnType("int");

                    b.HasKey("InstitutionId", "EducationalLevelId");

                    b.HasIndex("EducationalLevelId");

                    b.ToTable("InstitutionEducationalLevel", (string)null);
                });

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AuditCreateDate")
                        .HasColumnType("datetime");

                    b.Property<int>("AuditCreateUser")
                        .HasColumnType("int");

                    b.Property<DateTime?>("AuditUpdateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("AuditUpdateUser")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.Institution", b =>
                {
                    b.HasOne("SistemaEscolar.Domain.Entities.User", "User")
                        .WithMany("Institutions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.InstitutionEducationalLevel", b =>
                {
                    b.HasOne("SistemaEscolar.Domain.Entities.EducationalLevel", "EducationalLevel")
                        .WithMany()
                        .HasForeignKey("EducationalLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaEscolar.Domain.Entities.Institution", "Institution")
                        .WithMany()
                        .HasForeignKey("InstitutionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EducationalLevel");

                    b.Navigation("Institution");
                });

            modelBuilder.Entity("SistemaEscolar.Domain.Entities.User", b =>
                {
                    b.Navigation("Institutions");
                });
#pragma warning restore 612, 618
        }
    }
}
