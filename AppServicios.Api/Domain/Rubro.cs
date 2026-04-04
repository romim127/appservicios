using System;
using System.Collections.Generic;

namespace AppServicios.Api.Domain
{
    public class Rubro
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty; // "Electricidad", "Plomería", etc.
        public string Descripcion { get; set; } = string.Empty;
        public string Icono { get; set; } = string.Empty; // URL o nombre de ícono
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<Profesional> Profesionales { get; set; } = new List<Profesional>();
        public ICollection<Servicio> Servicios { get; set; } = new List<Servicio>();
    }
}
