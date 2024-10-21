using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListAPI.Enum;

namespace ToDoListAPI.Model
{

    public class Tarefa
    {
        public Tarefa(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = Status.Pendente;

        }

        public Tarefa(string titulo, string descricao, Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Status = status;

        }

        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public Status Status { get; set; }

        public DateTime DataConclusao { get; set; }

    }
}
