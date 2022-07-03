using SistemaEstudo.BLL;
using SistemaEstudo.Entidades;
using System;
using System.Windows.Forms;

namespace SistemaEstudo.Views
{
    public partial class CadCategoria : Form
    {
        CategoriaModel categoria;
        public CadCategoria()
        {
            InitializeComponent();
            categoria = new CategoriaModel();
            PreencherGrid();
        }

        private void PreencherGrid()
        {
            var bll = new CategoriaBLL();
            var categorias = bll.RetornarCategorias();
            dgvCategorias.DataSource = null; //Limpa o grid antes de inserir dados;
            dgvCategorias.DataSource = categorias;
            dgvCategorias.Refresh();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (!ValidarTela())
                MessageBox.Show("Favor peencher campos obrigatorios!");
            Salvar();
            MessageBox.Show("Categoria Cadastrada com sucesso!");
        }
        private void Salvar()
        {
            var bll = new CategoriaBLL();
            categoria.Id = Convert.ToInt32(txtId.Text);
            categoria.Nome = txtNome.Text;
            categoria.Descricao = txtDescricao.Text;
            categoria.DataCriacao = DateTime.Now;
            categoria.DataUltimaAlteracao = DateTime.Now;
            bll.Cadastrar(categoria);
            PreencherGrid();
            LimparTela();
        }
        private void LimparTela()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
        }
        private bool ValidarTela()
        {
            return true;
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            txtNome.SelectionStart = txtNome.Text.Length;
            txtNome.Text = txtNome.Text.ToUpper();
        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            txtDescricao.SelectionStart = txtDescricao.Text.Length;
            txtDescricao.Text = txtDescricao.Text.ToUpper();
        }

        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtId.Text == null)
            {
                MessageBox.Show("Favor informar id para pesquisa de uma Categoria!");
                return;
            }
            int categoriaId = Convert.ToInt32(txtId.Text);
            var bll = new CategoriaBLL();
            var retornoCategoria = bll.RegistroUnico(categoriaId);
            if (retornoCategoria != null && categoriaId > 0 )
                PreencherCampos(retornoCategoria);
            else
                MessageBox.Show("nenhuma Categoria foi encontrada!");
        }
        private void PreencherCampos(CategoriaModel categoria)
        {
            txtId.Text = Convert.ToInt32(categoria.Id).ToString();
            txtNome.Text = categoria.Nome;
            txtDescricao.Text = categoria.Descricao;
        }
    }
}
