using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.DataAccess.Repository;
using CapitalPlacement.Assessment.Model.Entities;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
namespace SpredMedia.Catalogue.Infrastructure.Repository
{
    

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CosmosClient _cosmosClient;
        private IGenericRepository<ProgramDetails> _programDetailsRepository;
        private IGenericRepository<ApplicationForm> _applicationFormRepository;
        private IGenericRepository<WorkFlow> _workFlowRepository;
        private readonly string _databaseName = "CapitalPlacementDB";
        private readonly IConfiguration _configuration;
        public UnitOfWork(CosmosClient cosmosClient, IConfiguration config)
        {
            _cosmosClient = cosmosClient;
            _configuration = config;
            //_databaseName = _configuration.GetSection("AzureCosmosDBSetting").GetValue<string>("");
        }

        public IGenericRepository<ProgramDetails> ProgramDetailsRepository => _programDetailsRepository ??= new GenericRepository<ProgramDetails>(_cosmosClient, _databaseName, "ProgramDetails");
        public IGenericRepository<ApplicationForm> ApplicationFormRepository => _applicationFormRepository ??= new GenericRepository<ApplicationForm>(_cosmosClient, _databaseName, "Applicants");
        public IGenericRepository<WorkFlow> WorkFlowRepository => _workFlowRepository ??= new GenericRepository<WorkFlow>(_cosmosClient, _databaseName, "WorkFLow");

    }
}
