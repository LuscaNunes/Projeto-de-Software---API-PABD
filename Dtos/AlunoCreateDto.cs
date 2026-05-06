using ApiGerenciamentoMatricula.Models;

namespace ApiGerenciamentoMatricula.Dtos
{
    public class AlunoCreateDto
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public NivelMusical NivelInicial { get; set; }
    }
}