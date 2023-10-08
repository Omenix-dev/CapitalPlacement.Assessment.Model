using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {

        [HttpGet("get-all-workflow")]
        public IActionResult GetAllWorkflow()
        {
            return Ok();
        }

        // GET api/<ProgramDetailController>/5
        [HttpGet("get-byid-workflow/{id}")]
        public IActionResult GetById([FromQuery]string id)
        {
            return Ok();
        }

        // POST api/<ProgramDetailController>
        [HttpPost("add-workflow")]
        public IActionResult AddWorkflow([FromBody] string value)
        {
            return BadRequest();
        }

        // PUT api/<ProgramDetailController>/5
        [HttpPut("update-workflow/{id}")]
        public IActionResult UpdateWorkflow([FromRoute]string id, [FromBody] string value)
        {
            return BadRequest();
        }
    }
}
