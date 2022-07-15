using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CIS2055___Nemesys.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    RRN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAndTimeOfReport = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Reporter_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    upvotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.RRN);
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "RRN", "DateAndTimeOfReport", "Desc", "Location", "Reporter_Email", "Title", "upvotes" },
                values: new object[] { 1, new DateTime(2022, 5, 9, 14, 29, 53, 214, DateTimeKind.Local).AddTicks(8518), "desctiption: hazardous", "Malta", "email@mail.com", "Disaster1", 0 });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "RRN", "DateAndTimeOfReport", "Desc", "Location", "Reporter_Email", "Title", "upvotes" },
                values: new object[] { 2, new DateTime(2022, 5, 9, 14, 29, 53, 219, DateTimeKind.Local).AddTicks(7426), "desctiption: hazardous", "Malta", "email@mail.com", "Disaster2", 0 });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "RRN", "DateAndTimeOfReport", "Desc", "Location", "Reporter_Email", "Title", "upvotes" },
                values: new object[] { 3, new DateTime(2022, 5, 9, 14, 29, 53, 219, DateTimeKind.Local).AddTicks(7483), "desctiption: hazardous", "Malta", "email@mail.com", "Disaster3", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
