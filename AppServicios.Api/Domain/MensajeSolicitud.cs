using System;

namespace AppServicios.Api.Domain
{
    public class MensajeSolicitud
    {
        public int Id { get; set; }

        public int SolicitudTrabajoId { get; set; }
        public SolicitudTrabajo SolicitudTrabajo { get; set; } = null!;

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public string RemitenteNombre { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; } = DateTime.UtcNow;
    }
}