namespace Trabalho_Api.Models
{
    public class Aluno
    {
        public int Id_Aluno { get; set; } // alterar para chave primária
        public required string Nome { get; set; }
        public DateOnly DataNascimento { get; set; }
        public DateOnly DataCadastro { get; set; } // data que o aluno ingressou
        public int CPF { get; set; }
        public required string NivelAtual { get; set; }
        // Automaticamente o usuário adquiri o nível de INICIANTE. Atribuir de forma estática
        // o aluno passará por uma avaliação de capacidade para alterar o seu nível,
        // independentemente se ele já veio de outra orquestra. Requisito de confiabilidade do Professor
    }
}
