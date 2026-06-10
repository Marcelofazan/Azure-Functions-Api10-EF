## ⚙️ Api10-Functions-Azure
Exemplo de criação de API com Functions Azure em C# .NET Core 10.

O que voçê vai ver nesse Projeto

| Tecnologia| Descrição |
|-----------|-----------|
| Azure Functions | Arquitetura serverless, com uso de gatilhos de API (HTTP Triggers) |
| Computação em Nuvem | Infraestrutura global de data centers para hospedar, gerenciar e escalar aplicativos e dados pela internet |

🔄 Executar a aplicação

- Criar Migrations e Update Database SQLServer 

```bash 
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate -StartupProject "ApiFunctionsAzure"
Update-Database -StartupProject "ApiFunctionsAzure"
```

#### 🧪 Executar Functions
Importar Coleção de testes que contém no diretório Postman **APIFunctionsAzure.postman_collection**


| Metodo | Descrição |
|-----------|-----------|
| ApagarProduto: [DELETE] | http://localhost:7006/api/ApagarProduto/{id} |
| AtualizarProduto: [PUT] | http://localhost:7006/api/AtualizarProduto |
| BuscarProduto: [GET] |  http://localhost:7006/api/BuscarProduto/{id} |
| BuscarProdutos: [GET] | http://localhost:7006/api/BuscarProdutos |
| RegistrarProduto: [POST] | http://localhost:7006/api/RegistrarProduto|


#### ⚠️ String de conexão do banco
Modifique a string de conexão no arquivo local.settings.json se caso necessário, no trecho indicado:
```bash 
"Server=localhost\\SQLEXPRESS;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True;"
```