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
    public partial class ProductoExtra : Form
    {
        bool respuestaLista = false;
        String[] res = null;

        public ProductoExtra()
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
            ValleVerdeComun.Programacion.Producto obj = new ValleVerdeComun.Programacion.Producto();
            
            if (txtCodigo.Text != "" && txtDescripcionA.Text != "" && txtPiezas.Text != "" )
            {
                if (obj.ExisteProductoConCodigo(txtCodigo,false,false,true,"-1"))
                {
                    res = new string[] { txtCodigo.Text, txtDescripcionA.Text, txtPiezas.Text };
                    respuestaLista = true;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("El producto " + txtCodigo.Text + " no existe o esta bloqueado.");
                    txtCodigo.Focus();
                }
            }
            else
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

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescripcionA.Focus();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(txtCodigo,null, false).ShowDialog(); ;
        }
    }
}
