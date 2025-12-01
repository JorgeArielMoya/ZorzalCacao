using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class RemocionAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Remociones",
                columns: new[] { "RemocionId", "Cantidad", "NumeroRemocion" },
                values: new object[,]
                {
                    { 1, 0.0, 1 },
                    { 2, 0.0, 2 },
                    { 3, 0.0, 3 },
                    { 4, 0.0, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Remociones",
                keyColumn: "RemocionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Remociones",
                keyColumn: "RemocionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Remociones",
                keyColumn: "RemocionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Remociones",
                keyColumn: "RemocionId",
                keyValue: 4);
        }
    }
}
