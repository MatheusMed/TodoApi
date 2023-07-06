using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRep;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio){
            _usuarioRep  = usuarioRepositorio;

        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios() 
        {
           List<UsuarioModel> usuarios =  await _usuarioRep.BuscarTodosUsuarios();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id) 
        {
             UsuarioModel usuario =  await _usuarioRep.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel usuarioModel) 
        {
            UsuarioModel usuario = await _usuarioRep.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        // atualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel,int id) 
        {   
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRep.Atualizar(usuarioModel,id);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id) 
        {   
            bool usuarioApagado = await _usuarioRep.Apagar(id);
            return Ok(usuarioApagado);
        }
    }
}
