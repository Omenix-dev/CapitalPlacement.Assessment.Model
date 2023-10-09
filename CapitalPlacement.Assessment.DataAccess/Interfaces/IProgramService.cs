

using CapitalPlacement.Assessment.Model.Dto;

namespace CapitalPlacement.Assessment.DataAccess.Interfaces
{
    public interface IProgramService
    {
        public Task<ResponseDto<List<ProgramRequestDto>>> GetAllProgram();
        public Task<ResponseDto<ProgramRequestDto>> GetById(string id);
        public Task<ResponseDto<bool>> AddProgram(ProgramRequestDto programObject);
        public Task<ResponseDto<bool>> UpdateProgram(string id, ProgramRequestDto value);
        public Task<ResponseDto<ProgramRequestDto>> Preview(string id);
    }
}
