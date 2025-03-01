using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IntroducingController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public IntroducingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        public async Task<ActionResult<string>> Get([FromServices] IMyService _service, string name)
        {
            var introducingMessage = await _service.Introducing("André");
            return Ok(introducingMessage);
        }

        // GET: api/<CategoriasController>
        [HttpGet("ConfigurationsParameters")]
        public async Task<ActionResult<string>> Get()
        {
            var key1 =  _configuration["Key1"];
            var sectionValue1 = _configuration["Section1:Key1"];
            return $"Chave 1 {key1}  Seção 1, chave 1 {sectionValue1}";
        }

    }
}
