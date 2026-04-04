using AppServicios.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppServicios.Api.Controllers
{
    public abstract class CrudControllerBase<TEntity> : ControllerBase where TEntity : class
    {
        private static readonly System.Reflection.PropertyInfo IdProperty = typeof(TEntity).GetProperty("Id")
            ?? throw new InvalidOperationException($"La entidad {typeof(TEntity).Name} debe tener una propiedad Id.");

        private readonly AppServiciosDbContext _context;

        protected CrudControllerBase(AppServiciosDbContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> Entities => _context.Set<TEntity>();

        private static int GetEntityId(TEntity entity)
        {
            var value = IdProperty.GetValue(entity);
            return value is int id ? id : 0;
        }

        private static void SetEntityId(TEntity entity, int id)
        {
            IdProperty.SetValue(entity, id);
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            var items = await Entities.AsNoTracking().ToListAsync();
            return Ok(items);
        }

        [HttpGet("{id:int}")]
        public virtual async Task<ActionResult<TEntity>> GetById(int id)
        {
            var entity = await Entities
                .AsNoTracking()
                .FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);

            return entity is null ? NotFound() : Ok(entity);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TEntity>> Create([FromBody] TEntity entity)
        {
            Entities.Add(entity);
            await _context.SaveChangesAsync();

            var id = GetEntityId(entity);
            return CreatedAtAction(nameof(GetById), new { id }, entity);
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] TEntity entity)
        {
            var entityId = GetEntityId(entity);
            if (entityId != 0 && entityId != id)
            {
                return BadRequest("El id de la URL no coincide con el del cuerpo.");
            }

            var existing = await Entities.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            if (existing is null)
            {
                return NotFound();
            }

            SetEntityId(entity, id);
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var existing = await Entities.FirstOrDefaultAsync(e => EF.Property<int>(e, "Id") == id);
            if (existing is null)
            {
                return NotFound();
            }

            Entities.Remove(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}