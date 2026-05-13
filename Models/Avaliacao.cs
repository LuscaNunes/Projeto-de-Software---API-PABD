namespace Trabalho_Api.Models  // ← Deve ser Trabalho_Api
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string NomeMusica { get; set; } = string.Empty;
        public double Nota { get; set; }
        public NivelMusical NivelAtingido { get; set; }
        public DateTime DataAvaliacao { get; set; }

        // Propriedade de navegação
        public Aluno? Aluno { get; set; }
    }
}