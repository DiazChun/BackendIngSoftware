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
    public class FuenteFinanciamientoesController : ControllerBase
    {
        private readonly SgamiContext _context;

        public FuenteFinanciamientoesController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/FuenteFinanciamientoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuenteFinanciamiento>>> GetFuenteFinanciamiento()
        {
          if (_context.FuenteFinanciamiento == null)
          {
              return NotFound();
          }
            return await _context.FuenteFinanciamiento.ToListAsync();
        }

        // GET: api/FuenteFinanciamientoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuenteFinanciamiento>> GetFuenteFinanciamiento(int id)
        {
          if (_context.FuenteFinanciamiento == null)
          {
              return NotFound();
          }
            var fuenteFinanciamiento = await _context.FuenteFinanciamiento.FindAsync(id);

            if (fuenteFinanciamiento == null)
            {
                return NotFound();
            }

            return fuenteFinanciamiento;
        }

        // PUT: api/FuenteFinanciamientoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuenteFinanciamiento(int id, FuenteFinanciamiento fuenteFinanciamiento)
        {
            if (id != fuenteFinanciamiento.Id)
            {
                return BadRequest();
            }

            _context.Entry(fuenteFinanciamiento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuenteFinanciamientoExists(id))
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

        // POST: api/FuenteFinanciamientoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuenteFinanciamiento>> PostFuenteFinanciamiento(FuenteFinanciamiento fuenteFinanciamiento)
        {
          if (_context.FuenteFinanciamiento == null)
          {
              return Problem("Entity set 'SgamiContext.FuenteFinanciamiento'  is null.");
          }
            _context.FuenteFinanciamiento.Add(fuenteFinanciamiento);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuenteFinanciamiento", new { id = fuenteFinanciamiento.Id }, fuenteFinanciamiento);
        }

        // DELETE: api/FuenteFinanciamientoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuenteFinanciamiento(int id)
        {
            if (_context.FuenteFinanciamiento == null)
            {
                return NotFound();
            }
            var fuenteFinanciamiento = await _context.FuenteFinanciamiento.FindAsync(id);
            if (fuenteFinanciamiento == null)
            {
                return NotFound();
            }

            _context.FuenteFinanciamiento.Remove(fuenteFinanciamiento);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuenteFinanciamientoExists(int id)
        {
            return (_context.FuenteFinanciamiento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
