
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho_Api.DataContexts;
using Trabalho_Api.Dtos;
using Trabalho_Api.Exceptions;
using Trabalho_Api.Models;

namespace Trabalho_Api.Services
{
    public class AvaliacaoService
    {
        private readonly AppDbContext _context;

        public AvaliacaoService(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<AvaliacaoResponseDto> RegistrarAvaliacao(AvaliacaoCreateDto avaliacaoDto)
        {
            
            var aluno = await _context.Alunos.FindAsync(avaliacaoDto.AlunoId);
            if (aluno == null)
                throw new ErrorServiceException("Aluno não encontrado",
                    controller => controller.NotFound(new { message = "Aluno não encontrado" }));

            
            if (avaliacaoDto.Nota < 0 || avaliacaoDto.Nota > 10)
                throw new ErrorServiceException("Nota inválida. A nota deve estar entre 0 e 10",
                    controller => controller.BadRequest(new { message = "Nota inválida. A nota deve estar entre 0 e 10" }));

            var avaliacao = new Avaliacao
            {
                AlunoId = avaliacaoDto.AlunoId,
                NomeMusica = avaliacaoDto.NomeMusica,
                Nota = avaliacaoDto.Nota,
                NivelAtingido = avaliacaoDto.NivelAtingido,
                DataAvaliacao = DateTime.Now
            };

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();

            string status = avaliacaoDto.Nota >= 7 ? "Aprovado" : "Reprovado";

            return new AvaliacaoResponseDto
            {
                Id = avaliacao.Id,
                AlunoId = avaliacao.AlunoId,
                NomeAluno = aluno.NomeCompleto,
                NomeMusica = avaliacao.NomeMusica,
                Nota = avaliacao.Nota,
                NivelAtingido = avaliacao.NivelAtingido,
                DataAvaliacao = avaliacao.DataAvaliacao,
                Status = status
            };
        }

        // UC07 - Gerar ficha de aprovação
        public async Task<FichaAprovacaoDto> GerarFichaAprovacao(int avaliacaoId)
        {
            // Buscar a avaliação
            var avaliacao = await _context.Avaliacoes
                .Include(a => a.Aluno)
                .FirstOrDefaultAsync(a => a.Id == avaliacaoId);

            if (avaliacao == null)
                throw new ErrorServiceException("Avaliação não encontrada",
                    controller => controller.NotFound(new { message = "Avaliação não encontrada" }));

            // Determinar se foi aprovado (nota >= 7)
            bool aprovado = avaliacao.Nota >= 7;
            string mensagem = aprovado
                ? $"Parabéns! Você foi aprovado com nota {avaliacao.Nota} no nível {avaliacao.NivelAtingido}"
                : $"Infelizmente você não foi aprovado. Sua nota foi {avaliacao.Nota}. A nota mínima é 7.";

            return new FichaAprovacaoDto
            {
                AvaliacaoId = avaliacao.Id,
                AlunoId = avaliacao.AlunoId,
                NomeAluno = avaliacao.Aluno?.NomeCompleto ?? "Aluno não encontrado",
                NomeMusica = avaliacao.NomeMusica,
                Nota = avaliacao.Nota,
                Aprovado = aprovado,
                Mensagem = mensagem,
                DataAprovacao = DateTime.Now
            };
        }

        // Listar avaliações de um aluno
        public async Task<List<AvaliacaoResponseDto>> FindByAlunoId(int alunoId)
        {
            // Verificar se o aluno existe
            var aluno = await _context.Alunos.FindAsync(alunoId);
            if (aluno == null)
                throw new ErrorServiceException("Aluno não encontrado",
                    controller => controller.NotFound(new { message = "Aluno não encontrado" }));

            // Buscar todas as avaliações do aluno
            var avaliacoes = await _context.Avaliacoes
                .Where(a => a.AlunoId == alunoId)
                .OrderByDescending(a => a.DataAvaliacao)
                .ToListAsync();

            return avaliacoes.Select(a => new AvaliacaoResponseDto
            {
                Id = a.Id,
                AlunoId = a.AlunoId,
                NomeAluno = aluno.NomeCompleto,
                NomeMusica = a.NomeMusica,
                Nota = a.Nota,
                NivelAtingido = a.NivelAtingido,
                DataAvaliacao = a.DataAvaliacao,
                Status = a.Nota >= 7 ? "Aprovado" : "Reprovado"
            }).ToList();
        }
    }
}