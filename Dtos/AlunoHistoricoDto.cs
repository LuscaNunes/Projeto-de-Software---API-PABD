namespace Trabalho_Api.Dtos
{
    public class AlunoHistoricoDto
    {
        public int Id { get; set; }
        public string NomeMusica { get; set; } = string.Empty;
        public double Nota { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}