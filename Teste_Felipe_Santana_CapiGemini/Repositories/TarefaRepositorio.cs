using Microsoft.EntityFrameworkCore;
using Teste_Felipe_Santana_CapiGemini.Data;
using Teste_Felipe_Santana_CapiGemini.Models;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini.Repositories;

public class TarefaRepositorio : ITarefaRepositorio
{

    private readonly SistemaTarefasDbcontex _dbContext;

    public TarefaRepositorio(SistemaTarefasDbcontex sistemaTarefasDbcontex) =>
        _dbContext = sistemaTarefasDbcontex;


    public async Task<TarefaModel> BuscarPorID(int id)
    {
        return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.id == id);
    }

    public async Task<ICollection<TarefaModel>> BuscarTodasTarefas()
    {
        return await _dbContext.Tarefas.Include(c => c.Usuario).ToListAsync();
    }

    public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
    {
        await _dbContext.Tarefas.AddAsync(tarefa);
        await _dbContext.SaveChangesAsync();

        return tarefa;
    }

    public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
    {
        TarefaModel tarefaPorId = await BuscarPorID(id) ?? throw new ArgumentException($"Tarefa do ID: {id} não foi localizada.");

        tarefaPorId.Nome = tarefa.Nome;
        tarefaPorId.Descricao = tarefa.Descricao;
        tarefaPorId.Status = tarefa.Status;
        tarefaPorId.UsuarioID = tarefa.UsuarioID;


        _dbContext.Tarefas.Update(tarefaPorId);
        await _dbContext.SaveChangesAsync();

        return tarefaPorId;

    }

    public async Task<bool> Apagar(int id)
    {
        TarefaModel tarefaPorId = await BuscarPorID(id) ?? throw new ArgumentException($"Tarefa do ID: {id} não foi localizada.");

        _dbContext.Remove(tarefaPorId);
        await _dbContext.SaveChangesAsync();

        return true;

    }

}
