using WebApplication1.Models;

namespace WebApplication1.Repositories.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarPorId(int id);
        Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel);
        Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id);
        Task<bool> Apagar(int id);
    }
}
