using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrabalhoIHM.Models
{
    [Table ("Alunos")]
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        public string Nome{ get; set; }

        [Required]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        public string Telefone { get; set; }
        
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Data de Nascimento")]
        public DateTime DataDeNascimento { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}