using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class PreguntaGenerarCompra : Form
    {
        VistaPreviaCompra vpc;
        public bool usuEstSeg = false;
        public PreguntaGenerarCompra(DataGridView dgv, List<DatosProductoPedido> prodAjuAut)
        {
            InitializeComponent();

            vpc = new VistaPreviaCompra(null, null, null, false);
            vpc.Show();
        }

        private void si_Click(object sender, EventArgs e)
        {
            usuEstSeg = true;
            vpc.Close();
            Close();
        }

        private void no_Click(object sender, EventArgs e)
        {
            usuEstSeg = false;
            vpc.Close();
            Close();
        }

        private void PreguntaGenerarCompra_Load(object sender, EventArgs e)
        {
            Location = new Point(0, Location.Y);
        }
    }
}
