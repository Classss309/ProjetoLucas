using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLucas.Models
{
    public class Filial
    {
        public int idFilial { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set;}
        public decimal Avaliacao { get; set; }

        public int IdEndereco { get; set; }
        public int Ativo { get; set; }

    }
    public class FilialColletion : List<Filial> { }

}
