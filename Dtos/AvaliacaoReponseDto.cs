using Trabalho_Api.Models;

namespace Trabalho_Api.Dtos
{
    public class AvaliacaoResponseDto
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string NomeMusica { get; set; } = string.Empty;
        public double Nota { get; set; }
        public NivelMusical NivelAtingido { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}