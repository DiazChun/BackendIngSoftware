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
    public class DefensasController : ControllerBase
    {
        private readonly SgamiContext _context;

        public DefensasController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/Defensas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Defensa>>> GetDefensa()
        {
          if (_context.Defensa == null)
          {
              return NotFound();
          }
            return await _context.Defensa.ToListAsync();
        }

        // GET: api/Defensas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Defensa>> GetDefensa(int id)
        {
          if (_context.Defensa == null)
          {
              return NotFound();
          }
            var defensa = await _context.Defensa.FindAsync(id);

            if (defensa == null)
            {
                return NotFound();
            }

            return defensa;
        }

        // PUT: api/Defensas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefensa(int id, Defensa defensa)
        {
            if (id != defensa.Id)
            {
                return BadRequest();
            }

            _context.Entry(defensa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefensaExists(id))
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

        // POST: api/Defensas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Defensa>> PostDefensa(Defensa defensa)
        {
          if (_context.Defensa == null)
          {
              return Problem("Entity set 'SgamiContext.Defensa'  is null.");
          }
            _context.Defensa.Add(defensa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDefensa", new { id = defensa.Id }, defensa);
        }

        // DELETE: api/Defensas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefensa(int id)
        {
            if (_context.Defensa == null)
            {
                return NotFound();
            }
            var defensa = await _context.Defensa.FindAsync(id);
            if (defensa == null)
            {
                return NotFound();
            }

            _context.Defensa.Remove(defensa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DefensaExists(int id)
        {
            return (_context.Defensa?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
