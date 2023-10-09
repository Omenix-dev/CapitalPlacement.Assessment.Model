
using CapitalPlacement.Assessment.Model.Dto;

namespace CapitalPlacement.Assessment.DataAccess.Interfaces
{
    public interface IWorkFlow
    {
        public Task<ResponseDto<List<WorkFlowRequestDto>>> GetAllWorkFlow();
        public Task<ResponseDto<WorkFlowRequestDto>> GetByWorkFlowId(string id);
        public Task<ResponseDto<bool>> AddWorkFlow(WorkFlowRequestDto WorkFlowObject);
        public Task<ResponseDto<bool>> UpdateWorkFlow(string id, WorkFlowRequestDto value);
    }
}
