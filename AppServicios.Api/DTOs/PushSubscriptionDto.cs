using System.ComponentModel.DataAnnotations;

namespace AppServicios.Api.DTOs
{
    public class PushSubscriptionDto
    {
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string Endpoint { get; set; } = string.Empty;
        [Required]
        public string P256dh { get; set; } = string.Empty;
        [Required]
        public string Auth { get; set; } = string.Empty;
    }
}
