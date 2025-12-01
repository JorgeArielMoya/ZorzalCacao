using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class Fermentacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FermentacionesDetalles_Remociones_RemocionId",
                table: "FermentacionesDetalles");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoId",
                table: "FermentacionesDetalles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoId",
                table: "Fermentaciones",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmpleadoId",
                table: "Controles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FermentacionesDetalles_EmpleadoId",
                table: "FermentacionesDetalles",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermentaciones_EmpleadoId",
                table: "Fermentaciones",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Controles_EmpleadoId",
                table: "Controles",
                column: "EmpleadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Controles_AspNetUsers_EmpleadoId",
                table: "Controles",
                column: "EmpleadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fermentaciones_AspNetUsers_EmpleadoId",
                table: "Fermentaciones",
                column: "EmpleadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FermentacionesDetalles_AspNetUsers_EmpleadoId",
                table: "FermentacionesDetalles",
                column: "EmpleadoId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FermentacionesDetalles_Remociones_RemocionId",
                table: "FermentacionesDetalles",
                column: "RemocionId",
                principalTable: "Remociones",
                principalColumn: "RemocionId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controles_AspNetUsers_EmpleadoId",
                table: "Controles");

            migrationBuilder.DropForeignKey(
                name: "FK_Fermentaciones_AspNetUsers_EmpleadoId",
                table: "Fermentaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_FermentacionesDetalles_AspNetUsers_EmpleadoId",
                table: "FermentacionesDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_FermentacionesDetalles_Remociones_RemocionId",
                table: "FermentacionesDetalles");

            migrationBuilder.DropIndex(
                name: "IX_FermentacionesDetalles_EmpleadoId",
                table: "FermentacionesDetalles");

            migrationBuilder.DropIndex(
                name: "IX_Fermentaciones_EmpleadoId",
                table: "Fermentaciones");

            migrationBuilder.DropIndex(
                name: "IX_Controles_EmpleadoId",
                table: "Controles");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "FermentacionesDetalles");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Fermentaciones");

            migrationBuilder.DropColumn(
                name: "EmpleadoId",
                table: "Controles");

            migrationBuilder.AddForeignKey(
                name: "FK_FermentacionesDetalles_Remociones_RemocionId",
                table: "FermentacionesDetalles",
                column: "RemocionId",
                principalTable: "Remociones",
                principalColumn: "RemocionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
