using CapitalPlacement.Assessment.Model.Entities;


namespace CapitalPlacement.Assessment.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<ApplicationForm> ApplicationFormRepository { get; }
        IGenericRepository<ProgramDetails> ProgramDetailsRepository { get; }
        IGenericRepository<WorkFlow> WorkFlowRepository { get; }
    }
}
