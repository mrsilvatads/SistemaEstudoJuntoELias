using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEstudo.Entidades
{
    class TipoPessoa : Base
    {
        public string Descricao { get; set; }

        List<TipoPessoa> tipoPessoa = new List<TipoPessoa>();
        public List<TipoPessoa> TipoPessoas()
        {
            TipoPessoa tipo = new TipoPessoa();
            tipo.Id = 1;
            tipo.Descricao = "Pessoa Fisica";
            tipoPessoa.Add(tipo);
            TipoPessoa tipo1 = new TipoPessoa();
            tipo1.Id = 2;
            tipo1.Descricao = "Pessoa juridica";
            tipoPessoa.Add(tipo1);
            return tipoPessoa;
        }
    }
}
