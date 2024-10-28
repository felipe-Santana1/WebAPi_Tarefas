using Teste_Felipe_Santana_CapiGemini.Models;

namespace Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;

public interface ITarefaRepositorio
{
    Task<ICollection<TarefaModel>> BuscarTodasTarefas();
    Task<TarefaModel> BuscarPorID(int id);
    Task<TarefaModel> Adicionar(TarefaModel tarefa);
    Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);
    Task<bool> Apagar(int id);


}
