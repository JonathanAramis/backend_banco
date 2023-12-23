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
        public async Task<IActionResult> ObterExtrato([FromQuery] ObterExtratoContaCorrenteRequest request)
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
        public async Task<IActionResult> IncluirExtrato([FromQuery] ExtratoContaCorrenteRequest request)
        {
            await _contaCorrenteService.IncluirExtratoAvulso(request);
            return Created();
        }

        /// <summary>
        /// Atualizar valor do extrato da conta corrente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("AtualizarExtrato")]
        public async Task<IActionResult> AtualizarExtrato([FromQuery] AtualizarExtratoContaCorrenteRequest request)
        {
            _contaCorrenteService.AtualizarExtrato(request);
            return NoContent();
        }

        /// <summary>
        /// Atualizar status do extrato para cancelado.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("Cancelar/Extrato/{extratoId}")]
        public async Task<IActionResult> CancelarExtrato([FromRoute] int extratoId)
        {
            await _contaCorrenteService.CancelarExtrato(extratoId);
            return NoContent();
        }

        /// <summary>
        /// Incluir extrato não avulso da conta corrente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("IncluirExtratoNaoAvulso")]
        public async Task<IActionResult> IncluirExtratoNaoAvulso([FromQuery] ExtratoContaCorrenteRequest request)
        {
            await _contaCorrenteService.IncluirExtratoNaoAvulso(request);
            return Created();
        }
    }
}
