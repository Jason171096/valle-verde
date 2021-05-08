using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValleVerde
{
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
            txtCodigo.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(txtCodigo,btnAceptar, false).Show(); 
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();

            int res = ob.EliminarProducto(txtCodigo.Text);

            switch (res)
            {
                case 1:
                    MessageBox.Show("El producto se elimino correctamente.");
                    this.Close();
                    break;
                case 2:
                    MessageBox.Show("El producto fue dado de baja por que no puede ser eliminado.");
                    this.Close();
                    break;
                case -1:
                    MessageBox.Show("No existe el producto.");
                    txtCodigo.Enabled = true;
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                    break;
                case -2:
                    MessageBox.Show("No se puede eliminar o dar de baja a un producto con existencias.");
                    txtCodigo.Enabled = true;
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                    break;
                case -4:
                    MessageBox.Show("No se puede eliminar el producto por un error en BD.");
                    txtCodigo.Enabled = true;
                    txtCodigo.Focus();
                    txtCodigo.SelectAll();
                    break;
            }

            
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                if (ob.ExisteProductoConCodigo(txtCodigo,true,false,false,"-1"))
                {
                    //txtCodigo.Enabled = false;
                    txtCodigo.ReadOnly = true;
                    string codigo = txtCodigo.Text;

                    int cant = ob.ObtenerCantidadImagenesProducto(codigo);
                    if(cant > 0)
                        try {
                            //pictureBox1.Image = Image.FromFile(ob.ObtenerImagenesProducto(codigo)[0]);
                            pictureBox1.Image = ob.ObtenerImagenesProducto(codigo)[0];
                        } catch { }

                    txtNombre.Text = ob.ObtenerNombreProducto(codigo);
                    txtDescripcion.Text = ob.ObtenerDescripcionProducto(codigo);
                    txtExistencia.Text = ob.ObtenerExistenciaTotalProducto(codigo) + "";

                }
                else
                {
                    MessageBox.Show("El producto no existe.");
                }
            }
        }

        private void EliminarProducto_Load(object sender, EventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }
    }
}
