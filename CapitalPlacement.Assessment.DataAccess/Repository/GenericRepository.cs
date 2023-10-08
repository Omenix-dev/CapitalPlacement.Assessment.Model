
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

        public GenericRepository(CosmosClient cosmosClient, string databaseName, string containerName)
        {
            _collection = cosmosClient.GetContainer(databaseName, containerName);
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
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
            var value = await _collection.ReadItemAsync<TDocument>(id, new PartitionKey(id));
            return value.Resource;
        }

        public async Task<TDocument> InsertAsync(TDocument document)
        {
            var item = await _collection.CreateItemAsync<TDocument>(document, new PartitionKey(document.Id));
            return item;
        }

        public async Task<TDocument> UpdateAsync(string id, TDocument document)
        {
            var item = await _collection.UpsertItemAsync<TDocument>(document, new PartitionKey(document.Id));
            return item;
        }

        public async Task DeleteAsync(string id, string partition)
        {
            await _collection.DeleteItemAsync<TDocument>(id, new PartitionKey(partition));
        }
    }
}
