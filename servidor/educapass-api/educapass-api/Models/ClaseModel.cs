using System.ComponentModel.DataAnnotations;

namespace educapass_api.Models
{
    public class ClaseModel
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public int Escola_id { get; set; }
        public EscolaModel? Escola { get; set; }
    }
}
