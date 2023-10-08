

namespace CapitalPlacement.Assessment.DataAccess.Interfaces
{
    public interface IProgramService
    {
        void GetAllProgram();
        void GetById(string id);
        void AddProgram(string value);
        void UpdateProgram(string id, string value);
    }
}
