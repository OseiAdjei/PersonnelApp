using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedNsp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_College_Nsp_NspId",
                table: "College");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Nsp_NspId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_Department_DepartmentId",
                table: "Faculty");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_Nsp_NspId",
                table: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Faculty_DepartmentId",
                table: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Faculty_NspId",
                table: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Department_NspId",
                table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_College_NspId",
                table: "College");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Faculty");

            migrationBuilder.DropColumn(
                name: "NspId",
                table: "Faculty");

            migrationBuilder.DropColumn(
                name: "NspId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "NspId",
                table: "College");

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Nsp",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Nsp",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Nsp",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "Department",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Nsp_CollegeId",
                table: "Nsp",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Nsp_DepartmentId",
                table: "Nsp",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Nsp_FacultyId",
                table: "Nsp",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_FacultyId",
                table: "Department",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nsp_College_CollegeId",
                table: "Nsp",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nsp_Department_DepartmentId",
                table: "Nsp",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nsp_Faculty_FacultyId",
                table: "Nsp",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Faculty_FacultyId",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Nsp_College_CollegeId",
                table: "Nsp");

            migrationBuilder.DropForeignKey(
                name: "FK_Nsp_Department_DepartmentId",
                table: "Nsp");

            migrationBuilder.DropForeignKey(
                name: "FK_Nsp_Faculty_FacultyId",
                table: "Nsp");

            migrationBuilder.DropIndex(
                name: "IX_Nsp_CollegeId",
                table: "Nsp");

            migrationBuilder.DropIndex(
                name: "IX_Nsp_DepartmentId",
                table: "Nsp");

            migrationBuilder.DropIndex(
                name: "IX_Nsp_FacultyId",
                table: "Nsp");

            migrationBuilder.DropIndex(
                name: "IX_Department_FacultyId",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Nsp");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Nsp");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Nsp");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Department");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Faculty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NspId",
                table: "Faculty",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NspId",
                table: "Department",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NspId",
                table: "College",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_DepartmentId",
                table: "Faculty",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_NspId",
                table: "Faculty",
                column: "NspId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_NspId",
                table: "Department",
                column: "NspId");

            migrationBuilder.CreateIndex(
                name: "IX_College_NspId",
                table: "College",
                column: "NspId");

            migrationBuilder.AddForeignKey(
                name: "FK_College_Nsp_NspId",
                table: "College",
                column: "NspId",
                principalTable: "Nsp",
                principalColumn: "NspId");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Nsp_NspId",
                table: "Department",
                column: "NspId",
                principalTable: "Nsp",
                principalColumn: "NspId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_Department_DepartmentId",
                table: "Faculty",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_Nsp_NspId",
                table: "Faculty",
                column: "NspId",
                principalTable: "Nsp",
                principalColumn: "NspId");
        }
    }
}
