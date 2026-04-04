using System;
using System.Collections.Generic;

namespace AppServicios.Api.Domain
{
    public class SolicitudTrabajo
    {
        public int Id { get; set; }

        // Cliente que solicita
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        // Profesional seleccionado
        public int? ProfesionalId { get; set; }
        public Profesional? Profesional { get; set; }

        // Servicio
        public int ServicioId { get; set; }
        public Servicio Servicio { get; set; } = null!;

        // Ubicación del trabajo
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Ubicacion { get; set; } = string.Empty;

        // Descripción del trabajo
        public string Descripcion { get; set; } = string.Empty;
        public DateTime FechaRequerida { get; set; }

        // Presupuesto y estado
        public decimal PresupuestoEstimado { get; set; }
        public decimal? PresupuestoFinal { get; set; }
        public string Estado { get; set; } = "Pendiente"; // Pendiente, Aceptado, Rechazado, Completado, Cancelado

        // Distancia y cálculos
        public decimal? DistanciaKm { get; set; }
        public decimal? CostoTraslado { get; set; }
        public decimal? Incentivo { get; set; }

        // Timestamps
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public DateTime? FechaAceptacion { get; set; }
        public DateTime? FechaCompletacion { get; set; }

        // Calificación
        public int? CalificacionProfesional { get; set; }
        public string? ComentarioProfesional { get; set; }
        public int? CalificacionCliente { get; set; }
        public string? ComentarioCliente { get; set; }

        public ICollection<MensajeSolicitud> Mensajes { get; set; } = new List<MensajeSolicitud>();
    }
}
