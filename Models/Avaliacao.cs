using Trabalho_Api.Models;

namespace ApiGerenciamentoMatricula.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public DateTime DataAvaliacao { get; set; }
        public bool Aprovado { get; set; }
        public string Observacoes { get; set; } = string.Empty;
        public NivelMusical NivelAnterior { get; set; }
        public NivelMusical? NovoNivel { get; set; }

        public Aluno? Aluno { get; set; }
    }
}