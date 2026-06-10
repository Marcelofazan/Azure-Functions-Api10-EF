using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFunctionsAzure
{
    internal class BuscarProdutos
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<BuscarProdutos> _logger;

        public BuscarProdutos(ShopContext shopContext, ILogger<BuscarProdutos> logger)
        {
            this.shopContext = shopContext;
            _logger = logger;
        }

        [Function("BuscarProdutos")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            var produtos = await shopContext.Produtos.ToListAsync();
            _logger.LogInformation("#ApiFunctionsAzure - Produtos consultados com sucesso!");

            return new OkObjectResult(produtos);
        }
    }
}
