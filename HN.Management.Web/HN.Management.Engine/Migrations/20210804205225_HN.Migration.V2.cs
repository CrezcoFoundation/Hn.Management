using Microsoft.EntityFrameworkCore.Migrations;

namespace HN.Management.Engine.Migrations
{
    public partial class HNMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Proyect_ProyectId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Proyect_ProyectId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidence_Proyect_ProyectId",
                table: "Evidence");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Proyect_ProyectId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectPermit_Proyect_ProyectId",
                table: "UserProjectPermit");

            migrationBuilder.RenameColumn(
                name: "ProyectId",
                table: "UserProjectPermit",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjectPermit_ProyectId",
                table: "UserProjectPermit",
                newName: "IX_UserProjectPermit_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProyectId",
                table: "Student",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ProyectId",
                table: "Student",
                newName: "IX_Student_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProyectId",
                table: "Evidence",
                newName: "ProjectId");

            migrationBuilder.RenameColumn(
                name: "EvidenceId",
                table: "Evidence",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Evidence_ProyectId",
                table: "Evidence",
                newName: "IX_Evidence_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProyectId",
                table: "Donation",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_ProyectId",
                table: "Donation",
                newName: "IX_Donation_ProjectId");

            migrationBuilder.RenameColumn(
                name: "ProyectId",
                table: "Activity",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_ProyectId",
                table: "Activity",
                newName: "IX_Activity_ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Proyect_ProjectId",
                table: "Activity",
                column: "ProjectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Proyect_ProjectId",
                table: "Donation",
                column: "ProjectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidence_Proyect_ProjectId",
                table: "Evidence",
                column: "ProjectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Proyect_ProjectId",
                table: "Student",
                column: "ProjectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectPermit_Proyect_ProjectId",
                table: "UserProjectPermit",
                column: "ProjectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activity_Proyect_ProjectId",
                table: "Activity");

            migrationBuilder.DropForeignKey(
                name: "FK_Donation_Proyect_ProjectId",
                table: "Donation");

            migrationBuilder.DropForeignKey(
                name: "FK_Evidence_Proyect_ProjectId",
                table: "Evidence");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Proyect_ProjectId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectPermit_Proyect_ProjectId",
                table: "UserProjectPermit");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "UserProjectPermit",
                newName: "ProyectId");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjectPermit_ProjectId",
                table: "UserProjectPermit",
                newName: "IX_UserProjectPermit_ProyectId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Student",
                newName: "ProyectId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_ProjectId",
                table: "Student",
                newName: "IX_Student_ProyectId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Evidence",
                newName: "ProyectId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Evidence",
                newName: "EvidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Evidence_ProjectId",
                table: "Evidence",
                newName: "IX_Evidence_ProyectId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Donation",
                newName: "ProyectId");

            migrationBuilder.RenameIndex(
                name: "IX_Donation_ProjectId",
                table: "Donation",
                newName: "IX_Donation_ProyectId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "Activity",
                newName: "ProyectId");

            migrationBuilder.RenameIndex(
                name: "IX_Activity_ProjectId",
                table: "Activity",
                newName: "IX_Activity_ProyectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Activity_Proyect_ProyectId",
                table: "Activity",
                column: "ProyectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Donation_Proyect_ProyectId",
                table: "Donation",
                column: "ProyectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Evidence_Proyect_ProyectId",
                table: "Evidence",
                column: "ProyectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Proyect_ProyectId",
                table: "Student",
                column: "ProyectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectPermit_Proyect_ProyectId",
                table: "UserProjectPermit",
                column: "ProyectId",
                principalTable: "Proyect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
