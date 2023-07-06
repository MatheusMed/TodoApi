using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data.map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefasModel>
    {
        public void Configure(EntityTypeBuilder<TarefasModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).HasMaxLength(1000);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioId);
            builder.HasOne(x => x.Usuario);
        }

    }
}
