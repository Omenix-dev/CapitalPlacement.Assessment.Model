using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {

        [HttpGet("get-all-applicants")]
        public IActionResult GetAllApplicants()
        {
            return Ok();
        }

        [HttpGet("get-applicant/{id}")]
        public IActionResult GetApplicantById(string id)
        {
            return Ok();
        }

        
        [HttpPost("register-applicant")]
        public IActionResult RegisterApplicant([FromBody] string value)
        {
            return BadRequest();
        }

        // PUT api/<ProgramDetailController>/5
        [HttpPut("update-applicant/{id}")]
        public IActionResult UpdateApplicant([FromRoute]string id, [FromBody] string value)
        {
            return BadRequest();
        }
    }
}
