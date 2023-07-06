using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefasRepositorio _tarefa;
        public TarefaController(ITarefasRepositorio tarefaRepositorio){
            _tarefa  = tarefaRepositorio;

        }

        [HttpGet]
        public async Task<ActionResult<List<TarefasModel>>> BuscarTodasTarefas() 
        {
           List<TarefasModel> usuarios =  await _tarefa.BuscarTodasTarefas();
            return Ok(usuarios);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TarefasModel>> BuscarPorId(int id) 
        {
             TarefasModel usuario =  await _tarefa.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<TarefasModel>> Adicionar([FromBody] TarefasModel TarefasModel) 
        {   
       
            if(TarefasModel.UsuarioId > 0){
            TarefasModel usuario = await _tarefa.Adicionar(TarefasModel);
            return Ok(usuario);
            } else{
                return BadRequest();
            }
        }

        // atualizar
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefasModel>> Atualizar([FromBody] TarefasModel TarefasModel,int id) 
        {   
         
            TarefasModel usuario = await _tarefa.Atualizar(TarefasModel,id);
            return Ok(usuario);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefasModel>> Apagar(int id) 
        {   
            bool usuarioApagado = await _tarefa.Apagar(id);
            return Ok(usuarioApagado);
        }
    }
}
