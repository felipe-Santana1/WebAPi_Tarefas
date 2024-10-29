using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Models;

namespace Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

public interface ITarefaServico
{
    Task<ICollection<TarefaDto>> BuscarTodasTarefas();
    Task<ICollection<TarefaDto>> BuscarTarefasUsuario(int idUsuario);
    Task<TarefaDto> BuscarPorID(int id);
    Task<TarefaDto> Adicionar(TarefaDto request);
    Task<TarefaDto> Atualizar(TarefaDto request, int id);
    Task<bool> Apagar(int id);
}
