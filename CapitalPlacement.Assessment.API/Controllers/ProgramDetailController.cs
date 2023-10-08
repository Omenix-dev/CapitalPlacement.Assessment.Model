using CapitalPlacement.Assessment.DataAccess.Interfaces;
using CapitalPlacement.Assessment.Model.Dto;
using Microsoft.AspNetCore.Mvc;


namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class ProgramDetailController : ControllerBase
    {
        private readonly IProgramService _programService;
        public ProgramDetailController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet("get-all-program")]
        public async Task<IActionResult> GetAllProgram()
        {
            var resp = await _programService.GetAllProgram();
            return StatusCode(resp.StatusCode, resp);
        }

        // GET api/<ProgramDetailController>/5
        [HttpGet("get-byid-program/{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var resp = await _programService.GetById(id);
            return StatusCode(resp.StatusCode, resp);
        }

        // POST api/<ProgramDetailController>
        [HttpPost("add-program")]
        public async Task<IActionResult> AddProgram([FromBody] ProgramRequestDto value)
        {
            var resp = await _programService.AddProgram(value);
            return StatusCode(resp.StatusCode, resp);
        }

        // PUT api/<ProgramDetailController>/5
        [HttpPut("update-program/{id}")]
        public async Task<IActionResult> UpdateProgram([FromRoute] string id, [FromBody] ProgramRequestDto value)
        {
            var resp = await _programService.UpdateProgram(id, value);
            return StatusCode(resp.StatusCode, resp);
        }
    }
}
