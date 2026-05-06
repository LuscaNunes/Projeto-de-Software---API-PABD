namespace Trabalho_Api.Dtos
{
    public class HistoricoNivelDto
    {
        public required string Nivel { get; set; }
        public DateTime DataMudanca { get; set; }
        public required string Motivo { get; set; }
        //verificar a passagem de chave estrangeira
    }
}
