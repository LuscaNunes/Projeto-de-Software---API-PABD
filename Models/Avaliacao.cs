namespace Trabalho_Api.Models 
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string NomeMusica { get; set; } = string.Empty;
        public double Nota { get; set; }
        public NivelMusical NivelAtingido { get; set; }
        public DateTime DataAvaliacao { get; set; }

        public Aluno? Aluno { get; set; }
    }
}