using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.DAO
{
    public class PessoaDao
    {
        public PessoaModel Add(PessoaModel pessoa)
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Pessoa.txt"))
            {
                using (StreamWriter sw = File.CreateText(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Pessoa.txt"))
                {
                    sw.WriteLine(pessoa.Id + ";" + pessoa.Nome + ";" + pessoa.Sobrenome + ";" + pessoa.Documento + ";" +pessoa.Telefone+ ";" + pessoa.Endereco + ";" + pessoa.Estado + ";" +pessoa.TipoPessoa + ";" +pessoa.DataCriacao + ";" +pessoa.DataUltimaAlteracao);
                }
            }
            else
            {
                List<string> linhas = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Pessoa.txt").ToList(); // Passo 1
                linhas.Insert(linhas.Count,pessoa.Id + ";" + pessoa.Nome + ";" + pessoa.Sobrenome + ";" + pessoa.Documento + ";" + pessoa.Telefone + ";" + pessoa.Endereco + ";" + pessoa.Estado + ";" + pessoa.TipoPessoa + ";" + pessoa.DataCriacao + ";" + pessoa.DataUltimaAlteracao); // Passo 2
                File.WriteAllLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Pessoa.txt", linhas); // Passo 3
            }
            return pessoa;
        }
        public List<PessoaModel> GetAll()
        {
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Pessoa.txt"))
               return null;
            List<PessoaModel> retorno = new List<PessoaModel>();          
            
            foreach (string line in File.ReadLines(AppDomain.CurrentDomain.BaseDirectory.ToString() + @"\bd\Pessoa.txt"))
            {
                string[] dado = line.Split(';');
                PessoaModel pessoa = new PessoaModel();
                pessoa.Id = Convert.ToInt32(dado[0]);
                pessoa.Nome = dado[1];
                pessoa.Sobrenome = dado[2];
                pessoa.Documento = dado[3];
                pessoa.Telefone = dado[4];
                pessoa.Endereco = dado[5];
                pessoa.Estado = Convert.ToInt32(dado[6]);
                pessoa.TipoPessoa = Convert.ToInt32(dado[7]);
                retorno.Add(pessoa);
            }          
            return retorno;
        }
    }
}
