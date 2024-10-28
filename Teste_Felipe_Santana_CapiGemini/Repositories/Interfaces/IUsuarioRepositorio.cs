using Teste_Felipe_Santana_CapiGemini.Models;

namespace Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;

public interface IUsuarioRepositorio
{
    Task<ICollection<UsuarioModel?>> BuscarTodosUsuarios();
    Task<UsuarioModel> BuscarPorID(int id);
    Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario);
    Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id);
    Task<bool> ApagarUsuario(int id);


}
