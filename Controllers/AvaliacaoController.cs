
using Microsoft.AspNetCore.Mvc;
using Trabalho_Api.Dtos;        
using Trabalho_Api.Exceptions;   
using Trabalho_Api.Services;      

namespace Trabalho_Api.Controllers  
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