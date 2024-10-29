using Teste_Felipe_Santana_CapiGemini.Dto;

namespace Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

public interface IUsuarioServico
{
    Task<ICollection<UsuarioDto?>> BuscarTodosUsuarios();
    Task<UsuarioDto> BuscarPorID(int id);
    Task<UsuarioDto> AdicionarUsuario(UsuarioDto request);
    Task<UsuarioDto> AtualizarUsuario(UsuarioDto request, int id);
    Task<bool> ApagarUsuario(int id);
}
