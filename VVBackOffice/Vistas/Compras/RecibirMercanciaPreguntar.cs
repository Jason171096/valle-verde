using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Compras
{
    public partial class RecibirMercanciaPreguntar : Form
    {
        public RecibirMercanciaPreguntar()
        {
            InitializeComponent();
        }

        private void ped_Click(object sender, EventArgs e)
        {
            new Ordenes().Show();
            Close();
        }

        private void noPed_Click(object sender, EventArgs e)
        {
            new Ordenes().Show();
            Close();
        }

        private void RecibirMercanciaPreguntar_Load(object sender, EventArgs e)
        {
            KeyDown += new KeyEventHandler(presionoTecla);
            ped.Focus();
        }

        private void presionoTecla(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (ped.Focused)
                    ped.PerformClick();
                else
                    noPed.PerformClick();
        }
    }
}
