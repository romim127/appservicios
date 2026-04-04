using System;

namespace AppServicios.Api.Domain
{
    public class PagoProfesional
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public decimal Monto { get; set; } = 2500m;
        public string Moneda { get; set; } = "ARS";
        public string Concepto { get; set; } = "Alta profesional";
        public string Estado { get; set; } = "Pendiente";
        public string Proveedor { get; set; } = "Checkout Demo AppServicios";
        public string ReferenciaExterna { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaAprobacion { get; set; }
    }
}
