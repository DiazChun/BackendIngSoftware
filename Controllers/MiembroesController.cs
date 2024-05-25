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
    public class MiembroesController : ControllerBase
    {
        private readonly SgamiContext _context;

        public MiembroesController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/Miembroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Miembro>>> GetMiembro()
        {
          if (_context.Miembro == null)
          {
              return NotFound();
          }
            return await _context.Miembro.ToListAsync();
        }

        // GET: api/Miembroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Miembro>> GetMiembro(int id)
        {
          if (_context.Miembro == null)
          {
              return NotFound();
          }
            var miembro = await _context.Miembro.FindAsync(id);

            if (miembro == null)
            {
                return NotFound();
            }

            return miembro;
        }

        // PUT: api/Miembroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMiembro(int id, Miembro miembro)
        {
            if (id != miembro.Id)
            {
                return BadRequest();
            }

            _context.Entry(miembro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MiembroExists(id))
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

        // POST: api/Miembroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Miembro>> PostMiembro(Miembro miembro)
        {
          if (_context.Miembro == null)
          {
              return Problem("Entity set 'SgamiContext.Miembro'  is null.");
          }
            _context.Miembro.Add(miembro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMiembro", new { id = miembro.Id }, miembro);
        }

        // DELETE: api/Miembroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMiembro(int id)
        {
            if (_context.Miembro == null)
            {
                return NotFound();
            }
            var miembro = await _context.Miembro.FindAsync(id);
            if (miembro == null)
            {
                return NotFound();
            }

            _context.Miembro.Remove(miembro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MiembroExists(int id)
        {
            return (_context.Miembro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
