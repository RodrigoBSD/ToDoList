using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ToDoListAPI.DataContext;
using ToDoListAPI.DataContext.Repository;
using ToDoListAPI.DataContext.Repository.Interface;
using ToDoListAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ConnectionContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.Services.AddScoped<ITarefaRepository, TarefaRepository>();

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>

       c.SwaggerDoc("v1", new OpenApiInfo { Title = "To Do List", Version = "v1" })

    );

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "To Do List v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
