using System;

namespace AppServicios.Api.Domain
{
    public class AuditoriaEvento
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public string Tipo { get; set; } = string.Empty;
        public string Accion { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Entidad { get; set; } = string.Empty;
        public int? EntidadId { get; set; }
        public string Metadata { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}