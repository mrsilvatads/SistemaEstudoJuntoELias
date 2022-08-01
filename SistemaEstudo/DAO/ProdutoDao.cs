using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.DAO
{
    public class ProdutoDao
    {
        public ProdutoModel Add(ProdutoModel produto)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Produto.txt"))
            {
                using (StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Produto.txt"))
                {
                    sw.WriteLine(produto.Id + ";" + produto.Nome + ";" + produto.Descricao + ";" + produto.Valor + ";" + produto.Unidade +";" + produto.QuantidadeEstoque +";" + produto.Categoria + ";" + produto.Status + ";" + produto.DataCriacao + ";" + produto.DataUltimaAlteracao);
                }
            }
            else
            {
                List<string> linhas = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Produto.txt").ToList();
                linhas.Insert(linhas.Count, produto.Id + ";" + produto.Nome + ";" + produto.Descricao + ";" + produto.Valor + ";" + produto.Unidade + ";" + produto.QuantidadeEstoque + ";" + produto.Categoria + ";" + produto.Status + ";" + produto.DataCriacao + ";" + produto.DataUltimaAlteracao);
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Produto.txt", linhas);
            }
            return produto;
        }
        public List<ProdutoModel> GetAll()
        {
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Produto.txt"))
                    return null;
                List<ProdutoModel> retorno = new List<ProdutoModel>();
                foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Produto.txt"))
                {
                    string[] dado = line.Split(';');
                    ProdutoModel produto = new ProdutoModel();
                    produto.Id = Convert.ToInt32(dado[0]);
                    produto.Nome = dado[1];
                    produto.Descricao = dado[2];
                    produto.Valor = Convert.ToInt32(dado[3]);
                    produto.Unidade = dado[4];
                    produto.QuantidadeEstoque = Convert.ToInt32(dado[5]);
                    ///produto.Status = boolean.Parse(dado[6].ToString());
                    //CategoriaModel categoria = new CategoriaModel();
                    //produto.Categoria.Id = Convert.ToInt32(dado[3]);
                    //produto.Status = Convert.ToString(dados[7]);//Convert.ToBoolean(dados[7]);//boolean.Parse(dado[7]);
                    //produto.Status = Boolean.Parse(dado[7]);//  Convert.ToBoolean(dado[3]);
                    /*
                     
                //bool checado = Convert.ToBoolean(dado[5].ToString());
                //categoria.Status = checado;//Convert.ToBoolean(dado[5].ToString);
                    */
                    produto.DataCriacao = Convert.ToDateTime(dado[8].ToString());
                    produto.DataUltimaAlteracao = Convert.ToDateTime(dado[9]);
                    retorno.Add(produto);
                }
                return retorno;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
    }
}
