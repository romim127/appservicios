using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppServicios.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSolicitudMessagesChat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MensajesSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SolicitudTrabajoId = table.Column<int>(type: "integer", nullable: false),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    RemitenteNombre = table.Column<string>(type: "text", nullable: false),
                    Contenido = table.Column<string>(type: "text", nullable: false),
                    FechaEnvio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MensajesSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MensajesSolicitud_SolicitudesTrabajo_SolicitudTrabajoId",
                        column: x => x.SolicitudTrabajoId,
                        principalTable: "SolicitudesTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MensajesSolicitud_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MensajesSolicitud_SolicitudTrabajoId_FechaEnvio",
                table: "MensajesSolicitud",
                columns: new[] { "SolicitudTrabajoId", "FechaEnvio" });

            migrationBuilder.CreateIndex(
                name: "IX_MensajesSolicitud_UsuarioId",
                table: "MensajesSolicitud",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MensajesSolicitud");
        }
    }
}
