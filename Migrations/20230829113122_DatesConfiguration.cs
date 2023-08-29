using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TollFee.Api.Migrations
{
	public partial class DatesConfiguration : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Fee",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Year = table.Column<int>(type: "int", nullable: false),
					FromMinute = table.Column<long>(type: "bigint", nullable: false),
					ToMinute = table.Column<long>(type: "bigint", nullable: false),
					Price = table.Column<decimal>(type: "decimal(2,0)", nullable: false),
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Fee", x => new { x.Id });
				});

			migrationBuilder.CreateTable(
				name: "TollFree",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Year = table.Column<int>(type: "int", nullable: false),
					Date = table.Column<DateTime>(type: "date", nullable: false),
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_TollFree", x => new { x.Id });
				});

			Console.Write("Insert seed data for Fee\n");
			migrationBuilder.InsertData(
				table: "Fee",
				columns: new[] { "Year", "FromMinute", "ToMinute", "Price" },
				values: new object[,]
				{
					{ 2021, 6 * 60, 6 * 60 + 29, 9 },
					{ 2021, 6 * 60 + 30, 6 * 60 + 59, 16 },
					{ 2021, 7 * 60, 7 * 60 + 59, 22 },
					{ 2021, 8 * 60, 8 * 60 + 29, 16 },
					{ 2021, 8 * 60 + 30, 14 * 60 + 59, 9 },
					{ 2021, 15 * 60, 15 * 60 + 29, 16 },
					{ 2021, 15 * 60 + 30, 16 * 60 + 59, 22 },
					{ 2021, 17 * 60, 17 * 60 + 59, 16 },
					{ 2021, 18 * 60, 18 * 60 + 29, 9 },
					{ 2021, 18 * 60 + 30, 24 * 60 - 1, 0 }
				});

			Console.Write("Insert seed data for TollFree\n");
			migrationBuilder.InsertData(
				table: "TollFree",
				columns: new[] { "Year", "Date" },
				values: new object[,]
				{
					{ 2021, new DateTime(2021, 1, 1) },
					{ 2021, new DateTime(2021, 1, 5) },
					{ 2021, new DateTime(2021, 1, 6) },
					{ 2021, new DateTime(2021, 4, 1) },
					{ 2021, new DateTime(2021, 4, 2) },
					{ 2021, new DateTime(2021, 4, 5) },
					{ 2021, new DateTime(2021, 4, 30) },
					{ 2021, new DateTime(2021, 5, 12) },
					{ 2021, new DateTime(2021, 5, 13) },
					{ 2021, new DateTime(2021, 6, 25) },
					{ 2021, new DateTime(2021, 11, 5) },
					{ 2021, new DateTime(2021, 12, 24) },
					{ 2021, new DateTime(2021, 12, 31) }
				});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Fee");

			migrationBuilder.DropTable(
				name: "TollFree");
		}
	}
}
