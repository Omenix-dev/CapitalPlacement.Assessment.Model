using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.DataAccess.Services;
using CapitalPlacement.Assessment.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IApplicants _applicantService;
        public ApplicationFormController(IApplicants applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet("get-all-applicants")]
        public async Task<IActionResult> GetAllApplicants()
        {
            var resp = await _applicantService.GetAllApplicants();
            return StatusCode(resp.StatusCode, resp);
        }

        [HttpGet("get-applicant/{id}")]
        public async Task<IActionResult> GetApplicantById([FromRoute]string id)
        {
            var resp = await _applicantService.GetById(id);
            return StatusCode(resp.StatusCode, resp);
        }

        
        [HttpPost("register-applicant")]
        public async Task<IActionResult> RegisterApplicant([FromBody] ApplicantRequestDto value)
        {
            var resp = await _applicantService.RegisterApplicant(value);
            return StatusCode(resp.StatusCode, resp);
        }

        [HttpPut("update-applicant/{id}")]
        public async Task<IActionResult> UpdateApplicant([FromRoute]string id, [FromBody] ApplicantRequestDto value)
        {
            var resp = await _applicantService.UpdateApplicant(id, value);
            return StatusCode(resp.StatusCode, resp);
        }
    }
}
