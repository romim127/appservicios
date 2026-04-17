using System;

namespace AppServicios.Api.Domain
{
    public class SesionUsuario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }
        public bool Exito { get; set; }
        public string? MotivoCierre { get; set; }

        public required Usuario Usuario { get; set; }
    }
}