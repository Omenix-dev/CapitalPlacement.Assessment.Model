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
        private readonly string _databaseName;
        private readonly IConfiguration _configuration;
        private readonly string ProgramDocumentId;
        private readonly string WorkFLowDocumentId;
        private readonly string ApplicationDocumentId;
        public UnitOfWork(CosmosClient cosmosClient, IConfiguration config)
        {
            _cosmosClient = cosmosClient;
            _configuration = config;
            _databaseName = config.GetSection("AzureCosmosDBSetting").GetSection("DatabaseName").Value;
            ProgramDocumentId = config.GetSection("AzureCosmosDBSetting").GetSection("ProgramDocumentId").Value;
            WorkFLowDocumentId = config.GetSection("AzureCosmosDBSetting").GetSection("WorkFLowDocumentId").Value;
            ApplicationDocumentId = config.GetSection("AzureCosmosDBSetting").GetSection("ApplicationDocumentId").Value;
        }

        public IGenericRepository<ProgramDetails> ProgramDetailsRepository => _programDetailsRepository ??= new GenericRepository<ProgramDetails>(_cosmosClient, _databaseName, ProgramDocumentId);
        public IGenericRepository<ApplicationForm> ApplicationFormRepository => _applicationFormRepository ??= new GenericRepository<ApplicationForm>(_cosmosClient, _databaseName, ApplicationDocumentId);
        public IGenericRepository<WorkFlow> WorkFlowRepository => _workFlowRepository ??= new GenericRepository<WorkFlow>(_cosmosClient, _databaseName, WorkFLowDocumentId);

    }
}
