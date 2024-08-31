using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace educapass_api.Models
{
    public class AlunoCreateDto
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Inscricao { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public string? Telefone { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Responsavel { get; set; }
        public string? ContatoResponsavel { get; set; }
        public int? NumeroChamada { get; set; }
        public int? TotalFalta { get; set; }
        public int Escola_id { get; set; }
        public int? Clase_id { get; set; }
    }
}
