using AutoMapper;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Models;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;
using Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini.Service;

public class TarefaServico : ITarefaServico
{
    private readonly ITarefaRepositorio _tarefaRepositorio;
    private readonly IMapper _mapper;

    public TarefaServico(ITarefaRepositorio tarefaRepositorio, IMapper mapper)
    {
        _tarefaRepositorio = tarefaRepositorio;
        _mapper = mapper;
    }

    public async Task<TarefaDto> Adicionar(TarefaDto request)
    {
        TarefaModel result = await _tarefaRepositorio.Adicionar(_mapper.Map<TarefaModel>(request));
        return _mapper.Map<TarefaDto>(result);
    }

    public async Task<bool> Apagar(int id)
    {
        return await _tarefaRepositorio.Apagar(id);
    }

    public async Task<TarefaDto> Atualizar(TarefaDto request, int id)
    {
        TarefaModel result = await _tarefaRepositorio.Atualizar(_mapper.Map<TarefaModel>(request), id);
        return _mapper.Map<TarefaDto>(result);
    }

    public async Task<TarefaDto> BuscarPorID(int id)
    {
        TarefaModel result = await _tarefaRepositorio.BuscarPorID(id);

        return _mapper.Map<TarefaDto>(result);
    }

    public async Task<ICollection<TarefaDto>> BuscarTarefasUsuario(int idUsuario)
    {
        return _mapper.Map<ICollection<TarefaDto>>(await _tarefaRepositorio.BuscarTarefasUsuario(idUsuario));
    }

    public async Task<ICollection<TarefaDto>> BuscarTodasTarefas()
    {
        ICollection<TarefaModel> result = await _tarefaRepositorio.BuscarTodasTarefas();

        return _mapper.Map<ICollection<TarefaDto>>(result);
    }
}
