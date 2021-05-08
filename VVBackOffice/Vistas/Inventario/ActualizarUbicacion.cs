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
    public partial class ActualizarUbicacion : Form
    {
        Programacion.Almacenes ob = new Programacion.Almacenes();

        List<string> ubicaciones = new List<string>();
        public ActualizarUbicacion()
        {
            InitializeComponent();
            txtCodigo.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAceptar.PerformClick();
            }
        }

        private void ActualizarUbicacion_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(txtCodigo, btnAceptar, false).Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                if (ob.ExisteProductoConCodigo(txtCodigo,true,false,false,"-1"))
                {
                    txtCodigo.Enabled = false;
                    string codigo = txtCodigo.Text;

                    int cant = ob.ObtenerCantidadImagenesProducto(codigo);
                    if (cant > 0)
                        try
                        {
                            //pictureBox1.Image = Image.FromFile(ob.ObtenerImagenesProducto(codigo)[0]);
                            pictureBox1.Image = ob.ObtenerImagenesProducto(codigo)[0];
                        }
                        catch { }

                    txtNombre.Text = ob.ObtenerNombreProducto(codigo);
                    txtDescripcion.Text = ob.ObtenerDescripcionProducto(codigo);

                    CargarListaAlmacenes();

                    btnGuardar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El producto no existe.");
                }
            }
        }

        private void CargarListaAlmacenes()
        {
            ubicaciones.Clear();

            

            List<String[]> res = ob.ObtenerAlmacenesProducto(txtCodigo.Text);

            cbAlmacen.DisplayMember = "Text";
            cbAlmacen.ValueMember = "Value";

            List<Object> items = new List<Object>();

            foreach (String[] almacen in res)
            {
                items.Add(new { Text = almacen[1], Value = almacen[0] });
                ubicaciones.Add(almacen[2]);
            }

            cbAlmacen.DataSource = items;
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbAlmacen.SelectedIndex != -1)
                txtUbicacion.Text = ubicaciones[cbAlmacen.SelectedIndex];
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            int res = ob.ActualizarAlmacenProducto(txtCodigo.Text,cbAlmacen.SelectedValue+"",txtUbicacion.Text);

            if (res == 1)
            {


                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtUbicacion.Text = "";
                cbAlmacen.DataSource = null;
                cbAlmacen.Items.Clear();
                ubicaciones.Clear();
                txtCodigo.Enabled = true;
                btnGuardar.Enabled = false;
                pictureBox1.Image = null;
            }
            else
            {
                MessageBox.Show("Error: " + res);
            }
        }
    }
}
