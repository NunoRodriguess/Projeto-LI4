// LicitacoesController.cs
using BirdBoxFull.Server.Services.ServicoProduto;
using BirdBoxFull.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BirdBoxFull.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicitacoesController : ControllerBase
    {
        private readonly IServicoLicitacao _licitacaoService;

        public LicitacoesController(IServicoLicitacao licitacaoService)
        {
            _licitacaoService = licitacaoService;
        }

        [HttpPost]
        public async Task<ActionResult> AddLicitacao(Licitacao newLicitacao)
        {
            Console.WriteLine("Tou aqui CONTROLLER FORA");
            try
            {
                Console.WriteLine("Tou aqui CONTROLLER");
                await _licitacaoService.AddLicitacao(newLicitacao);
                return Ok("Licitacao added successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{username}/{codLeilao}")]
        public async Task<ActionResult<Licitacao>> ConsultarLicitacao(string username, string codLeilao)
        {

        
            try
            {
                var licitacao = await _licitacaoService.ConsultarLicitacao(username, codLeilao);
                if (licitacao != null)
                {
                    return Ok(licitacao);
                }
                else
                {
                    return NotFound("Licitacao not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }

		[HttpGet("list/{username}")]
		public async Task<ActionResult<List<Licitacao>>> ConsultarLicitacaoList(string username)
		{
			try
			{
				var licitacoes = await _licitacaoService.ConsultarLicitacaoList(username);
				return Ok(licitacoes);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
			}
		}

        [HttpDelete("{codLicitacao}")]
        public async Task<ActionResult> ApagarLicitacao(string codLicitacao)
        {
            try
            {
                await _licitacaoService.ApagarLicitacao(codLicitacao);
                return Ok("Licitacao deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
    }
}
