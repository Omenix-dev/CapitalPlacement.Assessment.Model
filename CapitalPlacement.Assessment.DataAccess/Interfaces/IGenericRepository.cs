using CapitalPlacement.Assessment.Model.Entities;


namespace CapitalPlacement.Assessment.DataAccess.Interfaces
{
    public interface IGenericRepository<TDocument> where TDocument : BaseEntity
    {
        Task DeleteAsync(string id, string partition);
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<TDocument> GetByIdAsync(string id);
        Task<TDocument> InsertAsync(TDocument document);
        Task<TDocument> UpdateAsync(string id, TDocument document);
    }
}
