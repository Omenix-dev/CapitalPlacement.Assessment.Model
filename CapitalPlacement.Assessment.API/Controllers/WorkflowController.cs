using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.DataAccess.Services;
using CapitalPlacement.Assessment.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkFlow _WorflowService;
        public WorkflowController(IWorkFlow Service)
        {
            _WorflowService = Service;
        }

        [HttpGet("get-all-workflow")]
        public async Task<IActionResult> GetAllWorkflow()
        {
            var resp = await _WorflowService.GetAllWorkFlow();
            return StatusCode(resp.StatusCode, resp);
        }

        // GET api/<ProgramDetailController>/5
        [HttpGet("get-byid-workflow/{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var resp = await _WorflowService.GetByWorkFlowId(id);
            return StatusCode(resp.StatusCode, resp);
        }

        // POST api/<ProgramDetailController>
        [HttpPost("add-workflow")]
        public async Task<IActionResult> AddWorkflow([FromBody] WorkFlowRequestDto value)
        {
            var resp = await _WorflowService.AddWorkFlow(value);
            return StatusCode(resp.StatusCode, resp);
        }

        // PUT api/<ProgramDetailController>/5
        [HttpPut("update-workflow/{id}")]
        public async Task<IActionResult> UpdateWorkflow([FromRoute]string id, [FromBody] WorkFlowRequestDto value)
        {
            var resp = await _WorflowService.UpdateWorkFlow(id, value);
            return StatusCode(resp.StatusCode, resp);
        }
    }
}
