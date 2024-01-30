using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class Trying : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_College_Faculty_FacultyId",
                table: "College");

            migrationBuilder.DropIndex(
                name: "IX_College_FacultyId",
                table: "College");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "College");

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "Faculty",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_CollegeId",
                table: "Faculty",
                column: "CollegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculty_College_CollegeId",
                table: "Faculty",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "CollegeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculty_College_CollegeId",
                table: "Faculty");

            migrationBuilder.DropIndex(
                name: "IX_Faculty_CollegeId",
                table: "Faculty");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "Faculty");

            migrationBuilder.AddColumn<int>(
                name: "FacultyId",
                table: "College",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_College_FacultyId",
                table: "College",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_College_Faculty_FacultyId",
                table: "College",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "FacultyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
