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
    public class ArchivoCompartidoesController : ControllerBase
    {
        private readonly SgamiContext _context;

        public ArchivoCompartidoesController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/ArchivoCompartidoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArchivoCompartido>>> GetArchivoCompartido()
        {
          if (_context.ArchivoCompartido == null)
          {
              return NotFound();
          }
            return await _context.ArchivoCompartido.ToListAsync();
        }

        // GET: api/ArchivoCompartidoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArchivoCompartido>> GetArchivoCompartido(int id)
        {
          if (_context.ArchivoCompartido == null)
          {
              return NotFound();
          }
            var archivoCompartido = await _context.ArchivoCompartido.FindAsync(id);

            if (archivoCompartido == null)
            {
                return NotFound();
            }

            return archivoCompartido;
        }

        // PUT: api/ArchivoCompartidoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArchivoCompartido(int id, ArchivoCompartido archivoCompartido)
        {
            if (id != archivoCompartido.Id)
            {
                return BadRequest();
            }

            _context.Entry(archivoCompartido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArchivoCompartidoExists(id))
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

        // POST: api/ArchivoCompartidoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArchivoCompartido>> PostArchivoCompartido(ArchivoCompartido archivoCompartido)
        {
          if (_context.ArchivoCompartido == null)
          {
              return Problem("Entity set 'SgamiContext.ArchivoCompartido'  is null.");
          }
            _context.ArchivoCompartido.Add(archivoCompartido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArchivoCompartido", new { id = archivoCompartido.Id }, archivoCompartido);
        }

        // DELETE: api/ArchivoCompartidoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArchivoCompartido(int id)
        {
            if (_context.ArchivoCompartido == null)
            {
                return NotFound();
            }
            var archivoCompartido = await _context.ArchivoCompartido.FindAsync(id);
            if (archivoCompartido == null)
            {
                return NotFound();
            }

            _context.ArchivoCompartido.Remove(archivoCompartido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArchivoCompartidoExists(int id)
        {
            return (_context.ArchivoCompartido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
