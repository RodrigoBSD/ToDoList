# ToDoList  - API
Este projeto se trata de um desafio técnico, onde foi solicitado o desenvolvimento de um API “To Do List” com os métodos (create, read, update e delete).

## Tecnologias utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- xUnit

## Configurando Ambiente

Realize o backup do bando de dados **ToDoAPI.bak** em algum servidor SqlServer

![image](https://github.com/user-attachments/assets/ca012e62-e9ea-4fa3-ad9c-31d2103d66f9)

Altere o arquivo **appsettings.json** substituindo os campos **HOST**, **USARNAME** e **PASSWORD** com os dados do seu servidor.

![image](https://github.com/user-attachments/assets/4a6af04c-33c8-4aec-80d3-71871f464880)

## Endpoints

| Verbo  | Endpoint                | Parâmetro | Body                         | Response                               |
|--------|-------------------------|-----------|------------------------------|----------------------------------------|
| GET    | api/tarefa/             | N/A       | N/A                          | Retorna uma lista todas as tarefas     |
| GET    | api/tarefa/{id}         | id        | N/A                          | Retorna uma tarefa                     |
| POST   | api/tarefa              | N/A       | Schema TarefaViewModel       | Retorna a tarefa criada                |
| PUT    | api/tarefa/{id}         | id        | Schema TarefaEditorViewModel | Retorna a tarefa atualizada            |
| DELETE | api/tarefa/{id}         | id        | N/A                          | Retorna se a tarefa foi excluida ou não|

### Swagger

![image](https://github.com/user-attachments/assets/ff662c14-f626-4a8b-820f-4a32c63db6f0)


Schema para interagir com os metodos que exigirem

TarefaViewModel
```json
 {
  "titulo": "string",
  "descricao": "string"
}
```
TarefaEditorViewModel
```json
{
  "titulo": "string",
  "descricao": "string",
  "status": 0
}
```

