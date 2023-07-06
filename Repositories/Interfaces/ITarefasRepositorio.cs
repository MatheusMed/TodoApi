using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface ITarefasRepositorio
    {
        Task<List<TarefasModel>> BuscarTodasTarefas();
        Task<TarefasModel> BuscarPorId(int id);
        Task<TarefasModel> Adicionar(TarefasModel TarefasModel);
        Task<TarefasModel> Atualizar(TarefasModel TarefasModel, int id);
        Task<bool> Apagar(int id);
    }
}
