using Microsoft.AspNetCore.Builder;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Assessment.DataAccess.Repository
{
    public static class DatabaseInitializer
    {
        public async static Task Initialize(IApplicationBuilder builder, IConfiguration config) 
        {
            using var serviceScope = builder.ApplicationServices.CreateScope();
            var cosmosClient = serviceScope.ServiceProvider.GetService<CosmosClient>();
            await cosmosClient.CreateDatabaseIfNotExistsAsync(config.GetSection("AzureCosmosDBSetting").GetSection("DatabaseName").Value);
        }
    }
}
