using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_SGAMI.Models;

namespace API_SGAMI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadsController : ControllerBase
    {
        private readonly SgamiContext _context;

        public ActividadsController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/Actividads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Actividad>>> GetActividad()
        {
          if (_context.Actividad == null)
          {
              return NotFound();
          }
            return await _context.Actividad.ToListAsync();
        }

        // GET: api/Actividads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Actividad>> GetActividad(int id)
        {
          if (_context.Actividad == null)
          {
              return NotFound();
          }
            var actividad = await _context.Actividad.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return actividad;
        }

        // PUT: api/Actividads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutActividad(int id, Actividad actividad)
        {
            if (id != actividad.Id)
            {
                return BadRequest();
            }

            _context.Entry(actividad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActividadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Actividads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Actividad>> PostActividad(Actividad actividad)
        {
          if (_context.Actividad == null)
          {
              return Problem("Entity set 'SgamiContext.Actividad'  is null.");
          }
            _context.Actividad.Add(actividad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetActividad", new { id = actividad.Id }, actividad);
        }

        // DELETE: api/Actividads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActividad(int id)
        {
            if (_context.Actividad == null)
            {
                return NotFound();
            }
            var actividad = await _context.Actividad.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividad.Remove(actividad);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ActividadExists(int id)
        {
            return (_context.Actividad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
