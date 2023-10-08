
using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.Model.Entities;
using Microsoft.Azure.Cosmos;
//using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CapitalPlacement.Assessment.DataAccess.Repository
{
    public class GenericRepository<TDocument> : IGenericRepository<TDocument> where TDocument : BaseEntity
    {
        private readonly Container _collection;
        private readonly CosmosClient _client;
        private readonly string _containername;
        private readonly string _databaseName;

        public GenericRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _collection = cosmosClient.GetContainer(databaseName, containerName);
            _client = cosmosClient;
            _databaseName = databaseName;
            _containername = containerName;
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            await _client.GetDatabase(_databaseName).CreateContainerIfNotExistsAsync(_containername, "/program");
            var query = _collection.GetItemQueryIterator<TDocument>
            (new QueryDefinition("SELECT * FROM c"));
            List<TDocument> results = new List<TDocument>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response);
            }
            return results;
        }

        public async Task<TDocument> GetByIdAsync(string id)
        {
            await _client.GetDatabase(_databaseName).CreateContainerIfNotExistsAsync(_containername, "/program");
            var value = await _collection.ReadItemAsync<TDocument>(id, new PartitionKey("program"));
            return value.Resource;
        }

        public async Task<TDocument> InsertAsync(TDocument document)
        {

            await _client.GetDatabase(_databaseName).CreateContainerIfNotExistsAsync(_containername,"/program");
            var item = await _collection.CreateItemAsync<TDocument>(document);
            return item;
        }

        public async Task<TDocument> UpdateAsync(string id, TDocument document)
        {
            await _client.GetDatabase(_databaseName).CreateContainerIfNotExistsAsync(_containername, "/program");
            document.id = id;
            var item = await _collection.ReplaceItemAsync<TDocument>(document, id);
            return item;
        }

        public async Task DeleteAsync(string id, string partition)
        {
            await _client.GetDatabase(_databaseName).CreateContainerIfNotExistsAsync(_containername, "/program");
            await _collection.DeleteItemAsync<TDocument>(id, new PartitionKey(partition));
        }
    }
}
