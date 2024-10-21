using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using ToDoListAPI.ViewModel;
using ToDoListAPI.Controllers;
using ToDoListAPI.DataContext.Repository.Interface;
using ToDoListAPI.Model;

namespace ToDoTests;

public class TarefaControllerTests
{
    private readonly Mock<ITarefaRepository> _mockRepository;
    private readonly TarefaController _controller;

    public TarefaControllerTests()
    {
        _mockRepository = new Mock<ITarefaRepository>();
        _controller = new TarefaController(_mockRepository.Object);
    }

    [Fact]
    public async Task AdicionarTarefa_RetornarOkResult_QuandoTarefaValida()
    {
        // Arrange
        var tarefaViewModel = new TarefaViewModel
        {
            Titulo = "Tarefa Teste",
            Descricao = "Descrição Teste"
        };

        var tarefaEsperada = new Tarefa(tarefaViewModel.Titulo, tarefaViewModel.Descricao);

        // Mock
        _mockRepository.Setup(repo => repo.Adicionar(It.IsAny<Tarefa>()))
            .ReturnsAsync(tarefaEsperada);

        // Act
        var result = await _controller.AdicionarTarefa(tarefaViewModel);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result); 
        var tarefaRetornada = Assert.IsType<Tarefa>(okResult.Value); 

        Assert.Equal(tarefaEsperada.Titulo, tarefaRetornada.Titulo);
        Assert.Equal(tarefaEsperada.Descricao, tarefaRetornada.Descricao);
    }

    [Fact]
    public async Task AtualizarTarefa_RetornarOkResult_QuandoTarefaAtualizada()
    {
        // Arrange
        var tarefaEditorViewModel = new TarefaEditorViewModel
        {
            Titulo = "Tarefa Atualizada",
            Descricao = "Descrição Atualizada"
        };

        var idTarefa = 1;
        var tarefaAtualizadaEsperada = new Tarefa(tarefaEditorViewModel.Titulo, tarefaEditorViewModel.Descricao)
        {
            Id = idTarefa
        };

        // Mock
        _mockRepository.Setup(repo => repo.Atualizar(tarefaEditorViewModel, idTarefa))
            .ReturnsAsync(tarefaAtualizadaEsperada);

        // Act
        var result = await _controller.AtualizarTarefa(tarefaEditorViewModel, idTarefa);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result); 
        var tarefaRetornada = Assert.IsType<Tarefa>(okResult.Value); 

        Assert.Equal(tarefaAtualizadaEsperada.Id, tarefaRetornada.Id);
        Assert.Equal(tarefaAtualizadaEsperada.Titulo, tarefaRetornada.Titulo);
        Assert.Equal(tarefaAtualizadaEsperada.Descricao, tarefaRetornada.Descricao);
    }

    [Fact]
    public async Task DeletarTarefa_RetornarOkResult_QuandoTarefaDeletada()
    {
        // Arrange
        var idTarefa = 1;

        // Mock
        _mockRepository.Setup(repo => repo.Remover(idTarefa))
            .ReturnsAsync(true); 

        // Act
        var result = await _controller.DeletarTarefa(idTarefa);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result); 
        Assert.Equal("Tarefa excluida", okResult.Value); 
       
    }

}
