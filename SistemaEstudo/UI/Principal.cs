using SistemaEstudo.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstudo
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            CadPessoa tela = new CadPessoa();
            tela.ShowDialog();
        }
        private void btnProduto_Click(object sender, EventArgs e)
        {

        }
        private void btnCategoria_Click(object sender, EventArgs e)
        {
            CadCategoria telaCategoria = new CadCategoria();
            telaCategoria.ShowDialog();
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblVersao.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
