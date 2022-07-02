using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.DAO
{
    public class CategoriaDao
    {
        public CategoriaModel Add(CategoriaModel categoria)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
            {
                using (StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
                {
                    sw.WriteLine(categoria.Id + ";"+ categoria.Nome + ";" + categoria.Descricao + ";" + categoria.DataCriacao + ";" + categoria.DataUltimaAlteracao);
                    //sw.WriteLine(pessoa.Id + ";" + pessoa.Nome + ";" + pessoa.Sobrenome + ";" + pessoa.Documento + ";" + pessoa.Telefone + ";" + pessoa.Endereco + ";" + pessoa.Estado + ";" + pessoa.TipoPessoa + ";" + pessoa.DataCriacao + ";" + pessoa.DataUltimaAlteracao);
                }
            }
            else
            {
                List<string> linhas = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt").ToList();
                linhas.Insert(linhas.Count, categoria.Id + ";" + categoria.Nome + ";" + categoria.Descricao + ";" + categoria.DataCriacao + ";" + categoria.DataUltimaAlteracao);
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt", linhas);
            }
            return categoria;
        }

        public List<CategoriaModel> GetAll()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
                return null;
            List<CategoriaModel> retornoCategorias = new List<CategoriaModel>();
            foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
            {
                string[] dado = line.Split(';');
                CategoriaModel categoria = new CategoriaModel();
                categoria.Id = Convert.ToInt32(dado[0]);
                categoria.Nome = dado[1];
                categoria.Descricao= dado[2];
                retornoCategorias.Add(categoria);
            }
            return retornoCategorias;
        }
    }
}
