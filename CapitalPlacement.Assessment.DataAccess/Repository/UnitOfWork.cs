using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SpredMedia.Catalogue.Catalogue.Entity;
using SpredMedia.Catalogue.Core.Interface;
using System.IO;

namespace SpredMedia.Catalogue.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CosmosClient _cosmosClient;
        private IGenericRepository<Actor> _actorRepository;
      
        private IConfiguration _configuration;

        public UnitOfWork(CosmosClient cosmosClient, IConfiguration config)
        {
            _cosmosClient = cosmosClient;
            _configuration = config;
        }

        public IGenericRepository<Actor> ActorRepository => _actorRepository ??= new GenericRepository<Actor>(_database, "actors");
    
    }
}
