using APICatalogo.Filters;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IntroducingController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<IntroducingController> _logger;
        private readonly IMyService _service;

        // Corrigido: ILogger<IntroducingController> e IMyService injetados no construtor
        public IntroducingController(
            IConfiguration configuration,
            ILogger<IntroducingController> logger,
            IMyService service)
        {
            _configuration = configuration;
            _logger = logger;
            _service = service;
        }

        // GET: api/<CategoriasController>
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))] // Filtro aplicado corretamente
        public async Task<ActionResult<string>> Get(string name)
        {
            // Usando o _service injetado no construtor
            var introducingMessage = await _service.Introducing("André");
            return Ok(introducingMessage);
        }

        // GET: api/<CategoriasController>
        [HttpGet("ConfigurationsParameters")]
        public ActionResult<string> GetConfigurations()
        {
            // Usando o _logger injetado no construtor
            _logger.LogInformation("........................................ Entrou no endpoint");

            var key1 = _configuration["Key1"];
            var sectionValue1 = _configuration["Section1:Key1"];
            return $"Chave 1: {key1}, Seção 1, chave 1: {sectionValue1}";
        }
    }
}