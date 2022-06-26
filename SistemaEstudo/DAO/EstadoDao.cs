using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.DAO
{
    public class EstadoDao
    {
        public  List<EstadoModel> GetAll()
        {
            List<EstadoModel> retono = new List<EstadoModel>();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Estado.txt"))
            {
                foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Estado.txt"))
                {
                    string[] dado = line.Split(';');
                    EstadoModel estado = new EstadoModel();
                    estado.Id = Convert.ToInt32(dado[0]);
                    estado.Sigla = dado[1];
                    estado.Nome = dado[2];
                    retono.Add(estado);
                }
                
            }

            return retono;
        }
    }
}
