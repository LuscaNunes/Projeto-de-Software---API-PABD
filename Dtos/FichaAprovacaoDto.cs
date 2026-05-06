namespace ApiGerenciamentoMatricula.Dtos
{
    public class FichaAprovacaoDto
    {
        public string NomeAluno { get; set; } = string.Empty;
        public string NivelAnterior { get; set; } = string.Empty;
        public string NovoNivel { get; set; } = string.Empty;
        public DateTime DataAprovacao { get; set; }
    }
}