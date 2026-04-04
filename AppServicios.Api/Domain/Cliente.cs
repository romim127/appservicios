using System;
using System.Collections.Generic;

namespace AppServicios.Api.Domain
{
    public class Cliente
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        // Ubicación
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Ubicacion { get; set; } = string.Empty;

        // Preferencias
        public string Preferencias { get; set; } = string.Empty;
        public bool RecibeNotificaciones { get; set; } = true;

        // Historial
        public decimal GastoPorMes { get; set; } = 0;
        public int TotalServiciosContratados { get; set; } = 0;
        public decimal CalificacionPromedioProfesionales { get; set; } = 5.0m;

        // Relaciones
        public ICollection<Direccion> Direcciones { get; set; } = new List<Direccion>();
        public ICollection<SolicitudTrabajo> SolicitudesTrabajo { get; set; } = new List<SolicitudTrabajo>();
    }
}
