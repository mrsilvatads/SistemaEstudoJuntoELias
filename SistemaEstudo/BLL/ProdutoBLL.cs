using SistemaEstudo.DAO;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.BLL
{
    public class ProdutoBLL
    {
        public ProdutoModel Cadastrar(ProdutoModel produto)
        {
            var retornaProduto = new ProdutoModel();
            var dao = new ProdutoDao();
            retornaProduto = dao.Add(produto);
            return retornaProduto;
        }

        public List<ProdutoModel> RetornarTodosProdutos()
        {
            var dao = new ProdutoDao();
            return dao.GetAll();
        }
    }
}
