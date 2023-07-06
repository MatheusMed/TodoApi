using System.ComponentModel;

namespace WebApplication1.Enums
{
    public enum StatusTarefa
    {
        [Description("A Fazer")]
        Afazer = 1,
        [Description("Em Andamento")]
        EmAdamento = 2,
        [Description("Concluido")]
        Concluido = 3
    }
}
