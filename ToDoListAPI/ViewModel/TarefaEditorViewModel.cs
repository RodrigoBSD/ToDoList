using System.ComponentModel.DataAnnotations;
using ToDoListAPI.Enum;

namespace ToDoListAPI.ViewModel
{
    public class TarefaEditorViewModel
    {

        [Required(ErrorMessage = " Titulo é obrigatorio")]
        [MaxLength(100, ErrorMessage = "Titulo não pode ter mais de 100 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = " Descrição é obrigatorio")]
        [MaxLength(350, ErrorMessage = "Descrição não pode ter mais de 350 caracteres")]
        public string Descricao { get; set; }

        public Status Status { get; set; }

    }
}
