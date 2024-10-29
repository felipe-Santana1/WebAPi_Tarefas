using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini.Controllers;

/// <summary>
/// Controller de Usuario
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioServico _usuarioService;
    private readonly IValidator<UsuarioDto> _validator;
    public UsuarioController(IUsuarioServico usuarioService, IValidator<UsuarioDto> validator)
    {
        _usuarioService = usuarioService;
        _validator = validator;
    }


    /// <summary>
    /// Listar todos os usuarios
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ICollection<UsuarioDto>>> BuscarTodosUsuarios()
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        ICollection<UsuarioDto?> result = await _usuarioService.BuscarTodosUsuarios();

        if (result == null || !result.Any())
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Listar por id
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> BuscarPorID(int id)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        UsuarioDto result = await _usuarioService.BuscarPorID(id);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Cadastrar usuario
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> Cadastrar([FromBody] UsuarioDto request)
    {
        ValidationResult resultValidation = await _validator.ValidateAsync(request);

        if (!resultValidation.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, resultValidation.Errors);

        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        UsuarioDto result = await _usuarioService.AdicionarUsuario(request);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Atualizar Usuario
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<UsuarioDto>> Atualizar([FromBody] UsuarioDto request, int id)
    { ValidationResult resultValidation = await _validator.ValidateAsync(request);

        if (!resultValidation.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, resultValidation.Errors);

        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        request.Id = id;
        UsuarioDto result = await _usuarioService.AtualizarUsuario(request, id);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Apagar usuario
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Apagar(int id)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        bool apagado = await _usuarioService.ApagarUsuario(id);

        return Ok(apagado);
    }
}
