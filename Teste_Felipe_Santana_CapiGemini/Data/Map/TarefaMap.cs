using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste_Felipe_Santana_CapiGemini.Models;

namespace Teste_Felipe_Santana_CapiGemini.Data.Map;

public class TarefaMap: IEntityTypeConfiguration<TarefaModel>
{
    public void Configure(EntityTypeBuilder<TarefaModel> builder)
    {
        builder.ToTable("Tarefa");
        builder.HasKey(x => x.id);
        builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.Status).IsRequired();
        builder.HasOne(x => x.Usuario);
    }
}
