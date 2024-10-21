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
        // Arrange: cria o ViewModel e simula o comportamento do reposit�rio
        var tarefaViewModel = new TarefaViewModel
        {
            Titulo = "Tarefa Teste",
            Descricao = "Descri��o Teste"
        };

        var tarefaEsperada = new Tarefa(tarefaViewModel.Titulo, tarefaViewModel.Descricao);

        // Mock: define o que o m�todo Adicionar do reposit�rio deve retornar
        _mockRepository.Setup(repo => repo.Adicionar(It.IsAny<Tarefa>()))
            .ReturnsAsync(tarefaEsperada);

        // Act: executa o m�todo do controller
        var result = await _controller.AdicionarTarefa(tarefaViewModel);

        // Assert: verifica se o resultado � do tipo OkObjectResult e cont�m a tarefa correta
        var okResult = Assert.IsType<OkObjectResult>(result); // Verifica se � um Ok (200)
        var tarefaRetornada = Assert.IsType<Tarefa>(okResult.Value); // Verifica o valor retornado

        Assert.Equal(tarefaEsperada.Titulo, tarefaRetornada.Titulo);
        Assert.Equal(tarefaEsperada.Descricao, tarefaRetornada.Descricao);
    }

    [Fact]
    public async Task AtualizarTarefa_RetornarOkResult_QuandoTarefaAtualizada()
    {
        // Arrange: cria o ViewModel e a tarefa que ser� atualizada
        var tarefaEditorViewModel = new TarefaEditorViewModel
        {
            Titulo = "Tarefa Atualizada",
            Descricao = "Descri��o Atualizada"
        };

        var idTarefa = 1;
        var tarefaAtualizadaEsperada = new Tarefa(tarefaEditorViewModel.Titulo, tarefaEditorViewModel.Descricao)
        {
            Id = idTarefa
        };

        // Mock: define o comportamento do reposit�rio ao chamar o m�todo Atualizar
        _mockRepository.Setup(repo => repo.Atualizar(tarefaEditorViewModel, idTarefa))
            .ReturnsAsync(tarefaAtualizadaEsperada);

        // Act: executa o m�todo do controller
        var result = await _controller.AtualizarTarefa(tarefaEditorViewModel, idTarefa);

        // Assert: verifica se o resultado � do tipo OkObjectResult e cont�m a tarefa atualizada
        var okResult = Assert.IsType<OkObjectResult>(result); // Verifica se o status � Ok (200)
        var tarefaRetornada = Assert.IsType<Tarefa>(okResult.Value); // Verifica o valor retornado

        Assert.Equal(tarefaAtualizadaEsperada.Id, tarefaRetornada.Id);
        Assert.Equal(tarefaAtualizadaEsperada.Titulo, tarefaRetornada.Titulo);
        Assert.Equal(tarefaAtualizadaEsperada.Descricao, tarefaRetornada.Descricao);
    }

    [Fact]
    public async Task DeletarTarefa_RetornarOkResult_QuandoTarefaDeletada()
    {
        // Arrange: define o Id da tarefa a ser deletada
        var idTarefa = 1;

        // Mock: define o comportamento do reposit�rio ao chamar o m�todo Remover
        _mockRepository.Setup(repo => repo.Remover(idTarefa))
            .ReturnsAsync(true); // Simula que a tarefa foi removida com sucesso

        // Act: executa o m�todo do controller
        var result = await _controller.DeletarTarefa(idTarefa);

        // Assert: verifica se o resultado � do tipo OkObjectResult e que a tarefa foi removida
        var okResult = Assert.IsType<OkObjectResult>(result); // Verifica se o status � Ok (200)
        Assert.Equal("Tarefa excluida", okResult.Value); // Verifica o valor retornado
       
    }

}
