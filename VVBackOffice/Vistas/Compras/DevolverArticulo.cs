using System;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class DevolverArticulo : Form
    {
        DataGridView dgv;
        public bool usuarioContinuo = false;

        public DevolverArticulo(DataGridView dgv)
        {
            InitializeComponent();
            this.dgv = dgv;
        }

        private void DevolverArticulo_Load(object sender, EventArgs e)
        {
            tbCan.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                SelectNextControl((Control)sender, true, true, true, true);
        }

        private void devProd_Click(object sender, EventArgs e)
        {
            usuarioContinuo = true;
            dgv.SelectedRows[0].Cells[15].Tag = decimal.Parse(tbCan.Text);
            dgv.SelectedRows[0].Cells[15].Value = decimal.Parse(tbCan.Text);
            Close();
        }
    }
}
