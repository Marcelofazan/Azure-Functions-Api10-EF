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
    internal class RegistrarProduto
    {
        private readonly ShopContext shopContext;
        private readonly ILogger<RegistrarProduto> _logger;

        public RegistrarProduto(ShopContext shopContext, ILogger<RegistrarProduto> logger)
        {
            this.shopContext = shopContext;
            _logger = logger;
        }

        [Function("RegistrarProduto")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var body = await new StreamReader(req.Body).ReadToEndAsync();
            var produto = JsonConvert.DeserializeObject<Produtos>(body);

            await shopContext.AddAsync(produto);
            await shopContext.SaveChangesAsync();
            _logger.LogInformation("#ApiFunctionsAzure - Produto registrado com sucesso!");

            return new OkObjectResult(produto.Id);
        }
    }
}
