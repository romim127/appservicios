using System;

namespace AppServicios.Api.Domain
{
    public class Certificado
    {
        public int Id { get; set; }
        public int ProfesionalId { get; set; }
        public Profesional Profesional { get; set; } = null!;

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string UrlDocumento { get; set; } = string.Empty;
        public DateTime FechaOtorgamiento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public bool Verificado { get; set; } = false;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
