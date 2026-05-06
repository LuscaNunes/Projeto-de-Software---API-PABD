namespace ApiGerenciamentoMatricula.Dtos
{
    public class AvaliacaoCreateDto
    {
        public int AlunoId { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public bool Aprovado { get; set; }
        public string Observacoes { get; set; } = string.Empty;
    }
}