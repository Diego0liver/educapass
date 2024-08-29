﻿using System.ComponentModel.DataAnnotations;

namespace educapass_api.Models
{
    public class EscolaModel
    {
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Cep { get; set; }
        public string? Logo { get; set; }
        //public int? Plano_id { get; set; }
        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }
    }
}
