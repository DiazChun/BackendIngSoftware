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
    public class LoginController : ControllerBase
    {
        private readonly SgamiContext _context;

        public LoginController(SgamiContext context)
        {
            _context = context;
        }

        // Nuevo endpoint para el login
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] Login login)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'SgamiContext.Usuario' is null.");
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

            if (usuario == null)
            {
                return Unauthorized();
            }

            // Asegúrate de que CreatedAtAction está utilizando el nombre correcto de la acción
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            if (_context.Usuario == null)
            {
                return NotFound();
            }
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
