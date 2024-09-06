using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace educapass_api.Models
{
    public class ProfessorMateriaModel
    {
        [Key]
        public int Id { get; set; }
        public int Materia_id { get; set; }
        public int Professor_id { get; set; }
        public MateriaModel? Materia { get; set; }
        [JsonIgnore]
        public ProfessorModel? Professor { get; set; }
    }
}
