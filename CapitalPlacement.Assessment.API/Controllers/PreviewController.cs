using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class PreviewController : ControllerBase
    {


        [HttpGet("preview-program/{id}")]
        public IActionResult PreviewProgram([FromHeader]string id)
        {
            return Ok();
        }
    }
}
