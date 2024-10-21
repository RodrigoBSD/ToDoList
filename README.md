# ToDoList  - API
Este projeto se trata de um desafio técnico, onde foi solicitado o desenvolvimento de um API “To Do List” com os métodos (create, read, update e delete).

## Tecnologias utilizadas

- .NET 8
- Entity Framework Core
- SQL Server
- xUnit

## Configurando Ambiente

Realize o backup do bando de dados Backup-BancoTarefas em algum servidor SqlServer

Imagem do banco criado

Altere o arquivo appsettings.json substituindo os campos HOST, USARNAME e PASSWORD com os dados do seu servidor.

Imagem do arquivo de configuração

## Como rodar o projeto 


## Como rodar os teste


## Endpoints

| Verbo  | Endpoint                | Parâmetro | Body                         | Response                               |
|--------|-------------------------|-----------|------------------------------|----------------------------------------|
| GET    | api/tarefa/             | N/A       | N/A                          | Retorna uma lista todas as tarefas     |
| GET    | api/tarefa/{id}         | id        | N/A                          | Retorna uma tarefa                     |
| POST   | api/tarefa              | N/A       | Schema TarefaViewModel       | Retorna a tarefa criada                |
| PUT    | api/tarefa/{id}         | id        | Schema TarefaEditorViewModel | Retorna a tarefa atualizada            |
| DELETE | api/tarefa/{id}         | id        | N/A                          | Retorna se a tarefa foi excluida ou não|

### Swagger
Colocar depois imagem do Swagger

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

