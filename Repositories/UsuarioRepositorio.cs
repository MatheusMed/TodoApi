using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Repositories.Interfaces;

namespace WebApplication1.Repositories
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemasTafefasDbContext _db;
        public UsuarioRepositorio(SistemasTafefasDbContext sistemasTafefasDbContext)
        {
            _db = sistemasTafefasDbContext;
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuarioModel)
        {
             await _db.Usuarios.AddAsync(usuarioModel);
            await _db.SaveChangesAsync(true); 
            return usuarioModel;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null) { throw new Exception($"Usuario para ID:{id} nao foi encontrado."); }


            _db.Usuarios.Remove(usuarioPorId);
            await _db.SaveChangesAsync(true);
            return true;
           
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuarioModel, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null) {  throw new Exception($"Usuario para ID:{id} nao foi encontrado."); } 

           usuarioPorId.Nome = usuarioModel.Nome;
           usuarioPorId.Email = usuarioModel.Email;

            _db.Usuarios.Update(usuarioPorId);
           await  _db.SaveChangesAsync(true);


            return usuarioModel;

        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _db.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _db.Usuarios.ToListAsync();
        }
    }
}
