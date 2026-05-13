using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_Api.DataContexts;
using Trabalho_Api.Dtos;
using Trabalho_Api.Exceptions;
using Trabalho_Api.Models;

namespace Trabalho_Api.Services  // ← Mudar namespace
{
    public class AlunoService
    {
        private readonly AppDbContext _context;

        public AlunoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<AlunoResponseDto>> FindAll(string? nome, string? cpf)
        {
            var query = _context.Alunos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
                query = query.Where(a => a.NomeCompleto.Contains(nome));

            if (!string.IsNullOrEmpty(cpf))
                query = query.Where(a => a.Cpf == cpf);

            var alunos = await query.ToListAsync();

            return alunos.Select(a => new AlunoResponseDto
            {
                Id = a.Id,
                NomeCompleto = a.NomeCompleto,
                Idade = a.Idade,
                Cpf = a.Cpf,
                NivelInicial = a.NivelInicial,
                DataMatricula = a.DataMatricula
            }).ToList();
        }

        public async Task<AlunoResponseDto> FindById(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                throw new ErrorServiceException("Aluno não encontrado",
                    controller => controller.NotFound(new { message = "Aluno não encontrado" }));

            return new AlunoResponseDto
            {
                Id = aluno.Id,
                NomeCompleto = aluno.NomeCompleto,
                Idade = aluno.Idade,
                Cpf = aluno.Cpf,
                NivelInicial = aluno.NivelInicial,
                DataMatricula = aluno.DataMatricula
            };
        }

        public async Task<AlunoResponseDto> Create(AlunoCreateDto novoAluno)
        {
            var cpfExiste = await _context.Alunos.AnyAsync(a => a.Cpf == novoAluno.Cpf);
            if (cpfExiste)
                throw new ErrorServiceException("CPF já cadastrado",
                    controller => controller.BadRequest(new { message = "CPF já cadastrado" }));

            var aluno = new Aluno
            {
                NomeCompleto = novoAluno.NomeCompleto,
                Idade = novoAluno.Idade,
                Cpf = novoAluno.Cpf,
                NivelInicial = novoAluno.NivelInicial,
                DataMatricula = DateTime.Now
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return new AlunoResponseDto
            {
                Id = aluno.Id,
                NomeCompleto = aluno.NomeCompleto,
                Idade = aluno.Idade,
                Cpf = aluno.Cpf,
                NivelInicial = aluno.NivelInicial,
                DataMatricula = aluno.DataMatricula
            };
        }

        public async Task<AlunoResponseDto> Update(int id, AlunoUpdateDto alunoDto)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                throw new ErrorServiceException("Aluno não encontrado",
                    controller => controller.NotFound(new { message = "Aluno não encontrado" }));

            if (alunoDto.NomeCompleto != null)
                aluno.NomeCompleto = alunoDto.NomeCompleto;

            if (alunoDto.Idade.HasValue)
                aluno.Idade = alunoDto.Idade.Value;

            if (alunoDto.NivelAtual.HasValue)
                aluno.NivelInicial = alunoDto.NivelAtual.Value;

            await _context.SaveChangesAsync();

            return new AlunoResponseDto
            {
                Id = aluno.Id,
                NomeCompleto = aluno.NomeCompleto,
                Idade = aluno.Idade,
                Cpf = aluno.Cpf,
                NivelInicial = aluno.NivelInicial,
                DataMatricula = aluno.DataMatricula
            };
        }

        public async Task Remove(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);

            if (aluno == null)
                throw new ErrorServiceException("Aluno não encontrado",
                    controller => controller.NotFound(new { message = "Aluno não encontrado" }));

            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task<List<AlunoHistoricoDto>> GetHistorico(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                throw new ErrorServiceException("Aluno não encontrado",
                    controller => controller.NotFound(new { message = "Aluno não encontrado" }));

            var avaliacoes = await _context.Avaliacoes
                .Where(a => a.AlunoId == id)
                .OrderByDescending(a => a.DataAvaliacao)
                .ToListAsync();

            return avaliacoes.Select(a => new AlunoHistoricoDto
            {
                Id = a.Id,
                NomeMusica = a.NomeMusica,
                Nota = a.Nota,
                DataAvaliacao = a.DataAvaliacao,
                Status = a.Nota >= 7 ? "Aprovado" : "Reprovado"
            }).ToList();
        }
    }
}