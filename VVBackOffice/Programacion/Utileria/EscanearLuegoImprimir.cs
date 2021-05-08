using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValleVerde.Programacion.Utileria;

namespace ValleVerde.Vistas.Utileria
{
    public partial class EscanearLuegoImprimir : Form
    {
        Validaciones v = new Validaciones();
        public EscanearLuegoImprimir()
        {
            InitializeComponent();
            txtCodigo.TabIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseCodigosPreescaneados guardar = new ClaseCodigosPreescaneados();
                guardar.GuardarEtiquetas(txtCodigo.Text, DateTime.Now.Date);
                txtCodigo.Text = "";
            }
            catch(Exception ex)
            {
                txtCodigo.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnGuardar.PerformClick();
            }
        }
    }
}
