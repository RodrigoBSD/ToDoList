using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Enum;

namespace ToDoListAPI.ViewModel
{
    public class TarefaEditorViewModel
    {

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }

    }
}
