using SistemaEstudo.BLL;
using SistemaEstudo.Entidades;
using System;
using System.Collections.Generic;
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
            CarregarComboStatus();
        }

        private void CarregarComboStatus()
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            foreach (int enumValue in
            Enum.GetValues(typeof(ENUM.StatusCategoria)))
            {
                dictionary.Add(Enum.GetName(typeof(ENUM.StatusCategoria), enumValue), enumValue);
            }
            cmbStatus.DisplayMember = "Key";
            cmbStatus.ValueMember = "Value";
            cmbStatus.DataSource = new BindingSource(dictionary, null);
        }

        private void PreencherGrid()
        {
            var bll = new CategoriaBLL();
            var categorias = bll.RetornarCategorias();
            dgvCategoria.DataSource = null;
            dgvCategoria.DataSource = categorias;
            dgvCategoria.Refresh();
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
            try
            {
                var bll = new CategoriaBLL();
                categoria.Id = Convert.ToInt32(txtId.Text);//Convert.ToInt32(txtId.Text);
                categoria.Nome = txtNome.Text;
                categoria.Descricao = txtDescricao.Text;
                categoria.DataCriacao = DateTime.Now;
                categoria.DataUltimaAlteracao = DateTime.Now;
                categoria.Status = Convert.ToBoolean(cmbStatus.SelectedIndex);
                bll.Cadastrar(categoria);
                PreencherGrid();
                LimparTela();
            }
            catch (Exception ex)
            {
                UTIL.ClsLogError.LogError(ex.Message + "Salvar()", ex);
                MessageBox.Show(ex.Message);
            }
        }
        private void LimparTela()
        {
            txtId.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
            cmbStatus.SelectedItem = -1;
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

        private void dgvCategorias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var teste = new CategoriaModel();
                if (dgvCategoria.SelectedRows.Count > 0)
                {
                    //forma providoria
                    txtNome.Text = dgvCategoria.SelectedRows[0].Cells[0].Value.ToString();
                    txtDescricao.Text = dgvCategoria.SelectedRows[0].Cells[1].Value.ToString();
                    cmbStatus.SelectedItem = dgvCategoria.SelectedRows[0].Cells[2].Value.ToString();//n]ao esta funcionando!!

                    //var bll = new CategoriaBLL();
                    //var categoria = bll.RegistroUnico();
                }
            }
            catch (Exception ex)
            {
                UTIL.ClsLogError.LogError(ex.Message + "dgvCategorias_CellDoubleClick()", ex);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
