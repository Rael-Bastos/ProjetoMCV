﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoIHM.Dtos
{
    public class AlunosDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public bool Ativo { get; set; }
    
    }
}