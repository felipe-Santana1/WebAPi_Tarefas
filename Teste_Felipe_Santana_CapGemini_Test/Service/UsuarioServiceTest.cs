using AutoMapper;
using Moq;
using Teste_Felipe_Santana_CapiGemini.Dto;
using Teste_Felipe_Santana_CapiGemini.Models;
using Teste_Felipe_Santana_CapiGemini.Repositories.Interfaces;
using Teste_Felipe_Santana_CapiGemini.Service;

namespace Teste_Felipe_Santana_CapGemini_UnitTest.Service;

public class UsuarioServiceTest
{
    private UsuarioServico _service;
    private readonly Mock<IUsuarioRepositorio> _repositorioFake = new();
    private readonly Mock<ITarefaRepositorio> _tarefaRepositorioFake = new();
    private readonly Mock<IMapper> _mapper = new();

    [Fact]
    [Trait("RecuperarTodosUsuarios", "Usuarios")]
    public async Task Deve_Retornar_Clientes_Existente_Valido()
    {
        //Arrange
        ICollection<UsuarioModel?> usuarioFakeReturn = new List<UsuarioModel?>() { new UsuarioModel() { Email = "Lorem", Id = 1, Nome = "Lorem" } };
        ICollection<UsuarioDto> usuarioDtoFakeReturn = new List<UsuarioDto>() { new UsuarioDto() { Nome = "Lorem", Id = 1, Email = "Lorem" } };
        _repositorioFake.Setup(s => s.BuscarTodosUsuarios()).ReturnsAsync(usuarioFakeReturn);

        _mapper.Setup(s => s.Map<ICollection<UsuarioDto>>(It.IsAny<ICollection<UsuarioModel?>>()))
        .Returns(usuarioDtoFakeReturn);

        _service = new UsuarioServico(_repositorioFake.Object, _tarefaRepositorioFake.Object, _mapper.Object);

        //Act
        var result = await _service.BuscarTodosUsuarios();

        //Assert
        _repositorioFake.Verify(v => v.BuscarTodosUsuarios(), Times.Once());
        _tarefaRepositorioFake.Verify(v => v.BuscarTarefasUsuario(It.IsAny<int>()), Times.Never);
        _mapper.Verify(v => v.Map<ICollection<UsuarioDto>>(It.IsAny<ICollection<UsuarioModel?>>()), Times.Once);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("RecuperarId", "Usuarios")]
    public async Task Deve_Retornar_Usuario_Por_Id_Valido()
    {
        //Arrange
        UsuarioModel? usuarioFakeReturn = new UsuarioModel() { Email = "Lorem", Id = 10, Nome = "Lorem" };
        UsuarioDto usuarioDtoFakeReturn = new UsuarioDto() { Nome = "Lorem", Id = 10, Email = "Lorem" };
        _repositorioFake.Setup(s => s.BuscarPorID(It.IsAny<int>())).ReturnsAsync(usuarioFakeReturn);
        _mapper.Setup(s => s.Map<UsuarioDto>(It.IsAny<UsuarioModel>())).Returns(usuarioDtoFakeReturn);
        _service = new UsuarioServico(_repositorioFake.Object, _tarefaRepositorioFake.Object, _mapper.Object);
        //Act
        var result = await _service.BuscarPorID(10);
        //Assert
        _repositorioFake.Verify(v => v.BuscarPorID(10), Times.Once());
        _tarefaRepositorioFake.Verify(v => v.BuscarTarefasUsuario(It.IsAny<int>()), Times.Never);
        _mapper.Verify(v => v.Map<UsuarioDto>(It.IsAny<UsuarioModel>()), Times.Once);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("AdicionarUsuario", "Usuarios")]
    public async Task Deve_Adicionar_Usuario_Valido()
    {
        //Arrange
        UsuarioModel usuarioFakeReturn = new UsuarioModel();
        _repositorioFake.Setup(s => s.AdicionarUsuario(It.IsAny<UsuarioModel>())).ReturnsAsync(usuarioFakeReturn);
        _mapper.Setup(s => s.Map<UsuarioDto>(It.IsAny<UsuarioModel>())).Returns(new UsuarioDto());
        _mapper.Setup(s => s.Map<UsuarioModel>(It.IsAny<UsuarioDto>())).Returns(new UsuarioModel());
        _service = new UsuarioServico(_repositorioFake.Object, _tarefaRepositorioFake.Object, _mapper.Object);
        //Act
        var result = await _service.AdicionarUsuario(new Teste_Felipe_Santana_CapiGemini.Dto.UsuarioDto());
        //Assert
        _repositorioFake.Verify(v => v.AdicionarUsuario(It.IsAny<UsuarioModel>()), Times.Once());
        _tarefaRepositorioFake.Verify(v => v.BuscarTarefasUsuario(It.IsAny<int>()), Times.Never);
        _mapper.Verify(v => v.Map<UsuarioDto>(It.IsAny<UsuarioModel>()), Times.Once);
        _mapper.Verify(v => v.Map<UsuarioModel>(It.IsAny<UsuarioDto>()), Times.Once);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("AtualizarUsuario", "Usuarios")]
    public async Task Deve_Atualizar_Usuario_Valido()
    {
        //Arrange
        UsuarioModel usuarioFakeReturn = new UsuarioModel();
        _repositorioFake.Setup(s => s.AtualizarUsuario(It.IsAny<UsuarioModel>(), It.IsAny<int>())).ReturnsAsync(usuarioFakeReturn);
        _mapper.Setup(s => s.Map<UsuarioDto>(It.IsAny<UsuarioModel>())).Returns(new UsuarioDto());
        _mapper.Setup(s => s.Map<UsuarioModel>(It.IsAny<UsuarioDto>())).Returns(new UsuarioModel());
        _service = new UsuarioServico(_repositorioFake.Object, _tarefaRepositorioFake.Object, _mapper.Object);
        //Act
        var result = await _service.AtualizarUsuario(new Teste_Felipe_Santana_CapiGemini.Dto.UsuarioDto(), 0);
        //Assert
        _repositorioFake.Verify(v => v.AtualizarUsuario(It.IsAny<UsuarioModel>(), It.IsAny<int>()), Times.Once());
        _tarefaRepositorioFake.Verify(v => v.BuscarTarefasUsuario(It.IsAny<int>()), Times.Never);
        _mapper.Verify(v => v.Map<UsuarioDto>(It.IsAny<UsuarioModel>()), Times.Once);
        _mapper.Verify(v => v.Map<UsuarioModel>(It.IsAny<UsuarioDto>()), Times.Once);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("DeletarUsuario", "Usuarios")]
    public async Task Deve_Deletar_Usuario_Valido()
    {
        //Arrange
        UsuarioModel usuarioFakeReturn = new UsuarioModel();
        ICollection<TarefaModel> tarefasFakeReturn = new List<TarefaModel>();
        _repositorioFake.Setup(s => s.ApagarUsuario(It.IsAny<int>())).ReturnsAsync(true);
        _tarefaRepositorioFake.Setup(s => s.BuscarTarefasUsuario(It.IsAny<int>())).ReturnsAsync(tarefasFakeReturn);
        _service = new UsuarioServico(_repositorioFake.Object, _tarefaRepositorioFake.Object, _mapper.Object);
        //Act
        var result = await _service.ApagarUsuario(0);
        //Assert
        _repositorioFake.Verify(v => v.ApagarUsuario(It.IsAny<int>()), Times.Once());
        _tarefaRepositorioFake.Verify(v => v.BuscarTarefasUsuario(It.IsAny<int>()), Times.Once);
        Assert.NotNull(result);
    }

    [Fact]
    [Trait("DeletarUsuario", "Usuarios")]
    public async Task Nao_Deve_Deletar_Usuario_Tarefa_Atrelada()
    {
        //Arrange
        UsuarioModel usuarioFakeReturn = new UsuarioModel();
        ICollection<TarefaModel> tarefasFakeReturn = new List<TarefaModel>() { new TarefaModel() };
        _repositorioFake.Setup(s => s.ApagarUsuario(It.IsAny<int>())).ReturnsAsync(true);
        _tarefaRepositorioFake.Setup(s => s.BuscarTarefasUsuario(It.IsAny<int>())).ReturnsAsync(tarefasFakeReturn);
        _service = new UsuarioServico(_repositorioFake.Object, _tarefaRepositorioFake.Object, _mapper.Object);
        //Act
        var result = await _service.ApagarUsuario(0);
        //Assert
        _repositorioFake.Verify(v => v.ApagarUsuario(It.IsAny<int>()), Times.Never());
        _tarefaRepositorioFake.Verify(v => v.BuscarTarefasUsuario(It.IsAny<int>()), Times.Once);
        Assert.NotNull(result);
    }
}
