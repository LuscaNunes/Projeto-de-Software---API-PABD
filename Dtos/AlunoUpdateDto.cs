using ApiGerenciamentoMatricula.Models;

namespace ApiGerenciamentoMatricula.Dtos
{
    public class AlunoUpdateDto
    {
        public string? NomeCompleto { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }
        public NivelMusical? NivelAtual { get; set; }
    }
}