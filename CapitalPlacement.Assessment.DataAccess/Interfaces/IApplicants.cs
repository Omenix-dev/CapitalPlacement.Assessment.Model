using CapitalPlacement.Assessment.Model.Dto;

namespace CapitalPlacement.Assessment.DataAccess.Interfaces
{
    public interface IApplicants
    {
        public Task<ResponseDto<List<ApplicantRequestDto>>> GetAllApplicants();
        public Task<ResponseDto<ApplicantRequestDto>> GetById(string id);
        public Task<ResponseDto<bool>> RegisterApplicant(ApplicantRequestDto programObject);
        public Task<ResponseDto<bool>> UpdateApplicant(string id, ApplicantRequestDto value);
    }
}
