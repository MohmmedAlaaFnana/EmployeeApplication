using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeApplication.Data.Migrations
{
    public partial class adduploaddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "infoEmployees",
                columns: table => new
                {
                    EmployeeCodeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    PhoneNumpur = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infoEmployees", x => x.EmployeeCodeId);
                });

            migrationBuilder.CreateTable(
                name: "infoEmployeeSubs",
                columns: table => new
                {
                    aseriesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCode = table.Column<string>(nullable: true),
                    holidaydate = table.Column<DateTime>(nullable: false),
                    Thenumberofdays = table.Column<int>(nullable: false),
                    Isitvacation = table.Column<string>(nullable: true),
                    Statement = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infoEmployeeSubs", x => x.aseriesId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "infoEmployees");

            migrationBuilder.DropTable(
                name: "infoEmployeeSubs");
        }
    }
}
