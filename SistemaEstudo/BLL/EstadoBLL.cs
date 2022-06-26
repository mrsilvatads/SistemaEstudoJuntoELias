using SistemaEstudo.DAO;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.BLL
{
    public class EstadoBLL
    {
        public List<EstadoModel> RetornaEstados()
        {
            var dao = new EstadoDao();
            return dao.GetAll();
        }
    }
}
