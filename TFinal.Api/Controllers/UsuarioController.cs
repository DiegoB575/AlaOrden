using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlaOrden.TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController:ControllerBase
    {
         private readonly ProyectoDBContext _context;
        public UsuarioController (ProyectoDBContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Usuario> GetUsuario() {
            return _context.Usuarios;
        }

       [HttpGet ("{id}")]
        public async Task<IActionResult> GetUsuario([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUsuario = await _context.Usuarios.SingleOrDefaultAsync(p => p.IdUsuario == id);

            if(currentUsuario == null)
            {
                return NotFound();
            }

            return Ok(currentUsuario);

        }

         [HttpGet ("{apodo}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string apodo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUsuario = await _context.Usuarios.SingleOrDefaultAsync(p =>p.apodo == apodo);

            if(currentUsuario == null)
            {
                return NotFound();
            }

            return Ok(currentUsuario);

        }

          [HttpGet ("{email}")]
        public async Task<IActionResult> GetUsuario([FromRoute] string email)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentUsuario = await _context.Usuarios.SingleOrDefaultAsync(p =>p.email == email);

            if(currentUsuario == null)
            {
                return NotFound();
            }

            return Ok(currentUsuario);

        }



        [HttpPost]
         public async Task<IActionResult> PostUsuario([FromBody] Usuario Usuario){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Usuarios.Add(Usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetUsuario", new {id = Usuario.IdUsuario},Usuario);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutUsuario ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentUsuario = await _context.Usuarios.SingleOrDefaultAsync(p => p.IdUsuario == id);

             if(currentUsuario == null){
                 return NotFound();
             }

             _context.Usuarios.Update(currentUsuario);
             await _context.SaveChangesAsync();

             return Ok(currentUsuario);
         }

    }
}