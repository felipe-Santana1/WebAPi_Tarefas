using AutoMapper;
using Moq;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Models;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;
using Teste_Felipe_Santana_CapiGemini.Service;

namespace Teste_Felipe_Santana_CapGemini_UnitTest.Service;

public class TarefaServiceTest
{
    private TarefaService _service;
    private readonly Mock<ITarefaRepositorio> _repositorioFake = new();
    private readonly Mock<IMapper> _mapper = new();

    [Fact]
    [Trait("AdicionarTarefa", "Tarefas")]
    public async Task Deve_Adicionar_Tarefa_Valida()
    {
        // Arrange
        TarefaModel tarefaFakeReturn = new TarefaModel();
        _repositorioFake.Setup(s => s.Adicionar(It.IsAny<TarefaModel>())).ReturnsAsync(tarefaFakeReturn);
        _mapper.Setup(m => m.Map<TarefaDto>(It.IsAny<TarefaModel>())).Returns(new TarefaDto());
        _mapper.Setup(m => m.Map<TarefaModel>(It.IsAny<TarefaDto>())).Returns(new TarefaModel());

        _service = new TarefaService(_repositorioFake.Object, _mapper.Object);

        // Act
        var result = await _service.Adicionar(new TarefaDto());

        // Assert
        _repositorioFake.Verify(v => v.Adicionar(It.IsAny<TarefaModel>()), Times.Once());
        _mapper.Verify(v => v.Map<TarefaDto>(It.IsAny<TarefaModel>()), Times.Once());
        _mapper.Verify(v => v.Map<TarefaModel>(It.IsAny<TarefaDto>()), Times.Once());
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("ApagarTarefa", "Tarefas")]
    public async Task Deve_Apagar_Tarefa_Valida()
    {
        // Arrange
        _repositorioFake.Setup(s => s.Apagar(It.IsAny<int>())).ReturnsAsync(true);
        _service = new TarefaService(_repositorioFake.Object, _mapper.Object);

        // Act
        var result = await _service.Apagar(1);

        // Assert
        _repositorioFake.Verify(v => v.Apagar(It.IsAny<int>()), Times.Once());
        Assert.True(result);
    }

    [Fact]
    [Trait("AtualizarTarefa", "Tarefas")]
    public async Task Deve_Atualizar_Tarefa_Valida()
    {
        // Arrange
        TarefaModel tarefaFakeReturn = new TarefaModel();
        _repositorioFake.Setup(s => s.Atualizar(It.IsAny<TarefaModel>(), It.IsAny<int>())).ReturnsAsync(tarefaFakeReturn);
        _mapper.Setup(m => m.Map<TarefaDto>(It.IsAny<TarefaModel>())).Returns(new TarefaDto());
        _mapper.Setup(m => m.Map<TarefaModel>(It.IsAny<TarefaDto>())).Returns(new TarefaModel());

        _service = new TarefaService(_repositorioFake.Object, _mapper.Object);

        // Act
        var result = await _service.Atualizar(new TarefaDto(), 1);

        // Assert
        _repositorioFake.Verify(v => v.Atualizar(It.IsAny<TarefaModel>(), It.IsAny<int>()), Times.Once());
        _mapper.Verify(v => v.Map<TarefaDto>(It.IsAny<TarefaModel>()), Times.Once());
        _mapper.Verify(v => v.Map<TarefaModel>(It.IsAny<TarefaDto>()), Times.Once());
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("BuscarTarefaPorId", "Tarefas")]
    public async Task Deve_Retornar_Tarefa_Por_Id_Valido()
    {
        // Arrange
        TarefaModel tarefaFakeReturn = new TarefaModel { id = 10, Nome = "Teste" };
        TarefaDto tarefaDtoFakeReturn = new TarefaDto { id = 10, Nome = "Teste" };

        _repositorioFake.Setup(s => s.BuscarPorID(It.IsAny<int>())).ReturnsAsync(tarefaFakeReturn);
        _mapper.Setup(m => m.Map<TarefaDto>(It.IsAny<TarefaModel>())).Returns(tarefaDtoFakeReturn);

        _service = new TarefaService(_repositorioFake.Object, _mapper.Object);

        // Act
        var result = await _service.BuscarPorID(10);

        // Assert
        _repositorioFake.Verify(v => v.BuscarPorID(10), Times.Once());
        _mapper.Verify(v => v.Map<TarefaDto>(It.IsAny<TarefaModel>()), Times.Once());
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("BuscarTodasTarefas", "Tarefas")]
    public async Task Deve_Retornar_Todas_Tarefas_Existentes()
    {
        // Arrange
        ICollection<TarefaModel> tarefasFakeReturn = new List<TarefaModel> { new TarefaModel { id = 1, Nome = "Teste" } };
        ICollection<TarefaDto> tarefasDtoFakeReturn = new List<TarefaDto> { new TarefaDto { id = 1, Nome = "Teste" } };

        _repositorioFake.Setup(s => s.BuscarTodasTarefas()).ReturnsAsync(tarefasFakeReturn);
        _mapper.Setup(m => m.Map<ICollection<TarefaDto>>(It.IsAny<ICollection<TarefaModel>>())).Returns(tarefasDtoFakeReturn);

        _service = new TarefaService(_repositorioFake.Object, _mapper.Object);

        // Act
        var result = await _service.BuscarTodasTarefas();

        // Assert
        _repositorioFake.Verify(v => v.BuscarTodasTarefas(), Times.Once());
        _mapper.Verify(v => v.Map<ICollection<TarefaDto>>(It.IsAny<ICollection<TarefaModel>>()), Times.Once());
        Assert.NotNull(result);
    }
}