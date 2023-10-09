using CapitalPlacement.Assessment.DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {
        private readonly IProgramService _programService;
        public PreviewController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet("preview-program/{id}")]
        public async Task<IActionResult> PreviewProgram([FromRoute]string id)
        {
            var resp = await _programService.Preview(id);
            return StatusCode(resp.StatusCode, resp);
        }
    }
}
