namespace Trabalho_Api.Models
{
    public class HistoricoNivel
    {
        public int Id_Historico { get; set; } 
        public required string Nivel {  get; set; } 
        public DateOnly DataMudanca { get; set; }
        public required string Motivo { get; set; }
        public int fk_id_aluno { get; set; }
        
    }
}
