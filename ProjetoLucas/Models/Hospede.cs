using System;
using System.Collections.Generic;

namespace ProjetoLucas.Models
{
    public class Hospede
    {
        public int IdHospede { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Nacionalidade { get; set; }
        public bool Ativo { get; set; }
    }

    public class HospedeCollection : List<Hospede> { }
}
