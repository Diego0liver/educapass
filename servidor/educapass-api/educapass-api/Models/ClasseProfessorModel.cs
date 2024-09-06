using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace educapass_api.Models
{
    public class ClasseProfessorModel
    {
        [Key]
        public int Id { get; set; }
        public int Clase_id { get; set; }
        public int Professor_id { get; set; }
        public ClaseModel? Clase { get; set; }
        [JsonIgnore]
        public ProfessorModel? Professor { get; set; }
    }
}
