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
    public class RolUsuariosController : ControllerBase
    {
        private readonly SgamiContext _context;

        public RolUsuariosController(SgamiContext context)
        {
            _context = context;
        }

        // GET: api/RolUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolUsuario>>> GetRolUsuario()
        {
          if (_context.RolUsuario == null)
          {
              return NotFound();
          }
            return await _context.RolUsuario.ToListAsync();
        }

        // GET: api/RolUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolUsuario>> GetRolUsuario(int id)
        {
          if (_context.RolUsuario == null)
          {
              return NotFound();
          }
            var rolUsuario = await _context.RolUsuario.FindAsync(id);

            if (rolUsuario == null)
            {
                return NotFound();
            }

            return rolUsuario;
        }

        // PUT: api/RolUsuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolUsuario(int id, RolUsuario rolUsuario)
        {
            if (id != rolUsuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(rolUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolUsuarioExists(id))
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

        // POST: api/RolUsuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolUsuario>> PostRolUsuario(RolUsuario rolUsuario)
        {
          if (_context.RolUsuario == null)
          {
              return Problem("Entity set 'SgamiContext.RolUsuario'  is null.");
          }
            _context.RolUsuario.Add(rolUsuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRolUsuario", new { id = rolUsuario.Id }, rolUsuario);
        }

        // DELETE: api/RolUsuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolUsuario(int id)
        {
            if (_context.RolUsuario == null)
            {
                return NotFound();
            }
            var rolUsuario = await _context.RolUsuario.FindAsync(id);
            if (rolUsuario == null)
            {
                return NotFound();
            }

            _context.RolUsuario.Remove(rolUsuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolUsuarioExists(int id)
        {
            return (_context.RolUsuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
