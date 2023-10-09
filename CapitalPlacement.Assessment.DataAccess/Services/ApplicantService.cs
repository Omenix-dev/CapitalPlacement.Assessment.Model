
using AutoMapper;
using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.Model.Dto;
using CapitalPlacement.Assessment.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Net;

namespace CapitalPlacement.Assessment.DataAccess.Services
{
    public class ApplicantService : IApplicants
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ApplicantService(IServiceProvider service)
        {
            _logger = service.GetRequiredService<ILogger>();
            _mapper = service.GetRequiredService<IMapper>();
            _unitOfWork = service.GetRequiredService<IUnitOfWork>();
            _configuration = service.GetRequiredService<IConfiguration>();
        }
        public async Task<ResponseDto<List<ApplicantRequestDto>>> GetAllApplicants()
        {
            try
            {
                _logger.Information("getting all the details from the database ");
                var response = await _unitOfWork.ApplicationFormRepository.GetAllAsync();
                var ApplicantsDetails = _mapper.Map<List<ApplicantRequestDto>>(response);
                return ResponseDto<List<ApplicantRequestDto>>.Success("successfully Retrieved", ApplicantsDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<List<ApplicantRequestDto>>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<ApplicantRequestDto>> GetById(string id)
        {
            try
            {
                _logger.Information("getting all the details from the database ");
                var response = (await _unitOfWork.ApplicationFormRepository.GetAllAsync()).FirstOrDefault(x => x.id == id);
                var programDetails = _mapper.Map<ApplicantRequestDto>(response);
                _logger.Information("successfully retrived the data with the Id " + id);
                return ResponseDto<ApplicantRequestDto>.Success("successfully retrieved", programDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<ApplicantRequestDto>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<bool>> RegisterApplicant(ApplicantRequestDto applicantObject)
        {
            try
            {
                _logger.Information("checking for nullability");
                if (applicantObject is not null)
                {
                    _logger.Information("inserting the program into the server with the email " + applicantObject.personalInfo.Email);
                    var applicationDetails = _mapper.Map<ApplicationForm>(applicantObject);
                    applicationDetails.CreatedAt = DateTime.Now;
                    applicationDetails.UpdatedAt = DateTime.Now;
                    await _unitOfWork.ApplicationFormRepository.InsertAsync(applicationDetails);
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

        public async Task<ResponseDto<bool>> UpdateApplicant(string id, ApplicantRequestDto value)
        {
            try
            {
                _logger.Information("checking for nullability");
                if (value is not null)
                {
                    _logger.Information("updating the program into the server with the name " + value.personalInfo.FirstName);
                    var programDetails = _mapper.Map<ApplicationForm>(value);
                    programDetails.UpdatedAt = DateTime.Now;
                    await _unitOfWork.ApplicationFormRepository.UpdateAsync(id, programDetails);
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
