using System.ComponentModel.DataAnnotations;

namespace Trabalho_Api.Dtos
{
    public class AlunoDto
    {
        [Required]
        public required string Nome { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        [Required]
        public int CPF { get; set; }
        [Required]
        public required string NivelAtual { get; set; }
    }
}
