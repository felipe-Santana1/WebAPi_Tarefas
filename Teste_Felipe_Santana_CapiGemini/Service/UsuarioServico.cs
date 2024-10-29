using AutoMapper;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Models;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;
using Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini.Service;

public class UsuarioServico : IUsuarioServico
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IMapper _mapper;
    public UsuarioServico(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _mapper = mapper;
    }

    public async Task<UsuarioDto> AdicionarUsuario(UsuarioDto request)
    {
        UsuarioModel result = await _usuarioRepositorio.AdicionarUsuario(_mapper.Map<UsuarioModel>(request));

        return _mapper.Map<UsuarioDto>(result);
    }

    public async Task<bool> ApagarUsuario(int id)
    {
        return await _usuarioRepositorio.ApagarUsuario(id);
    }

    public async Task<UsuarioDto> AtualizarUsuario(UsuarioDto request, int id)
    {
        UsuarioModel result = await _usuarioRepositorio.AtualizarUsuario(_mapper.Map<UsuarioModel>(request), id);

        return _mapper.Map<UsuarioDto>(result);
    }

    public async Task<UsuarioDto> BuscarPorID(int id)
    {
        UsuarioModel result = await _usuarioRepositorio.BuscarPorID(id);

        return _mapper.Map<UsuarioDto>(result);
    }

    public async Task<ICollection<UsuarioDto?>> BuscarTodosUsuarios()
    {
        ICollection<UsuarioModel?> result = await _usuarioRepositorio.BuscarTodosUsuarios();

        return _mapper.Map<ICollection<UsuarioDto?>>(result);
    }
}
