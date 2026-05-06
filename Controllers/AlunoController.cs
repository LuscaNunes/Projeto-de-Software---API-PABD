using ApiGerenciamentoMatricula.Dtos;
using ApiGerenciamentoMatricula.Exceptions;
using ApiGerenciamentoMatricula.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiGerenciamentoMatricula.Controllers
{
    [Route("/alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly AlunoService _service;

        public AlunoController(AlunoService service)
        {
            _service = service;
        }

        // UC04 - Consultar alunos (todos ou por nome/CPF)
        [HttpGet()]
        public async Task<IActionResult> FindAll([FromQuery] string? nome, [FromQuery] string? cpf)
        {
            try
            {
                var alunos = await _service.FindAll(nome, cpf);
                return Ok(alunos);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        // UC04 - Consultar aluno por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var aluno = await _service.FindById(id);
                return Ok(aluno);
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

        // UC01 - Cadastrar aluno
        [HttpPost()]
        public async Task<IActionResult> Create([FromBody] AlunoCreateDto novoAluno)
        {
            try
            {
                var aluno = await _service.Create(novoAluno);
                return Created($"/alunos/{aluno.Id}", aluno);
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

        // UC02 - Atualizar dados do aluno
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AlunoUpdateDto alunoDto)
        {
            try
            {
                var aluno = await _service.Update(id, alunoDto);
                return Ok(aluno);
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

        // UC03 - Remover aluno
        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            try
            {
                await _service.Remove(id);
                return NoContent();
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

        // UC08 - Consultar histórico do aluno
        [HttpGet("{id}/historico")]
        public async Task<IActionResult> GetHistorico(int id)
        {
            try
            {
                var historico = await _service.GetHistorico(id);
                return Ok(historico);
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
    }
}