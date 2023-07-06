using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Enums;

namespace WebApplication1.Models
{
    
    public class TarefasModel
    {   
   
        public int Id { get; set; }
      
        public string? Nome { get; set; }
      
        public string? Descricao { get; set; }
  
        public StatusTarefa Status { get; set; }


        public int? UsuarioId { get; set; }

        public virtual UsuarioModel? Usuario { get; set; }

    }
}
