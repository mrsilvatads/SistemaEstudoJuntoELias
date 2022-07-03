using SistemaEstudo.DAO;
using SistemaEstudo.Entidades;
using System.Collections.Generic;

namespace SistemaEstudo.BLL
{
    public class CategoriaBLL
    {
        public CategoriaModel Cadastrar(CategoriaModel categoria)
        {
            var retornaCategoria = new CategoriaModel();
            var dao = new CategoriaDao();
            retornaCategoria = dao.Add(categoria);
            return retornaCategoria;
        }
        public List<CategoriaModel> RetornarCategorias()
        {
            var dao = new CategoriaDao();
            return dao.GetAll();
        }

        //registro unico
        public CategoriaModel RegistroUnico(int idCategoria)
        {
            var categoria = new CategoriaModel();
            var dao = new CategoriaDao();
            categoria = dao.GetCategoria(idCategoria);
            return categoria;
        }
    }
}
