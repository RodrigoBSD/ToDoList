using ToDoListAPI.Model;
using ToDoListAPI.ViewModel;

namespace ToDoListAPI.DataContext.Repository.Interface;

public interface ITarefaRepository
{
    Task<Tarefa> Adicionar(Tarefa tarefa);

    Task<Tarefa> Atualizar(TarefaEditorViewModel tarefaEditorView, int idTarefa);

    Task<bool> Remover(int idTarefa);

    Task<Tarefa?> BuscarPorId(int idTarefa);

    Task<List<Tarefa>> ListarTarefas();


}
