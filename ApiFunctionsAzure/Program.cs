using ApiFunctionsAzure;
using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Azure.Functions.Worker.OpenTelemetry;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenTelemetry;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();


var connString = Environment.GetEnvironmentVariable("SqlServerConnection");
builder.Services.AddDbContext<ShopContext>(opts => opts.UseSqlServer(connString));

var appInsightsKey = builder.Configuration.GetValue<string>("APPLICATIONINSIGHTS_CONNECTION_STRING")
                     ?? builder.Configuration.GetValue<string>("Values:APPLICATIONINSIGHTS_CONNECTION_STRING");

builder.Services.AddOpenTelemetry()
    .UseFunctionsWorkerDefaults()
    .UseAzureMonitorExporter(options =>
    {
        options.ConnectionString = appInsightsKey;
    });

builder.Build().Run();
