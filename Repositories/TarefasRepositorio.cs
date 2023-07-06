using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class TarefasRepositorio : ITarefasRepositorio
    {
        private readonly SistemasTafefasDbContext _db;
        public TarefasRepositorio(SistemasTafefasDbContext sistemasTafefasDbContext)
        {
            _db = sistemasTafefasDbContext;
        }

        public async Task<TarefasModel> Adicionar(TarefasModel TarefasModel, int id)
        
        {
             TarefasModel tarefaPorId = await BuscarPorId(id);
             
            if(tarefaPorId.UsuarioId == null) {throw new Exception($"Nao foi encontrado {id}"); }
            await _db.Tarefas.AddAsync(TarefasModel);
            await _db.SaveChangesAsync(true); 
            return TarefasModel;
        }

        public async Task<TarefasModel> Adicionar(TarefasModel TarefasModel)
        {
            await _db.Tarefas.AddAsync(TarefasModel);
            await _db.SaveChangesAsync(true); 
            return TarefasModel;
        }

        public async Task<bool> Apagar(int id)
        {
            TarefasModel tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null) { throw new Exception($"Tarefa para ID:{id} nao foi encontrado."); }


            _db.Tarefas.Remove(tarefaPorId);
            await _db.SaveChangesAsync(true);
            return true;
        }

        public async Task<TarefasModel> Atualizar(TarefasModel TarefasModel, int id)
        {
            TarefasModel tarefaPorId = await BuscarPorId(id);

            if(tarefaPorId == null) {  throw new Exception($"Tarefa para ID:{id} nao foi encontrado."); } 

           tarefaPorId.Nome = TarefasModel.Nome;
           tarefaPorId.Descricao = TarefasModel.Descricao;
           tarefaPorId.Status = TarefasModel.Status;
           tarefaPorId.UsuarioId = TarefasModel.UsuarioId;

            _db.Tarefas.Update(tarefaPorId);
           await  _db.SaveChangesAsync(true);


            return tarefaPorId;
        }

        

        public async Task<TarefasModel> BuscarPorId(int id)
        {
            return await _db.Tarefas.FirstOrDefaultAsync(x => x.Id == id);

        }

    
        public async Task<List<TarefasModel>> BuscarTodasTarefas()
        {
            return await _db.Tarefas.ToListAsync();
        }
    }
}
