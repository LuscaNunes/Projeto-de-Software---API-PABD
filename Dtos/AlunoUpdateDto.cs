using Trabalho_Api.Models;

namespace Trabalho_Api.Dtos
{
    public class AlunoUpdateDto
    {
        public string? NomeCompleto { get; set; }
        public int? Idade { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public NivelMusical? NivelAtual { get; set; }
    }
}