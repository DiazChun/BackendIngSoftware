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
    public class FinanciamientoProyectoesController : ControllerBase
    {
        private readonly SgamiContext _context;

        public FinanciamientoProyectoesController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/FinanciamientoProyectoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanciamientoProyecto>>> GetFinanciamientoProyecto()
        {
          if (_context.FinanciamientoProyecto == null)
          {
              return NotFound();
          }
            return await _context.FinanciamientoProyecto.ToListAsync();
        }

        // GET: api/FinanciamientoProyectoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinanciamientoProyecto>> GetFinanciamientoProyecto(int id)
        {
          if (_context.FinanciamientoProyecto == null)
          {
              return NotFound();
          }
            var financiamientoProyecto = await _context.FinanciamientoProyecto.FindAsync(id);

            if (financiamientoProyecto == null)
            {
                return NotFound();
            }

            return financiamientoProyecto;
        }

        // PUT: api/FinanciamientoProyectoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanciamientoProyecto(int id, FinanciamientoProyecto financiamientoProyecto)
        {
            if (id != financiamientoProyecto.Id)
            {
                return BadRequest();
            }

            _context.Entry(financiamientoProyecto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanciamientoProyectoExists(id))
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

        // POST: api/FinanciamientoProyectoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinanciamientoProyecto>> PostFinanciamientoProyecto(FinanciamientoProyecto financiamientoProyecto)
        {
          if (_context.FinanciamientoProyecto == null)
          {
              return Problem("Entity set 'SgamiContext.FinanciamientoProyecto'  is null.");
          }
            _context.FinanciamientoProyecto.Add(financiamientoProyecto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinanciamientoProyecto", new { id = financiamientoProyecto.Id }, financiamientoProyecto);
        }

        // DELETE: api/FinanciamientoProyectoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanciamientoProyecto(int id)
        {
            if (_context.FinanciamientoProyecto == null)
            {
                return NotFound();
            }
            var financiamientoProyecto = await _context.FinanciamientoProyecto.FindAsync(id);
            if (financiamientoProyecto == null)
            {
                return NotFound();
            }

            _context.FinanciamientoProyecto.Remove(financiamientoProyecto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FinanciamientoProyectoExists(int id)
        {
            return (_context.FinanciamientoProyecto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
