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
    public class ProgramServices : IProgramService
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;   
        public ProgramServices(IServiceProvider service)
        {
            _logger = service.GetRequiredService<ILogger>();
            _mapper = service.GetRequiredService<IMapper>();
            _unitOfWork = service.GetRequiredService<IUnitOfWork>();
            _configuration = service.GetRequiredService<IConfiguration>();
        }
        public async Task<ResponseDto<bool>> AddProgram(ProgramRequestDto programObject)
        {
            try
            {
                _logger.Information("checking for nullability");
                if(programObject is not null)
                {
                    _logger.Information("inserting the program into the server with the title " +programObject.ProgramTitle);
                    var programDetails = _mapper.Map<ProgramDetails>(programObject);
                    programDetails.CreatedAt = DateTime.Now;
                    programDetails.UpdatedAt = DateTime.Now;    
                    await _unitOfWork.ProgramDetailsRepository.InsertAsync(programDetails);
                    return ResponseDto<bool>.Success("successfully inserted", true,(int)HttpStatusCode.OK);
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

        public async Task<ResponseDto<List<ProgramRequestDto>>> GetAllProgram()
        {
            try
            {
                _logger.Information("getting all the details from the database ");
                var response = await _unitOfWork.ProgramDetailsRepository.GetAllAsync();
                var programDetails = _mapper.Map<List<ProgramRequestDto>>(response);
                return ResponseDto<List<ProgramRequestDto>>.Success("successfully Retrieved", programDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<List<ProgramRequestDto>>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<ProgramRequestDto>> GetById(string id)
        {
            try
            {
                _logger.Information("getting all the details from the database ");
                //var response = await _unitOfWork.ProgramDetailsRepository.GetByIdAsync(id);
                var response =( await _unitOfWork.ProgramDetailsRepository.GetAllAsync()).FirstOrDefault(x=>x.id == id);
                var programDetails = _mapper.Map<ProgramRequestDto>(response);
                _logger.Information("successfully retrived the data with the Id " + id);
                return ResponseDto<ProgramRequestDto>.Success("successfully retrieved", programDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<ProgramRequestDto>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<ProgramRequestDto>> Preview(string id)
        {
            try{
                _logger.Information("previewing the program with the Id "+ id);
                //var response = await _unitOfWork.ProgramDetailsRepository.GetByIdAsync(id);
                var response = (await _unitOfWork.ProgramDetailsRepository.GetAllAsync()).FirstOrDefault(x => x.id == id);
                var programDetails = _mapper.Map<ProgramRequestDto>(response);
                _logger.Information("successfully retrived the data with the Id " + id);
                return ResponseDto<ProgramRequestDto>.Success("successfully retrieved", programDetails, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                _logger.Error(ex.StackTrace);
                return ResponseDto<ProgramRequestDto>.Fail("somthing went wrong contact admin", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task<ResponseDto<bool>> UpdateProgram(string id, ProgramRequestDto programObject)
        {
            try
            {
                _logger.Information("checking for nullability");
                if (programObject is not null)
                {
                    _logger.Information("updating the program into the server with the title " + programObject.ProgramTitle);
                    var programDetails = _mapper.Map<ProgramDetails>(programObject);
                    programDetails.UpdatedAt = DateTime.Now;
                    await _unitOfWork.ProgramDetailsRepository.UpdateAsync(id,programDetails);
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
