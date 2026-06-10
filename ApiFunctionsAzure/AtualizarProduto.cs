using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFunctionsAzure
{
    internal class AtualizarProduto
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<AtualizarProduto> _logger;

        public AtualizarProduto(ShopContext shopContext, ILogger<AtualizarProduto> logger)
        {
            this.shopContext = shopContext;
            _logger = logger;
        }

        [Function("AtualizarProduto")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "put")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var produto = JsonConvert.DeserializeObject<Produtos>(body);

            var oldProdutos = await shopContext.Produtos.FindAsync(produto.Id);
            if (oldProdutos is null) return new NotFoundResult();

            oldProdutos.Nome = produto.Nome;
            oldProdutos.Preco = produto.Preco;
            _logger.LogInformation("#ApiFunctionsAzure - Produto atualizado com sucesso!");

            await shopContext.SaveChangesAsync();

            return new NoContentResult();
        }
    }
}
