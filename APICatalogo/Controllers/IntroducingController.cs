using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IntroducingController : ControllerBase
    {
        public IntroducingController() { }

        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<ActionResult<string>> Get([FromServices] IMyService _service, string name)
        {
            var introducingMessage = await _service.Introducing("André");
            return Ok(introducingMessage);
        }

    }
}
