using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace coreData.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "dutys",
                columns: table => new
                {
                    dutyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dutyDefinition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dutyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dutyPoint = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dutys", x => x.dutyID);
                });

            migrationBuilder.CreateTable(
                name: "titles",
                columns: table => new
                {
                    titleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_titles", x => x.titleID);
                });

            migrationBuilder.CreateTable(
                name: "units",
                columns: table => new
                {
                    unitsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unitsName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unitsNOE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_units", x => x.unitsID);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    projectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectDOS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    projectDOE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dutyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.projectID);
                    table.ForeignKey(
                        name: "FK_projects_dutys_dutyID",
                        column: x => x.dutyID,
                        principalTable: "dutys",
                        principalColumn: "dutyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    employeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    employeeDOS = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employeeShift = table.Column<bool>(type: "bit", nullable: false),
                    employeeWage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    employeeBounty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dutyID = table.Column<int>(type: "int", nullable: false),
                    titleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.employeeID);
                    table.ForeignKey(
                        name: "FK_employees_dutys_dutyID",
                        column: x => x.dutyID,
                        principalTable: "dutys",
                        principalColumn: "dutyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employees_titles_titleID",
                        column: x => x.titleID,
                        principalTable: "titles",
                        principalColumn: "titleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DutyUnits",
                columns: table => new
                {
                    dutyID = table.Column<int>(type: "int", nullable: false),
                    unitsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DutyUnits", x => new { x.dutyID, x.unitsID });
                    table.ForeignKey(
                        name: "FK_DutyUnits_dutys_dutyID",
                        column: x => x.dutyID,
                        principalTable: "dutys",
                        principalColumn: "dutyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DutyUnits_units_unitsID",
                        column: x => x.unitsID,
                        principalTable: "units",
                        principalColumn: "unitsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "kids",
                columns: table => new
                {
                    kidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    kidNameSurname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kidGender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    kidBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kids", x => x.kidID);
                    table.ForeignKey(
                        name: "FK_kids_employees_employeeID",
                        column: x => x.employeeID,
                        principalTable: "employees",
                        principalColumn: "employeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DutyUnits_unitsID",
                table: "DutyUnits",
                column: "unitsID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_dutyID",
                table: "employees",
                column: "dutyID");

            migrationBuilder.CreateIndex(
                name: "IX_employees_titleID",
                table: "employees",
                column: "titleID");

            migrationBuilder.CreateIndex(
                name: "IX_kids_employeeID",
                table: "kids",
                column: "employeeID");

            migrationBuilder.CreateIndex(
                name: "IX_projects_dutyID",
                table: "projects",
                column: "dutyID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DutyUnits");

            migrationBuilder.DropTable(
                name: "kids");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "units");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "dutys");

            migrationBuilder.DropTable(
                name: "titles");
        }
    }
}
