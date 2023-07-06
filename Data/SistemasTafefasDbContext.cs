using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.map;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class SistemasTafefasDbContext : DbContext
    {
        public SistemasTafefasDbContext(DbContextOptions<SistemasTafefasDbContext> options) : base(options)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefasModel> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
