using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFunctionsAzure
{
    internal class ApagarProduto
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<ApagarProduto> _logger;

        public ApagarProduto(ShopContext shopContext, ILogger<ApagarProduto> logger)
        {
            this.shopContext = shopContext;
            _logger = logger;
        }

        [Function("ApagarProduto")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "delete", Route = "ApagarProduto/{id}")]
        HttpRequest req, string id)
        {
            var produto = await shopContext.Produtos.FindAsync(Guid.Parse(id));
            if (produto is null) return new NotFoundResult();

            shopContext.Produtos.Remove(produto);
            await shopContext.SaveChangesAsync();
            _logger.LogInformation("#ApiFunctionsAzure - Produto apagado com sucesso!");

            return new NoContentResult();
        }
    }
}
