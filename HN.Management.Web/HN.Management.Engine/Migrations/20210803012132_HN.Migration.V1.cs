﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HN.Management.Engine.Migrations
{
    public partial class HNMigrationV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: true),
                    FirstName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proyect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    CountryFlag = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true),
                    MoneyAmount = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Date = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    ProyectId = table.Column<int>(type: "int", nullable: true),
                    DonorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donation_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Donation_Proyect_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "Proyect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Image = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true),
                    ProyectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_Proyect_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "Proyect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDonorPermit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permit = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDonorPermit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserDonorPermit_Donor_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserDonorPermit_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProjectPermit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Permit = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    ProyectId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectPermit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProjectPermit_Proyect_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "Proyect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProjectPermit_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true),
                    LocalMoneyAmount = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    ConversionToDollar = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    DollarMoneyAmount = table.Column<int>(type: "int", maxLength: 11, nullable: false),
                    Date = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: true),
                    ProyectId = table.Column<int>(type: "int", nullable: true),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Proyect_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "Proyect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Activity_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evidence",
                columns: table => new
                {
                    EvidenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "Varchar(500)", maxLength: 500, nullable: true),
                    ProyectId = table.Column<int>(type: "int", nullable: true),
                    ActivitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidence", x => x.EvidenceId);
                    table.ForeignKey(
                        name: "FK_Evidence_Activity_ActivitiesId",
                        column: x => x.ActivitiesId,
                        principalTable: "Activity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evidence_Proyect_ProyectId",
                        column: x => x.ProyectId,
                        principalTable: "Proyect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ProyectId",
                table: "Activity",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_StudentId",
                table: "Activity",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_DonorId",
                table: "Donation",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donation_ProyectId",
                table: "Donation",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidence_ActivitiesId",
                table: "Evidence",
                column: "ActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Evidence_ProyectId",
                table: "Evidence",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ProyectId",
                table: "Student",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonorPermit_DonorId",
                table: "UserDonorPermit",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDonorPermit_UserId",
                table: "UserDonorPermit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectPermit_ProyectId",
                table: "UserProjectPermit",
                column: "ProyectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectPermit_UserId",
                table: "UserProjectPermit",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donation");

            migrationBuilder.DropTable(
                name: "Evidence");

            migrationBuilder.DropTable(
                name: "UserDonorPermit");

            migrationBuilder.DropTable(
                name: "UserProjectPermit");

            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "Donor");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Proyect");
        }
    }
}
