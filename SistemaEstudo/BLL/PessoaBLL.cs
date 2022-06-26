using SistemaEstudo.DAO;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.BLL
{
    public class PessoaBLL
    {
        public PessoaModel CadastrarPessoa(PessoaModel pessoa)
        {
            var retornoPessoal = new PessoaModel();
            var dao = new PessoaDao();
            retornoPessoal = dao.Add(pessoa);
            return retornoPessoal;
        }

        public List<PessoaModel> RetornaPessoas()
        {
            var dao = new PessoaDao();            
            return dao.GetAll();
        }
    }
}
