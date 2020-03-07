using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExportarExcel.Data.Migrations
{
    public partial class Productos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ventas");

            migrationBuilder.CreateTable(
                name: "Productos",
                schema: "ventas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Descontinuado = table.Column<bool>(nullable: true),
                    FechaDaLanzamiento = table.Column<DateTime>(maxLength: 100, nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "ventas",
                table: "Productos",
                columns: new[] { "Id", "Descontinuado", "FechaDaLanzamiento", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2020, 3, 6, 23, 17, 6, 376, DateTimeKind.Local).AddTicks(6742), "Dark Side of The Moon", 99.9m },
                    { 2, true, new DateTime(2010, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desire", 69.9m },
                    { 3, false, new DateTime(2020, 3, 6, 23, 17, 6, 381, DateTimeKind.Local).AddTicks(1426), "Próxima estación esperanza", 19.9m },
                    { 4, false, new DateTime(2018, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "OK Computer", 79.9m },
                    { 5, false, new DateTime(2011, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amnesiac", 89.9m },
                    { 6, true, new DateTime(2015, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Merlina", 99.9m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos",
                schema: "ventas");
        }
    }
}
