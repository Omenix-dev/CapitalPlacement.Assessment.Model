using AutoMapper;
using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.Model.Dto;
using CapitalPlacement.Assessment.Model.Entities;
using CapitalPlacement.Assessment.Model.Enum;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CapitalPlacement.Assessment.DataAccess.Services
{
    public class WorkFlowServices : IWorkFlow
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public WorkFlowServices(IServiceProvider service)
        {
            _logger = service.GetRequiredService<ILogger>();
            _mapper = service.GetRequiredService<IMapper>();
            _unitOfWork = service.GetRequiredService<IUnitOfWork>();
            _configuration = service.GetRequiredService<IConfiguration>();
        }
        public async Task<ResponseDto<bool>> AddWorkFlow(WorkFlowRequestDto WorkFlowObject)
        {
            try
            {
                _logger.Information("checking for nullability");
                if (WorkFlowObject is not null)
                {
                    _logger.Information("inserting the workflow into the server with the title " +WorkFlowObject.StageName);
                    var WorkFlowDetails = _mapper.Map<WorkFlow>(WorkFlowObject);
                    WorkFlowDetails.CreatedAt = DateTime.Now;
                    WorkFlowDetails.UpdatedAt = DateTime.Now;
                    WorkFlowDetails.StageType = Enum.GetName(typeof(StageType), WorkFlowObject.StageType);
                    await _unitOfWork.WorkFlowRepository.InsertAsync(WorkFlowDetails);
                    return ResponseDto<bool>.Success("successfully inserted", true, (int)HttpStatusCode.OK);
                }
                return ResponseDto<bool>.Fail("the probject is null", (int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<bool>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<List<WorkFlowRequestDto>>> GetAllWorkFlow()
        {
            try
            {
                _logger.Information("getting all the workflows from the database ");
                var response = await _unitOfWork.WorkFlowRepository.GetAllAsync();
                var programDetails = _mapper.Map<List<WorkFlowRequestDto>>(response);
                return ResponseDto<List<WorkFlowRequestDto>>.Success("successfully Retrieved", programDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<List<WorkFlowRequestDto>>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<WorkFlowRequestDto>> GetByWorkFlowId(string id)
        {
            try
            {
                _logger.Information("getting all the details from the database ");
                var response = (await _unitOfWork.WorkFlowRepository.GetAllAsync()).FirstOrDefault(x => x.id == id);
                var programDetails = _mapper.Map<WorkFlowRequestDto>(response);
                _logger.Information("successfully retrived the data with the Id " + id);
                return ResponseDto<WorkFlowRequestDto>.Success("successfully retrieved", programDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<WorkFlowRequestDto>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }


        public async Task<ResponseDto<bool>> UpdateWorkFlow(string id, WorkFlowRequestDto value)
        {
            try
            {
                _logger.Information("checking for nullability");
                if (value is not null)
                {
                    _logger.Information("updating the program into the server with the title " + value.StageName);
                    var workflowDetails = _mapper.Map<WorkFlow>(value);
                    workflowDetails.UpdatedAt = DateTime.Now;
                    workflowDetails.StageType = Enum.GetName(typeof(StageType), value.StageType);
                    await _unitOfWork.WorkFlowRepository.UpdateAsync(id, workflowDetails);
                    return ResponseDto<bool>.Success("successfully updated", true, (int)HttpStatusCode.OK);
                }
                return ResponseDto<bool>.Fail("the project is null", (int)HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<bool>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }
    }
}
