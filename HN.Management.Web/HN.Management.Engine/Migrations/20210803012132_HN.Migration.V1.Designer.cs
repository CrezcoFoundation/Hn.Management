﻿// <auto-generated />
using System;
using HN.Management.Engine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HN.Management.Engine.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210803012132_HN.Migration.V1")]
    partial class HNMigrationV1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HN.ManagementEngine.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConversionToDollar")
                        .HasMaxLength(11)
                        .HasColumnType("int")
                        .HasColumnName("ConversionToDollar");

                    b.Property<string>("Date")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Date");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Description");

                    b.Property<int>("DollarMoneyAmount")
                        .HasMaxLength(11)
                        .HasColumnType("int")
                        .HasColumnName("DollarMoneyAmount");

                    b.Property<int>("LocalMoneyAmount")
                        .HasMaxLength(11)
                        .HasColumnType("int")
                        .HasColumnName("LocalMoneyAmount");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Name");

                    b.Property<int?>("ProyectId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectId");

                    b.HasIndex("StudentId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Donation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Date")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Date");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Description");

                    b.Property<int?>("DonorId")
                        .HasColumnType("int");

                    b.Property<int>("MoneyAmount")
                        .HasMaxLength(11)
                        .HasColumnType("int")
                        .HasColumnName("MoneyAmount");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("Varchar(20)")
                        .HasColumnName("Name");

                    b.Property<int?>("ProyectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.HasIndex("ProyectId");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Donor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(30)
                        .HasColumnType("Varchar(30)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Image");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("LastName");

                    b.HasKey("Id");

                    b.ToTable("Donor");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Evidence", b =>
                {
                    b.Property<int>("EvidenceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ActivitiesId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Image");

                    b.Property<int?>("ProyectId")
                        .HasColumnType("int");

                    b.HasKey("EvidenceId");

                    b.HasIndex("ActivitiesId");

                    b.HasIndex("ProyectId");

                    b.ToTable("Evidence");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Proyect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Country");

                    b.Property<string>("CountryFlag")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("CountryFlag");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Description");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Image");

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("Varchar(20)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Proyect");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Image");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("LastName");

                    b.Property<int?>("ProyectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .HasColumnType("Varchar(500)")
                        .HasColumnName("Image");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.UserDonorPermit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DonorId")
                        .HasColumnType("int");

                    b.Property<string>("Permit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Permit");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DonorId");

                    b.HasIndex("UserId");

                    b.ToTable("UserDonorPermit");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.UserProjectPermit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Permit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("Varchar(50)")
                        .HasColumnName("Permit");

                    b.Property<int?>("ProyectId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProyectId");

                    b.HasIndex("UserId");

                    b.ToTable("UserProjectPermit");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Activity", b =>
                {
                    b.HasOne("HN.ManagementEngine.Models.Proyect", "Proyects")
                        .WithMany()
                        .HasForeignKey("ProyectId");

                    b.HasOne("HN.ManagementEngine.Models.Student", "Students")
                        .WithMany()
                        .HasForeignKey("StudentId");

                    b.Navigation("Proyects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Donation", b =>
                {
                    b.HasOne("HN.ManagementEngine.Models.Donor", "Donors")
                        .WithMany()
                        .HasForeignKey("DonorId");

                    b.HasOne("HN.ManagementEngine.Models.Proyect", "Proyects")
                        .WithMany()
                        .HasForeignKey("ProyectId");

                    b.Navigation("Donors");

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Evidence", b =>
                {
                    b.HasOne("HN.ManagementEngine.Models.Activity", "Activities")
                        .WithMany()
                        .HasForeignKey("ActivitiesId");

                    b.HasOne("HN.ManagementEngine.Models.Proyect", "Proyects")
                        .WithMany()
                        .HasForeignKey("ProyectId");

                    b.Navigation("Activities");

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.Student", b =>
                {
                    b.HasOne("HN.ManagementEngine.Models.Proyect", "Proyects")
                        .WithMany()
                        .HasForeignKey("ProyectId");

                    b.Navigation("Proyects");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.UserDonorPermit", b =>
                {
                    b.HasOne("HN.ManagementEngine.Models.Donor", "Donors")
                        .WithMany()
                        .HasForeignKey("DonorId");

                    b.HasOne("HN.ManagementEngine.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Donors");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("HN.ManagementEngine.Models.UserProjectPermit", b =>
                {
                    b.HasOne("HN.ManagementEngine.Models.Proyect", "Proyects")
                        .WithMany()
                        .HasForeignKey("ProyectId");

                    b.HasOne("HN.ManagementEngine.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Proyects");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
