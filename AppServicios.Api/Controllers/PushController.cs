using AppServicios.Api.Data;
using AppServicios.Api.Domain;
using AppServicios.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppServicios.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PushController : ControllerBase
    {
        private readonly AppServiciosDbContext _context;
        public PushController(AppServiciosDbContext context)
        {
            _context = context;
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe([FromBody] PushSubscriptionDto dto)
        {
            var claimUserId = User?.Identity?.IsAuthenticated == true ? int.Parse(User.FindFirst("sub")?.Value ?? "0") : 0;
            if (claimUserId != dto.UsuarioId)
                return Forbid();

            var existing = await _context.PushSubscriptions.FirstOrDefaultAsync(p => p.UsuarioId == dto.UsuarioId && p.Endpoint == dto.Endpoint);
            if (existing == null)
            {
                var sub = new PushSubscription
                {
                    UsuarioId = dto.UsuarioId,
                    Endpoint = dto.Endpoint,
                    P256dh = dto.P256dh,
                    Auth = dto.Auth
                };
                _context.PushSubscriptions.Add(sub);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
