using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppServicios.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProfessionalSectorRubros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ComentarioProfesional",
                table: "SolicitudesTrabajo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "ComentarioCliente",
                table: "SolicitudesTrabajo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Rubros",
                columns: new[] { "Id", "Activo", "Descripcion", "Icono", "Nombre" },
                values: new object[,]
                {
                    { 9, true, "Software, soporte IT, redes y servicios digitales", "tecnologia-sistemas", "Tecnología y Sistemas" },
                    { 10, true, "Atención clínica, cuidados y asistencia sanitaria", "salud-enfermeria", "Salud y Enfermería" },
                    { 11, true, "Procesos productivos, planta y operación técnica", "produccion-manufactura", "Producción, Manufactura y Operarios" },
                    { 12, true, "Ventas, reparto, logística y atención comercial", "comercio-logistica", "Comercio Ventas y Logística" },
                    { 13, true, "Gestión administrativa, contable y financiera", "administracion-finanzas", "Administración Contabilidad y Finanzas" },
                    { 14, true, "Hotelería, turismo, cocina y atención gastronómica", "hosteleria-gastronomia", "Hostelería Turismo y Gastronomía" },
                    { 15, true, "Obra, mantenimiento general y servicios técnicos", "construccion-servicios", "Construcción y Servicios Generales" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Rubros",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.AlterColumn<string>(
                name: "ComentarioProfesional",
                table: "SolicitudesTrabajo",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ComentarioCliente",
                table: "SolicitudesTrabajo",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
