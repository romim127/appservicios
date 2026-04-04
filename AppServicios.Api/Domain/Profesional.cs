using System;
using System.Collections.Generic;

namespace AppServicios.Api.Domain
{
    public class Profesional
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Ubicación
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Ubicacion { get; set; } = string.Empty;

        // Experiencia
        public int AñosExperiencia { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal CalificacionPromedio { get; set; } = 5.0m;
        public int TotalTrabajos { get; set; } = 0;

        // Tarifa y alcance
        public decimal TarifaBase { get; set; } // por hora o por trabajo
        public int RadioAlcanceKm { get; set; } = 10; // km de radio

        // Meta y ganancia
        public decimal GananciaMensualObjetivo { get; set; }
        public decimal GananciaMensualActual { get; set; } = 0;
        public decimal PorcentajeCompletado => GananciaMensualObjetivo > 0
            ? (GananciaMensualActual / GananciaMensualObjetivo) * 100
            : 0;

        // Incentivos
        public bool AceptaTrabajoLejano { get; set; } = true;
        public decimal BonoPorDistancia { get; set; } = 0; // adicional por km extra

        // Relaciones
        public ICollection<Rubro> RubrosProfesionales { get; set; } = new List<Rubro>();
        public ICollection<Certificado> Certificados { get; set; } = new List<Certificado>();
        public ICollection<SolicitudTrabajo> SolicitudesTrabajo { get; set; } = new List<SolicitudTrabajo>();
    }
}
