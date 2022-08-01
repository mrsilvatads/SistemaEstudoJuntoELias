using SistemaEstudo.BLL;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SistemaEstudo.Views
{
    public partial class CadProduto : Form
    {
        int contexto = 0;

        ProdutoModel produto;
        CategoriaModel categoria;//teste elias 03/07/2022
        List<ProdutoModel> listaProduto ;


        //List<ModelAluno> alunos;
        //ModelAluno aluno = new ModelAluno();
        List<ProdutoModel> produtos2;
        ProdutoModel produto2 = new ProdutoModel();

        #region Construtor
        public CadProduto()
        {
            InitializeComponent();
            produto = new ProdutoModel();
            CarregarTela();
            PreencherGrid();
            CarregarComboStatus(cmbStatus);
        }

        //public CadCategoria(ProdutoModel produtoAtual)
        //{
        //    produto = produtoAtual;
        //}

        #endregion

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
            try
            {
                if (btnSalvar.Text == "Salvar")
                {
                    var bll = new ProdutoBLL();
                    produto.Id = Convert.ToInt32(txtId.Text);
                    produto.Nome = txtNome.Text;
                    produto.Descricao = txtDescricao.Text;
                    produto.Valor = Convert.ToInt32(txtValor.Text);
                    produto.Unidade = (cmbUnidade.SelectedItem).ToString();
                    produto.QuantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
                    //produto.Categoria = (CategoriaModel)cmbCategoria.SelectedItem;// produto.Categoria = (CategoriaModel)txtQuantidadeEstoque.Text; // pessoa.Estado = ((EstadoModel)cmbEstado.SelectedItem).Id;
                    produto.Categoria = (CategoriaModel)cmbCategoria.SelectedItem;//.Nome.ToString();
                    produto.DataCriacao = DateTime.Now;
                    produto.DataUltimaAlteracao = DateTime.Now;
                    // produto.Status = true;//implementar campo
                    produto.Status = Convert.ToBoolean(cmbStatus.SelectedIndex);
                    bll.Cadastrar(produto);
                    PreencherGrid();
                    LimparTela();

                    /*
                   pessoa.TipoPessoa = ((TipoPessoa)cmbTipoPessoa.SelectedItem).Id; desse jeito da erro!
                   pessoa.Estado = ((EstadoModel)cmbEstado.SelectedItem).Id;    
                   */
                }
                else
                {
                    MessageBox.Show("Alterar");
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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
            try
            {
                if (dgvProduto.SelectedRows.Count > 0)
                {

                    listaProduto = new List<ProdutoModel>();
                    produto = new ProdutoModel();

                    txtId.Enabled = false;
                    btnSalvar.Text = "Alterar";

                    txtId.Text = dgvProduto.SelectedRows[0].Cells[7].Value.ToString();
                    txtNome.Text =  dgvProduto.SelectedRows[0].Cells[0].Value.ToString();
                    txtDescricao.Text = dgvProduto.SelectedRows[0].Cells[1].Value.ToString();
                    txtValor.Text = dgvProduto.SelectedRows[0].Cells[2].Value.ToString();
                    txtQuantidadeEstoque.Text = dgvProduto.SelectedRows[0].Cells[3].Value.ToString();
                    //cmbUnidade.SelectedItem = Convert.ToInt32(dgvProduto.SelectedRows[0].Cells[3].ToString());//cmbUnidade.SelectedText = dgvProduto.SelectedRows[0].Cells[3].ToString();
                    //categoria = new CategoriaModel();
                    //categoria = 
                    //CategoriaBLL cat = new CategoriaBLL();
                    //cmbCategoria.SelectedIndex = cat.RegistroUnico(categoria.Id); 

                }
                ///produto = produtos2[dgvProduto.SelectedRows[0].Index];
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<CategoriaModel> ListarCategoriasCombo()
        {
            List<CategoriaModel> lista = new List<CategoriaModel>();
            return lista;
        }

    }
}
