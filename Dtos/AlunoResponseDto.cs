using Trabalho_Api.Models;

namespace Trabalho_Api.Dtos
{
    public class AlunoResponseDto
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public NivelMusical NivelInicial { get; set; }
        public DateTime DataMatricula { get; set; }
    }
}