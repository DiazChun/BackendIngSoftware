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
    public class ParticipacionsController : ControllerBase
    {
        private readonly SgamiContext _context;

        public ParticipacionsController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/Participacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Participacion>>> GetParticipacion()
        {
          if (_context.Participacion == null)
          {
              return NotFound();
          }
            return await _context.Participacion.ToListAsync();
        }

        // GET: api/Participacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Participacion>> GetParticipacion(int id)
        {
          if (_context.Participacion == null)
          {
              return NotFound();
          }
            var participacion = await _context.Participacion.FindAsync(id);

            if (participacion == null)
            {
                return NotFound();
            }

            return participacion;
        }

        // PUT: api/Participacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParticipacion(int id, Participacion participacion)
        {
            if (id != participacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(participacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipacionExists(id))
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

        // POST: api/Participacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Participacion>> PostParticipacion(Participacion participacion)
        {
          if (_context.Participacion == null)
          {
              return Problem("Entity set 'SgamiContext.Participacion'  is null.");
          }
            _context.Participacion.Add(participacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParticipacion", new { id = participacion.Id }, participacion);
        }

        // DELETE: api/Participacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParticipacion(int id)
        {
            if (_context.Participacion == null)
            {
                return NotFound();
            }
            var participacion = await _context.Participacion.FindAsync(id);
            if (participacion == null)
            {
                return NotFound();
            }

            _context.Participacion.Remove(participacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParticipacionExists(int id)
        {
            return (_context.Participacion?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
