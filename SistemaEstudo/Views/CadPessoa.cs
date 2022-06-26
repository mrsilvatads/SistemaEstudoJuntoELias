using SistemaEstudo.BLL;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstudo.Views
{
    public partial class CadPessoa : Form
    {
        PessoaModel pessoa;
        public CadPessoa()
        {
            InitializeComponent();
            pessoa = new PessoaModel();
            PreencheComboBoxTipoPessoa();
            PreencheComboBoxEstado();
            PreencheGrid();
        }

        private void PreencheGrid()
        {
            var bll = new PessoaBLL();
            var pessoas = bll.RetornaPessoas();

            dgvPessoas.DataSource = null; //Limpa o grid;
            dgvPessoas.DataSource = pessoas;
            dgvPessoas.Refresh();
        }

        private void PreencheComboBoxEstado()
        {
            var bll = new EstadoBLL();
            var estados = bll.RetornaEstados();

            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "Sigla";
            cmbEstado.ValueMember = "id";
        }

        private void PreencheComboBoxTipoPessoa()
        {
            var tp = new TipoPessoa();
            var listatipos = tp.TipoPessoas();

            cmbTipoPessoa.DataSource = listatipos;
            cmbTipoPessoa.DisplayMember = "Descricao";
            cmbTipoPessoa.ValueMember = "id";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidaPessoa())
                MessageBox.Show("Favor informar os dados obrigatorios");
            else
            {
                Salvar();
            }

        }
        private bool ValidaPessoa()
        {
            if (txtId.Text == "")
                return false;
            if(txtNome.Text=="")
                return false;
            return true;
        }
        private void Salvar()
        {
            var bll = new PessoaBLL();
            pessoa.Id = Convert.ToInt32(txtId.Text);
            pessoa.Nome = txtNome.Text;
            pessoa.Sobrenome = txtSobrenome.Text;
            pessoa.Documento = txtDocumento.Text;
            pessoa.Telefone = txtTelefone.Text;
            pessoa.Endereco = txtEndere.Text;
            pessoa.DataCriacao = DateTime.Now;
            pessoa.DataUltimaAlteracao = DateTime.Now;
            pessoa.TipoPessoa = ((TipoPessoa)cmbTipoPessoa.SelectedItem).Id;
            pessoa.Estado = ((EstadoModel)cmbEstado.SelectedItem).Id;
            bll.CadastrarPessoa(pessoa);
            PreencheGrid();
        }
    }
}
