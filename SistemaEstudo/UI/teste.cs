using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEstudo.UI
{
    public partial class teste : Form
    {
        public teste()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        private void teste_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("First name", typeof(string));
            table.Columns.Add("Last name", typeof(string));

            dgvTeste.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeste.ReadOnly = true;
            dgvTeste.DataSource = table;
        }
    }
}
