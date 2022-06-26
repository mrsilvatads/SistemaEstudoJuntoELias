using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.Entidades
{
    public class PessoaModel : Base
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento{ get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public int Estado { get; set; }
        public int TipoPessoa { get; set; }


    }
}
