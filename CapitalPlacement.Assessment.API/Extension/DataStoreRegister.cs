using Microsoft.Azure.Cosmos;
using System.Configuration;
using System.Security.Policy;

namespace CapitalPlacement.Assessment.API.Extension
{
    public static class DataStoreRegister
    {
        public static void AddDataStoreConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<CosmosClient>(provider =>
            {
                string connectionString = config.GetSection("AzureCosmosDBSetting").GetValue<string>("ConnectionString");
                string database = config.GetSection("AzureCosmosDBSetting").GetValue<string>("ConnectionString");
                CosmosClient cosmosClient = new CosmosClient(connectionString);
                return cosmosClient;
            });
        }
    }
}
