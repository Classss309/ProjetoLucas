using System.Collections.Generic;

namespace ProjetoLucas.Models
{
    public class Filial
    {
        public int idFilial { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public decimal Avaliacao { get; set; }
        public int IdEndereco { get; set; }
        public bool Ativo { get; set; }
    }

    public class FilialColletion : List<Filial> { }
}
