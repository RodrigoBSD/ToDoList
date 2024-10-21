using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Security.AccessControl;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoListAPI.ViewModel;
using ToDoListAPI.Model;
using ToDoListAPI.Enum;
using ToDoListAPI.DataContext;
using ToDoListAPI.DataContext.Repository.Interface;

namespace ToDoListAPI.DataContext.Repository;

public class TarefaRepository : ITarefaRepository
{
    private readonly ConnectionContext _connection;

    public TarefaRepository(ConnectionContext ConnectionContext)
    {
        _connection = ConnectionContext;
    }

    public async Task<Tarefa> Adicionar(Tarefa tarefa)
    {
        await _connection.Tarefas.AddAsync(tarefa);
        await _connection.SaveChangesAsync();
        return tarefa;
    }

    public async Task<bool> Remover(int idTarefa)
    {
        Tarefa tarefa = await BuscarPorId(idTarefa);

        if (tarefa == null)
        {
            return false;
        }
        else
        {
            _connection.Tarefas.Remove(tarefa);
            _connection.SaveChanges();
            return true;
        }

    }

    public async Task<Tarefa> Atualizar(TarefaEditorViewModel tarefaEditorView, int idTarefa)
    {
        var tarefa = await BuscarPorId(idTarefa);

        var tarefaEditor = new Tarefa(tarefaEditorView.Titulo, tarefaEditorView.Descricao, tarefaEditorView.Status);

        if (tarefaEditorView?.Status == Status.Realizado)
        {
            tarefa.DataConclusao = DateTime.Now;
            tarefa.Status = tarefaEditor.Status;
        }

        tarefa.Titulo = tarefaEditor.Titulo;
        tarefa.Descricao = tarefaEditor.Descricao;


        _connection.Tarefas.Update(tarefa);
        _connection.SaveChanges();

        return tarefa;
    }

    public async Task<Tarefa> BuscarPorId(int idTarefa)
    {
        var tarefa = await _connection.Tarefas.FirstOrDefaultAsync(x => x.Id == idTarefa);
        return tarefa;
    }

    public async Task<List<Tarefa>> ListarTarefas()
    {
        return await _connection.Tarefas.ToListAsync();

    }

}
