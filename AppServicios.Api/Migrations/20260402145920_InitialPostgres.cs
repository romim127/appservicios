using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppServicios.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialPostgres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rubros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    Icono = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefono = table.Column<string>(type: "text", nullable: false),
                    DNI = table.Column<string>(type: "text", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Rol = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    VerificadoRenaper = table.Column<bool>(type: "boolean", nullable: false),
                    FechaVerificacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RubroId = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    PrecioSugerido = table.Column<decimal>(type: "numeric", nullable: false),
                    Unidad = table.Column<string>(type: "text", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Servicios_Rubros_RubroId",
                        column: x => x.RubroId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Longitud = table.Column<double>(type: "double precision", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Preferencias = table.Column<string>(type: "text", nullable: false),
                    RecibeNotificaciones = table.Column<bool>(type: "boolean", nullable: false),
                    GastoPorMes = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalServiciosContratados = table.Column<int>(type: "integer", nullable: false),
                    CalificacionPromedioProfesionales = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Profesionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Longitud = table.Column<double>(type: "double precision", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    AñosExperiencia = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    CalificacionPromedio = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalTrabajos = table.Column<int>(type: "integer", nullable: false),
                    TarifaBase = table.Column<decimal>(type: "numeric", nullable: false),
                    RadioAlcanceKm = table.Column<int>(type: "integer", nullable: false),
                    GananciaMensualObjetivo = table.Column<decimal>(type: "numeric", nullable: false),
                    GananciaMensualActual = table.Column<decimal>(type: "numeric", nullable: false),
                    AceptaTrabajoLejano = table.Column<bool>(type: "boolean", nullable: false),
                    BonoPorDistancia = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesionales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profesionales_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    Calle = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: false),
                    Piso = table.Column<string>(type: "text", nullable: false),
                    Departamento = table.Column<string>(type: "text", nullable: false),
                    Localidad = table.Column<string>(type: "text", nullable: false),
                    CodigoPostal = table.Column<string>(type: "text", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Longitud = table.Column<double>(type: "double precision", nullable: false),
                    EsPrincipal = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Direcciones_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProfesionalId = table.Column<int>(type: "integer", nullable: false),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    UrlDocumento = table.Column<string>(type: "text", nullable: false),
                    FechaOtorgamiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Verificado = table.Column<bool>(type: "boolean", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificados_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfesionalRubro",
                columns: table => new
                {
                    ProfesionalesId = table.Column<int>(type: "integer", nullable: false),
                    RubrosProfesionalesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfesionalRubro", x => new { x.ProfesionalesId, x.RubrosProfesionalesId });
                    table.ForeignKey(
                        name: "FK_ProfesionalRubro_Profesionales_ProfesionalesId",
                        column: x => x.ProfesionalesId,
                        principalTable: "Profesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfesionalRubro_Rubros_RubrosProfesionalesId",
                        column: x => x.RubrosProfesionalesId,
                        principalTable: "Rubros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: false),
                    ProfesionalId = table.Column<int>(type: "integer", nullable: true),
                    ServicioId = table.Column<int>(type: "integer", nullable: false),
                    Latitud = table.Column<double>(type: "double precision", nullable: false),
                    Longitud = table.Column<double>(type: "double precision", nullable: false),
                    Ubicacion = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    FechaRequerida = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PresupuestoEstimado = table.Column<decimal>(type: "numeric", nullable: false),
                    PresupuestoFinal = table.Column<decimal>(type: "numeric", nullable: true),
                    Estado = table.Column<string>(type: "text", nullable: false),
                    DistanciaKm = table.Column<decimal>(type: "numeric", nullable: true),
                    CostoTraslado = table.Column<decimal>(type: "numeric", nullable: true),
                    Incentivo = table.Column<decimal>(type: "numeric", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaAceptacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FechaCompletacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CalificacionProfesional = table.Column<int>(type: "integer", nullable: true),
                    ComentarioProfesional = table.Column<string>(type: "text", nullable: false),
                    CalificacionCliente = table.Column<int>(type: "integer", nullable: true),
                    ComentarioCliente = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesTrabajo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesTrabajo_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudesTrabajo_Profesionales_ProfesionalId",
                        column: x => x.ProfesionalId,
                        principalTable: "Profesionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_SolicitudesTrabajo_Servicios_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "Servicios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Activo", "Descripcion", "Icono", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Servicios eléctricos", "electricidad", "Electricidad" },
                    { 2, true, "Servicios de plomería", "plomeria", "Plomería" },
                    { 3, true, "Niñeras y cuidadores", "cuidados-ninos", "Cuidados de Niños" },
                    { 4, true, "Cuidados de salud", "enfermeria", "Enfermería" },
                    { 5, true, "Reparación de vehículos", "mecanica", "Mecánica" },
                    { 6, true, "Trabajo en metal", "metalurgia", "Metalurgia" },
                    { 7, true, "Servicios de soldadura", "soldadura", "Soldadura" },
                    { 8, true, "Reparaciones técnicas", "tecnica", "Técnica" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_ProfesionalId",
                table: "Certificados",
                column: "ProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioId",
                table: "Clientes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_ClienteId",
                table: "Direcciones",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Profesionales_UsuarioId",
                table: "Profesionales",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProfesionalRubro_RubrosProfesionalesId",
                table: "ProfesionalRubro",
                column: "RubrosProfesionalesId");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_RubroId",
                table: "Servicios",
                column: "RubroId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesTrabajo_ClienteId",
                table: "SolicitudesTrabajo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesTrabajo_ProfesionalId",
                table: "SolicitudesTrabajo",
                column: "ProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesTrabajo_ServicioId",
                table: "SolicitudesTrabajo",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_DNI",
                table: "Usuarios",
                column: "DNI",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "ProfesionalRubro");

            migrationBuilder.DropTable(
                name: "SolicitudesTrabajo");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Profesionales");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Rubros");
        }
    }
}
