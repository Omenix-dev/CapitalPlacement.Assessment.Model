using Microsoft.AspNetCore.Mvc;


namespace CapitalPlacement.Assessment.API.Controllers
{
    [Route("CapitalPlacement/api/[controller]")]
    [ApiController]
    public class ProgramDetailController : ControllerBase
    {

        [HttpGet("get-all-program")]
        public IActionResult GetAllProgram()
        {
            return Ok();
        }

        // GET api/<ProgramDetailController>/5
        [HttpGet("get-byid-program/{id}")]
        public IActionResult GetById([FromQuery] string id)
        {
            return Ok();
        }

        // POST api/<ProgramDetailController>
        [HttpPost("add-program")]
        public IActionResult AddProgram([FromBody] string value)
        {
            return BadRequest();
        }

        // PUT api/<ProgramDetailController>/5
        [HttpPut("update-program/{id}")]
        public IActionResult UpdateProgram([FromRoute] string id, [FromBody] string value)
        {
            return BadRequest();
        }
    }
}
