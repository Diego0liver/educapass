using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace educapass_api.Models
{
    public class MateriaModel
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public string? Descricao { get; set; }
        public int Escola_id { get; set; }
        [JsonIgnore]
        public EscolaModel? Escola { get; set; }
        [JsonIgnore]
        public ICollection<ProfessorMateriaModel>? ProfessorMateria { get; set; }
    }
}
