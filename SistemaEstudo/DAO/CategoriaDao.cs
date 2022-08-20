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
                    sw.WriteLine(categoria.Id + ";"+ categoria.Nome + ";" + categoria.Descricao + ";" + categoria.Status + ";" + categoria.DataCriacao + ";" + categoria.DataUltimaAlteracao);
                }
            }
            else
            {
                List<string> linhas = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt").ToList();
                linhas.Insert(linhas.Count, categoria.Id + ";" + categoria.Nome + ";" + categoria.Descricao + ";" + categoria.Status + ";" + categoria.DataCriacao + ";" + categoria.DataUltimaAlteracao);
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt", linhas);
            }
            return categoria;
        }
        public List<CategoriaModel> GetAll()
        {
            try
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
                    categoria.Descricao = dado[2];
                    categoria.Status = true;//dado[3, ""].ToString();
                    categoria.DataCriacao = Convert.ToDateTime(dado[4].ToString());
                    categoria.DataUltimaAlteracao = Convert.ToDateTime(dado[5].ToString());
                    // categoria.Status = Convert.ToBoolean(dados[5].ToString()); //ainda não existe no BD 20/08
                    retornoCategorias.Add(categoria);
                }
                return retornoCategorias;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public CategoriaModel GetCategoria(int id)
        {
            CategoriaModel retorno = new CategoriaModel();
            List<CategoriaModel> retornaCategoria = new List<CategoriaModel>();
            foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
            {
                string[] dado = line.Split(';');
                CategoriaModel categoria = new CategoriaModel();
                categoria.Id = Convert.ToInt32(dado[0]);
                categoria.Nome = dado[1];
                categoria.Descricao = dado[2];
                //teste
                //categoria.DataCriacao = Convert.ToDateTime(dado[3].ToString());
                //categoria.DataUltimaAlteracao = Convert.ToDateTime(dado[4].ToString());
                //categoria.Status = Convert.ToBoolean(dado[5]);
                //produto.DataCriacao = Convert.ToDateTime(dado[8].ToString());
                retornaCategoria.Add(categoria);
            }
            var teste = retornaCategoria.FirstOrDefault(cat => cat.Id == id);
            return teste;
        }
    }
}
