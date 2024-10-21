using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListAPI.Model;

namespace ToDoListAPI.DataContext
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {

            builder.ToTable("TAREFAS");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Status);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(350);
            builder.Property(x => x.DataConclusao);
        }
    }
}
