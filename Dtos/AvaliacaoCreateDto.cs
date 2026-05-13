using Trabalho_Api.Models;
namespace Trabalho_Api.Dtos
{
    public class AvaliacaoCreateDto
    {
        public int AlunoId { get; set; }
        public string NomeMusica { get; set; } = string.Empty;
        public double Nota { get; set; }
        public NivelMusical NivelAtingido { get; set; }
    }
}