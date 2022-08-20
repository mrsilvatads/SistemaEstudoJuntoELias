using SistemaEstudo.DAO;
using SistemaEstudo.Entidades;
using System.Collections.Generic;

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

        public ProdutoModel RetornarProduto(int idProduto)
        {//teste elias 20/08
            var retornaProduto = new ProdutoModel();
            var dao = new ProdutoDao();
            retornaProduto = dao.GetProdutoId(idProduto);
            return retornaProduto;
        }

        
    }
}
