using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.DataContext.Repository.Interface;
using ToDoListAPI.Model;
using ToDoListAPI.ViewModel;

namespace ToDoListAPI.Controllers
{
    [ApiController]
    [Route("api/tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarTarefa(TarefaViewModel tarefaView)
        {
            var tarefa = await _tarefaRepository.Adicionar(new Tarefa(tarefaView.Titulo, tarefaView.Descricao));

            return Ok(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa(TarefaEditorViewModel tarefaEditorView, int id)
        {
            return Ok(await _tarefaRepository.Atualizar(tarefaEditorView, id));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTarefa(int id)
        {

            if (await _tarefaRepository.Remover(id) == true)
            {
                return Ok("Tarefa excluida");
            }
            else
            {
                return Ok($"Tarefa não encontrada");
            }

        }

        [HttpGet]
        public async Task<IActionResult> ListarTarefas()
        {
            return Ok( await _tarefaRepository.ListarTarefas());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterTarefaPorID(int id)
        {
           return Ok (await _tarefaRepository.BuscarPorId(id));
        }
    }
}
