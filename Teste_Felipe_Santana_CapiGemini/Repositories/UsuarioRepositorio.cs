using Microsoft.EntityFrameworkCore;
using Teste_Felipe_Santana_CapiGemini.Data;
using Teste_Felipe_Santana_CapiGemini.Models;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini.Repositories;

public class UsuarioRepositorio : IUsuarioRepositorio
{

    private readonly SistemaTarefasDbcontex _dbContext;
    public UsuarioRepositorio(SistemaTarefasDbcontex sistemaTarefasDbcontex) =>
        _dbContext = sistemaTarefasDbcontex;

    public async Task<UsuarioModel?> BuscarPorID(int id)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<ICollection<UsuarioModel>> BuscarTodosUsuarios()
    {
        return await _dbContext.Usuarios.ToListAsync();
    }
    public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
    {
        await _dbContext.Usuarios.AddAsync(usuario);
        await _dbContext.SaveChangesAsync();

        return usuario;
    }
    public async Task<UsuarioModel> AtualizarUsuario(UsuarioModel usuario, int id)
    {
        UsuarioModel usuarioPorId = await BuscarPorID(id) ?? throw new ArgumentException($"Usuário do ID: {id} não foi localizado");

        usuarioPorId.Nome = usuario.Nome;
        usuarioPorId.Email = usuario.Email;

        _dbContext.Usuarios.Update(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return usuarioPorId;

    }
    public async Task<bool> ApagarUsuario(int id)
    {
        UsuarioModel usuarioPorId = await BuscarPorID(id) ?? throw new ArgumentException($"Usuário do ID: {id} não foi localizado.");

        _dbContext.Remove(usuarioPorId);
        await _dbContext.SaveChangesAsync();

        return true;

    }

}
