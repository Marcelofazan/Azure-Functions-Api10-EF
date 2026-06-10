## ⚙️ Azure-Functions-Api-EF10
Exemplo de simulação de API com Triggers do Azure Functions e EntityFramework em C# .NET Core 10 com banco de dados SQL-Server.

O que voçê vai ver nesse Projeto

| Tecnologia| Descrição |
|-----------|-----------|
| Azure Functions | Arquitetura serverless, com uso de gatilhos de API (HTTP Triggers) |
| Computação em Nuvem | Infraestrutura global de data centers para hospedar, gerenciar e escalar aplicativos e dados pela internet |

#### ⚠️ String de conexão do banco
Modifique a string de conexão no arquivo local.settings.json se caso necessário, no trecho indicado:
```bash 
"Server=localhost\\SQLEXPRESS;Database=Shop;Trusted_Connection=True;TrustServerCertificate=True;"
```

#### 🔄 Executar a aplicação

- Criar Migrations EntityFramework no Visual Studio e Update da database SQLServer .

```bash 
Install-Package Microsoft.EntityFrameworkCore.Tools
Add-Migration InitialCreate -StartupProject "ApiFunctionsAzure"
Update-Database -StartupProject "ApiFunctionsAzure"
```

#### 🧪 Executar Functions
Importar Coleção de testes que contém no diretório Postman **APIFunctionsAzure.postman_collection**

| Metodo | Descrição |
|-----------|-----------|
| RegistrarProduto: [POST] | http://localhost:7006/api/RegistrarProduto|
| BuscarProdutos: [GET] | http://localhost:7006/api/BuscarProdutos |
| BuscarProduto: [GET] |  http://localhost:7006/api/BuscarProduto/{id} |
| AtualizarProduto: [PUT] | http://localhost:7006/api/AtualizarProduto |
| ApagarProduto: [DELETE] | http://localhost:7006/api/ApagarProduto/{id} |

