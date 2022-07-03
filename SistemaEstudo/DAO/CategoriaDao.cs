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
        public CategoriaModel GetCategoria(int id)
        //public int GetCategoria(int id)
        {
            CategoriaModel retorno = new CategoriaModel();//teste elias

            List<CategoriaModel> retornaCategoria = new List<CategoriaModel>();
            foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
            {
                string[] dado = line.Split(';');
                CategoriaModel categoria = new CategoriaModel();
                categoria.Id = Convert.ToInt32(dado[0]);
                categoria.Nome = dado[1];
                categoria.Descricao = dado[2];
                retornaCategoria.Add(categoria);
            }
            //retornaCategoria = retornaCategoria.FirstOrDefault(cat => cat.Id == id);
            //retornoCategorias = retornoCategorias.Where(cat => cat.Id == 1).ToList();
            //where = linq   (cat => cat.id == Lambida)
            /*return retorno = retornaCategoria;///faltando converter*/
            //return retorno;//somente para não gerar erro na compilação
            var teste = retornaCategoria.FirstOrDefault(cat => cat.Id == id);
            return teste;
        }
    }
}
