using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFunctionsAzure
{
    internal class BuscarProduto
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<BuscarProduto> _logger;

        public BuscarProduto(ShopContext shopContext, ILogger<BuscarProduto> logger)
        {
            this.shopContext = shopContext;
            _logger = logger;
        }

        [Function("BuscarProduto")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "BuscarProduto/{id}")]
        HttpRequest req, string id)
        {
            var produto = await shopContext.Produtos.FindAsync(Guid.Parse(id));
            if (produto is null) return new NotFoundResult();
            _logger.LogInformation("#ApiFunctionsAzure - Produto consultado com sucesso!");

            return new OkObjectResult(produto);
        }
    }
}
