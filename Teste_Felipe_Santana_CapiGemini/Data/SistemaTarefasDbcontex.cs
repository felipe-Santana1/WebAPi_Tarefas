using Microsoft.EntityFrameworkCore;
using Teste_Felipe_Santana_CapiGemini.Data.Map;
using Teste_Felipe_Santana_CapiGemini.Models;

namespace Teste_Felipe_Santana_CapiGemini.Data;

public class SistemaTarefasDbcontex : DbContext
{
    public SistemaTarefasDbcontex(DbContextOptions<SistemaTarefasDbcontex> options)
        : base(options)
    { }


    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<TarefaModel> Tarefas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioMap());
        modelBuilder.ApplyConfiguration(new TarefaMap());

        base.OnModelCreating(modelBuilder);
    }
}
