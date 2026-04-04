using AppServicios.Api.Data;
using AppServicios.Api.Domain;

namespace AppServicios.Api.Helpers
{
    internal static class AuditoriaHelper
    {
        public static async Task RegistrarAsync(
            AppServiciosDbContext context,
            int? usuarioId,
            string tipo,
            string accion,
            string descripcion,
            string entidad,
            int? entidadId = null,
            string? metadata = null)
        {
            context.AuditoriaEventos.Add(new AuditoriaEvento
            {
                UsuarioId = usuarioId,
                Tipo = tipo,
                Accion = accion,
                Descripcion = descripcion,
                Entidad = entidad,
                EntidadId = entidadId,
                Metadata = metadata ?? string.Empty,
                Fecha = DateTime.UtcNow
            });

            await context.SaveChangesAsync();
        }
    }
}