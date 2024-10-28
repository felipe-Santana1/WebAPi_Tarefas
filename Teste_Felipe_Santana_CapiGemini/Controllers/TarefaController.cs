using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Service.Interfaces;

namespace Teste_Felipe_Santana_CapiGemini.Controllers;

/// <summary>
/// Controller de Tarefa
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
[ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
[ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
[ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
public class TarefaController : ControllerBase
{
    private readonly ITarefaService _tarefaService;
    private readonly IValidator<TarefaDto> _validator;

    public TarefaController(ITarefaService tarefaService, IValidator<TarefaDto> validator)
    {
        _tarefaService = tarefaService;
        _validator = validator;
    }


    /// <summary>
    /// Listar Todas tarefas 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<ICollection<TarefaDto>>> ListarTodas()
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        ICollection<TarefaDto> result = await _tarefaService.BuscarTodasTarefas();

        if (result == null || !result.Any())
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Listar tarefa por ID
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TarefaDto>> BuscarPorID(int id)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        TarefaDto result = await _tarefaService.BuscarPorID(id);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Cadastrar Tarefa
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<TarefaDto>> Cadastrar([FromBody] TarefaDto request)
    {
        ValidationResult resultValidation = await _validator.ValidateAsync(request);

        if (!resultValidation.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, resultValidation.Errors);

        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        TarefaDto result = await _tarefaService.Adicionar(request);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Atualizar Tarefa
    /// </summary>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<TarefaDto>> Atualizar([FromBody] TarefaDto request, int id)
    {
        ValidationResult resultValidation = await _validator.ValidateAsync(request);

        if (!resultValidation.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, resultValidation.Errors);

        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        request.id = id;
        TarefaDto result = await _tarefaService.Atualizar(request, id);

        if (result == null)
            return NoContent();

        return Ok(result);
    }

    /// <summary>
    /// Deletar Tarefa
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Apagar(int id)
    {
        if (!ModelState.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);

        return Ok(await _tarefaService.Apagar(id));
    }
}