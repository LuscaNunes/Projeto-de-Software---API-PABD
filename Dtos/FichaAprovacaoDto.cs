namespace Trabalho_Api.Dtos
{
    public class FichaAprovacaoDto
    {
        public int AvaliacaoId { get; set; }
        public int AlunoId { get; set; }
        public string NomeAluno { get; set; } = string.Empty;
        public string NomeMusica { get; set; } = string.Empty;
        public double Nota { get; set; }
        public bool Aprovado { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public DateTime DataAprovacao { get; set; }
    }
}