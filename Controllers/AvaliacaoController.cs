
using Microsoft.AspNetCore.Mvc;
using Trabalho_Api.Dtos;        // ← Mudar
using Trabalho_Api.Exceptions;   // ← Mudar
using Trabalho_Api.Services;      // ← Mudar

namespace Trabalho_Api.Controllers  // ← Mudar namespace
{
    [Route("/avaliacoes")]
    [ApiController]
    public class AvaliacaoController : ControllerBase
    {
        private readonly AvaliacaoService _service;

        public AvaliacaoController(AvaliacaoService service)
        {
            _service = service;
        }

        // UC05 - Registrar avaliação
        [HttpPost()]
        public async Task<IActionResult> RegistrarAvaliacao([FromBody] AvaliacaoCreateDto avaliacaoDto)
        {
            try
            {
                var resultado = await _service.RegistrarAvaliacao(avaliacaoDto);
                return Created("", resultado);
            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // UC07 - Gerar ficha de aprovação
        [HttpGet("{avaliacaoId}/ficha-aprovacao")]
        public async Task<IActionResult> GerarFichaAprovacao(int avaliacaoId)
        {
            try
            {
                var ficha = await _service.GerarFichaAprovacao(avaliacaoId);
                return Ok(ficha);
            }
            catch (ErrorServiceException e)
            {
                return e.ToActionResult(this);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // Listar avaliações de um aluno
        [HttpGet("aluno/{alunoId}")]
        public async Task<IActionResult> FindByAlunoId(int alunoId)
        {
            try
            {
                var avaliacoes = await _service.FindByAlunoId(alunoId);
                return Ok(avaliacoes);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}