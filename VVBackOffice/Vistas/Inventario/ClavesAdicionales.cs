using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde.Vistas.Inventario
{
    public partial class ClavesAdicionales : Form
    {
        bool respuestaLista = false;
        String[] res = null;
        public ClavesAdicionales()
        {
            InitializeComponent();
            txtCodigo.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            respuestaLista = true;
            this.Close();
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescripcionA.Text != "" && txtPiezas.Text != "")
            {
                res = new string[] { txtCodigo.Text, txtDescripcionA.Text, txtPiezas.Text };
                respuestaLista = true;

                this.Close();
            } else
            {
                MessageBox.Show("Revisa los datos.");
                txtCodigo.Focus();
            }
        }

        public bool RespuestaLista()
        {
            return respuestaLista;
        }

        public string[] ObtenerRespuesta()
        {
            return res;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcionA.Focus();
            }
        }

        private void ClavesAdicionales_Load(object sender, EventArgs e)
        {

        }
    }
}
