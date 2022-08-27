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
                    categoria.Status = Convert.ToBoolean(dado[3]);// categoria.Status = Convert.ToBoolean(dados[5].ToString()); //ainda não existe no BD 20/08
                    categoria.DataCriacao = Convert.ToDateTime(dado[4].ToString());
                    categoria.DataUltimaAlteracao = Convert.ToDateTime(dado[5].ToString());
                    retornoCategorias.Add(categoria);
                }
                return retornoCategorias;
            }
            catch (Exception ex)
            {
                UTIL.ClsLogError.LogError(ex.Message + "GetAll()", ex);
                throw;
            }

        }
        public CategoriaModel GetCategoria(int id)
        {
            try
            {
                CategoriaModel retorno = new CategoriaModel();
                //List<CategoriaModel> retornaCategoria = new List<CategoriaModel>();
                foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Categoria.txt"))
                {
                    string[] dado = line.Split(';');
                    if (Convert.ToInt32(dado[0]) == id)
                    {
                        CategoriaModel categoria = new CategoriaModel();
                        categoria.Id = Convert.ToInt32(dado[0]);
                        categoria.Nome = dado[1];
                        categoria.Descricao = dado[2];
                        categoria.Status = Convert.ToBoolean(dado[3]);
                        //teste
                        //categoria.DataCriacao = Convert.ToDateTime(dado[3].ToString());
                        //categoria.DataUltimaAlteracao = Convert.ToDateTime(dado[4].ToString());
                        //categoria.Status = Convert.ToBoolean(dado[5]);
                        //produto.DataCriacao = Convert.ToDateTime(dado[8].ToString());
                        //retornaCategoria.Add(categoria);
                        break;
                    }
                }
                //var teste = retornaCategoria.FirstOrDefault(cat => cat.Id == id);
                return retorno;
            }
            catch (Exception ex)
            {
                UTIL.ClsLogError.LogError(ex.Message + "GetCategoria(int id)", ex);
                return null;
            }
        }
    }
}
