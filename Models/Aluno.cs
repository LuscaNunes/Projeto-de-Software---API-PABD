namespace Trabalho_Api.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public int Idade { get; set; }
        public string Cpf { get; set; } = string.Empty;
        public NivelMusical NivelInicial { get; set; }
        public DateTime DataMatricula { get; set; }

        public ICollection<Avaliacao>? Avaliacoes { get; set; }
    }
}