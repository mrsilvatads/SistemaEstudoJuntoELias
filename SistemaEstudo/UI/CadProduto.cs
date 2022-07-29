using SistemaEstudo.BLL;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaEstudo.Views
{
    public partial class CadProduto : Form
    {
        ProdutoModel produto;
        CategoriaModel categoria;//teste elias 03/07/2022
        public CadProduto()
        {
            InitializeComponent();
            produto = new ProdutoModel();
            CarregarTela();
            PreencherGrid();
            CarregarComboStatus(cmbStatus);
        }
        private void PreencherGrid()
        {
            var bll = new ProdutoBLL();
            var produtos = bll.RetornarTodosProdutos();
            dgvProduto.DataSource = null;
            dgvProduto.DataSource = produtos;
            dgvProduto.Refresh();
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarTela())
                MessageBox.Show("Favor preeencher campos obrigatorios!");
            Salvar();
            MessageBox.Show("Produto Cadastrado com sucesso!");
        }
        private bool ValidarTela()
        {
            if (txtId.Text == "" || txtNome.Text == "")
                return false;
            return true;
        }
        private void Salvar()
        {
            var bll = new ProdutoBLL();
            produto.Id = Convert.ToInt32(txtId.Text);
            produto.Nome = txtNome.Text;
            produto.Descricao = txtDescricao.Text;
            produto.Valor = Convert.ToInt32(txtValor.Text);
            produto.Unidade = (cmbUnidade.SelectedItem).ToString(); //produto.Unidade = Convert.ToDecimal(cmbUnidade.Text);
            produto.QuantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
            //produto.Categoria = (CategoriaModel)cmbCategoria.SelectedItem;// produto.Categoria = (CategoriaModel)txtQuantidadeEstoque.Text; // pessoa.Estado = ((EstadoModel)cmbEstado.SelectedItem).Id;
            produto.Categoria = (CategoriaModel)cmbCategoria.SelectedItem;//.Nome.ToString();
            produto.DataCriacao = DateTime.Now;
            produto.DataUltimaAlteracao = DateTime.Now;
            produto.Status = true;//implementar campo
            bll.Cadastrar(produto);
            PreencherGrid();
            LimparTela();
        }
        private void LimparTela()
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox)
                    (ctr as TextBox).Text = "";
                if (ctr is ComboBox)
                    (ctr as ComboBox).SelectedIndex = -1;
            }
        }
        private void CarregarTela()
        {
            CarregarComboCategoria();
        }
        private void CarregarComboCategoria()
        {
            var bll = new CategoriaBLL();
            var categorias = bll.RetornarCategorias();
            cmbCategoria.ValueMember = "id";
            cmbCategoria.DisplayMember = "nome";
            cmbCategoria.DataSource = categorias;
        }

        private void CarregarComboStatus(ComboBox cmbStatus)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (int enumValue in
            Enum.GetValues(typeof(ENUM.StatusProduto)))
            {
                dictionary.Add(Enum.GetName(typeof(ENUM.StatusProduto), enumValue), enumValue);
            }
            cmbStatus.DisplayMember = "Key";
            cmbStatus.ValueMember = "Value";
            cmbStatus.DataSource = new BindingSource(dictionary, null);
        }

        private void dgvProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Enabled = false;
            //var codProduto = int.Parse(dgvProduto.SelectedCells[0].Value.ToString());
            //var alterar = new For
            //txtNome.Text = produto.Nome;
            //MessageBox.Show(e.RowIndex.ToString());

            for (int i = 0; i < dgvProduto.Rows.Count; i++)
            {
                //bool selecionado = Convert.ToBoolean(dgvProduto.Rows[i].Cells[0].Value);
                //if (selecionado)
                //{
                txtId.Text = dgvProduto.Rows[i].Cells[0].Value.ToString();
                txtNome.Text = dgvProduto.Rows[i].Cells[0].Value.ToString();
                txtDescricao.Text = dgvProduto.Rows[i].Cells[1].Value.ToString();
                //}
            }
        }
    }
}
