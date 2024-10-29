using Teste_Felipe_Santana_CapiGemini.Dto;

namespace Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

public interface ITarefaServico
{
    Task<ICollection<TarefaDto>> BuscarTodasTarefas();
    Task<TarefaDto> BuscarPorID(int id);
    Task<TarefaDto> Adicionar(TarefaDto request);
    Task<TarefaDto> Atualizar(TarefaDto request, int id);
    Task<bool> Apagar(int id);
}
