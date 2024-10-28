using AutoMapper;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Models;

namespace Teste_Felipe_Santana_CapiGemini.ResolveMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UsuarioDto, UsuarioModel>().ReverseMap();
        CreateMap<TarefaDto, TarefaModel>().ReverseMap();
    }
}
