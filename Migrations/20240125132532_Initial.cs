using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nsp",
                columns: table => new
                {
                    NspId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NspNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NspLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NspName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NspEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nsp", x => x.NspId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentHod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NspId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_Department_Nsp_NspId",
                        column: x => x.NspId,
                        principalTable: "Nsp",
                        principalColumn: "NspId");
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacultyDean = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    NspId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyId);
                    table.ForeignKey(
                        name: "FK_Faculty_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculty_Nsp_NspId",
                        column: x => x.NspId,
                        principalTable: "Nsp",
                        principalColumn: "NspId");
                });

            migrationBuilder.CreateTable(
                name: "College",
                columns: table => new
                {
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeLogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CollegeProvost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollegeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<int>(type: "int", nullable: false),
                    NspId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_College", x => x.CollegeId);
                    table.ForeignKey(
                        name: "FK_College_Faculty_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculty",
                        principalColumn: "FacultyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_College_Nsp_NspId",
                        column: x => x.NspId,
                        principalTable: "Nsp",
                        principalColumn: "NspId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_College_FacultyId",
                table: "College",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_College_NspId",
                table: "College",
                column: "NspId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_NspId",
                table: "Department",
                column: "NspId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_DepartmentId",
                table: "Faculty",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_NspId",
                table: "Faculty",
                column: "NspId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "College");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Nsp");
        }
    }
}
