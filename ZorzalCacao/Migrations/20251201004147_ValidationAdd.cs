using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZorzalCacao.Migrations
{
    /// <inheritdoc />
    public partial class ValidationAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pesajes",
                columns: table => new
                {
                    PesajeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pesajes", x => x.PesajeId);
                });

            migrationBuilder.CreateTable(
                name: "Recogidas",
                columns: table => new
                {
                    RecogidaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PuntoEncuentro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificacionesProducto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadSacos = table.Column<double>(type: "float", nullable: false),
                    Chofer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recogidas", x => x.RecogidaId);
                });

            migrationBuilder.CreateTable(
                name: "Remociones",
                columns: table => new
                {
                    RemocionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroRemocion = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remociones", x => x.RemocionId);
                });

            migrationBuilder.CreateTable(
                name: "Sacos",
                columns: table => new
                {
                    SacoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadPesada = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sacos", x => x.SacoId);
                });

            migrationBuilder.CreateTable(
                name: "Controles",
                columns: table => new
                {
                    ControlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradosBrix = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decision = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecogidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controles", x => x.ControlId);
                    table.ForeignKey(
                        name: "FK_Controles_Recogidas_RecogidaId",
                        column: x => x.RecogidaId,
                        principalTable: "Recogidas",
                        principalColumn: "RecogidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fermentaciones",
                columns: table => new
                {
                    FermentacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RecogidaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fermentaciones", x => x.FermentacionId);
                    table.ForeignKey(
                        name: "FK_Fermentaciones_Recogidas_RecogidaId",
                        column: x => x.RecogidaId,
                        principalTable: "Recogidas",
                        principalColumn: "RecogidaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PesajesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PesajeId = table.Column<int>(type: "int", nullable: false),
                    SacoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Peso = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PesajesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_PesajesDetalles_Pesajes_PesajeId",
                        column: x => x.PesajeId,
                        principalTable: "Pesajes",
                        principalColumn: "PesajeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PesajesDetalles_Sacos_SacoId",
                        column: x => x.SacoId,
                        principalTable: "Sacos",
                        principalColumn: "SacoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FermentacionesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FermentacionId = table.Column<int>(type: "int", nullable: false),
                    RemocionId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Temperatura = table.Column<double>(type: "float", nullable: false),
                    FechaFermentacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FermentacionesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_FermentacionesDetalles_Fermentaciones_FermentacionId",
                        column: x => x.FermentacionId,
                        principalTable: "Fermentaciones",
                        principalColumn: "FermentacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FermentacionesDetalles_Remociones_RemocionId",
                        column: x => x.RemocionId,
                        principalTable: "Remociones",
                        principalColumn: "RemocionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Controles_RecogidaId",
                table: "Controles",
                column: "RecogidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fermentaciones_RecogidaId",
                table: "Fermentaciones",
                column: "RecogidaId");

            migrationBuilder.CreateIndex(
                name: "IX_FermentacionesDetalles_FermentacionId",
                table: "FermentacionesDetalles",
                column: "FermentacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FermentacionesDetalles_RemocionId",
                table: "FermentacionesDetalles",
                column: "RemocionId");

            migrationBuilder.CreateIndex(
                name: "IX_PesajesDetalles_PesajeId",
                table: "PesajesDetalles",
                column: "PesajeId");

            migrationBuilder.CreateIndex(
                name: "IX_PesajesDetalles_SacoId",
                table: "PesajesDetalles",
                column: "SacoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Controles");

            migrationBuilder.DropTable(
                name: "FermentacionesDetalles");

            migrationBuilder.DropTable(
                name: "PesajesDetalles");

            migrationBuilder.DropTable(
                name: "Fermentaciones");

            migrationBuilder.DropTable(
                name: "Remociones");

            migrationBuilder.DropTable(
                name: "Pesajes");

            migrationBuilder.DropTable(
                name: "Sacos");

            migrationBuilder.DropTable(
                name: "Recogidas");
        }
    }
}
