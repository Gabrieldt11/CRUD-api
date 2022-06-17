using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetUsuarios()
        {
            try
            {
                var usuarios = await _service.GetUsuarios();
                return Ok(usuarios);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter usuários");
            }
        }

        [HttpPost]
        public async Task<ActionResult> CreateUsuario(Usuario usuario)
        {
            try
            {
                await _service.CreateUsuario(usuario);
                return Ok("Usuário criado com sucesso");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao criar usuário");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUsuario(int id, [FromBody]Usuario usuario)
        {
            try
            {
                if(usuario.Id == id)
                {
                    await _service.UpdateUsuario(usuario);
                    return Ok("Usuário editado com sucesso");
                }
                else
                {
                    return BadRequest("Usuário não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao editar usuário");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUsuario(int id, [FromBody]Usuario usuario)
        {
            try
            {
                if(usuario.Id == id)
                {
                    await _service.DeleteUsuario(usuario);
                    return Ok("Usuário deletado com sucesso");
                }
                else
                {
                    return BadRequest("Usuário não encontrado");
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao deletar usuário");
            }
        }
    }
}