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
    public class DerechosHumanoesController : ControllerBase
    {
        private readonly SgamiContext _context;

        public DerechosHumanoesController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/DerechosHumanoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DerechosHumano>>> GetDerechosHumanos()
        {
          if (_context.DerechosHumanos == null)
          {
              return NotFound();
          }
            return await _context.DerechosHumanos.ToListAsync();
        }

        // GET: api/DerechosHumanoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DerechosHumano>> GetDerechosHumano(int id)
        {
          if (_context.DerechosHumanos == null)
          {
              return NotFound();
          }
            var derechosHumano = await _context.DerechosHumanos.FindAsync(id);

            if (derechosHumano == null)
            {
                return NotFound();
            }

            return derechosHumano;
        }

        // PUT: api/DerechosHumanoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDerechosHumano(int id, DerechosHumano derechosHumano)
        {
            if (id != derechosHumano.Id)
            {
                return BadRequest();
            }

            _context.Entry(derechosHumano).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DerechosHumanoExists(id))
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

        // POST: api/DerechosHumanoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DerechosHumano>> PostDerechosHumano(DerechosHumano derechosHumano)
        {
          if (_context.DerechosHumanos == null)
          {
              return Problem("Entity set 'SgamiContext.DerechosHumanos'  is null.");
          }
            _context.DerechosHumanos.Add(derechosHumano);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDerechosHumano", new { id = derechosHumano.Id }, derechosHumano);
        }

        // DELETE: api/DerechosHumanoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDerechosHumano(int id)
        {
            if (_context.DerechosHumanos == null)
            {
                return NotFound();
            }
            var derechosHumano = await _context.DerechosHumanos.FindAsync(id);
            if (derechosHumano == null)
            {
                return NotFound();
            }

            _context.DerechosHumanos.Remove(derechosHumano);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DerechosHumanoExists(int id)
        {
            return (_context.DerechosHumanos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
