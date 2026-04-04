using System;
using System.Collections.Generic;

namespace AppServicios.Api.Domain
{
    public class Servicio
    {
        public int Id { get; set; }
        public int RubroId { get; set; }
        public Rubro Rubro { get; set; } = null!;

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal PrecioSugerido { get; set; }
        public string Unidad { get; set; } = string.Empty; // "por hora", "por trabajo", etc.
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<SolicitudTrabajo> SolicitudesTrabajo { get; set; } = new List<SolicitudTrabajo>();
    }
}
