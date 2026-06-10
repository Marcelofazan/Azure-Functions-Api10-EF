using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFunctionsAzure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            // 1. Aponta para o diretório atual onde o projeto está rodando
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<ShopContext>();

            // 2. Tenta buscar o nome da conexão em diferentes lugares do local.settings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                                   ?? configuration["Values:SqlConnectionString"];

            // 3. Informa o SQL Server com a string encontrada
            builder.UseSqlServer(connectionString);

            return new ShopContext(builder.Options);
        }
    }
}
