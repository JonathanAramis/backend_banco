using backend.Interfaces.Services;
using backend.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ILogger<ContaCorrenteController> _logger;
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(ILogger<ContaCorrenteController> logger,
                                       IContaCorrenteService contaCorrenteService)
        {
            _logger = logger;
            _contaCorrenteService = contaCorrenteService;
        }

        [HttpGet("ObterExtrato")]
        public async Task<IEnumerable<ExtratoContaCorrenteResponse>> ObterExtrato()
        {
            var response = await _contaCorrenteService.ObterExtrato();
            return response;
        }

        [HttpGet("IncluirExtrato")]
        public async Task IncluirExtrato()
        {
            //await _contaCorrenteService.IncluirExtrato();
            //return response;
        }
    }
}
