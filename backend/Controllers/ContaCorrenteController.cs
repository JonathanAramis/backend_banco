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

        /// <summary>
        /// Obter Extrato da conta corrente.
        /// </summary>
        /// <returns></returns>
        [HttpGet("ObterExtrato")]
        public async Task<IActionResult> ObterExtrato([FromQuery]ObterExtratoContaCorrenteRequest request) 
        {
            var response = await _contaCorrenteService.ObterExtrato(request);
            return Ok(response);
        }

        /// <summary>
        /// Incluir extrato da conta corrente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("IncluirExtrato")]
        public async Task<IActionResult> IncluirExtrato([FromQuery]ExtratoContaCorrenteRequest request)
        {
            await _contaCorrenteService.IncluirExtrato(request);
            return Created();
        }

        /// <summary>
        /// Atualizar valor do extrato da conta corrente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("AtualizarExtrato")]
        public async Task<IActionResult> AtualizarExtrato([FromQuery] AtualizarExtratoContaCorrenteResponse request)
        {
            _contaCorrenteService.AtualizarExtrato(request);
            return NoContent();
        }
    }
}
