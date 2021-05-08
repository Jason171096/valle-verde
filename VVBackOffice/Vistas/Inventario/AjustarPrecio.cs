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
    public partial class AjustarPrecio : Form
    {
        Array[] precios;
        bool preciosModificados = false;
        ValleVerdeComun.Vistas.Inventario.Precios objPrecios = new ValleVerdeComun.Vistas.Inventario.Precios();
        ValleVerdeComun.Programacion.Precios obp = new ValleVerdeComun.Programacion.Precios();

        string costoOriginal = "";
        List<decimal[]> preciosSinModificarProducto = null;

        public AjustarPrecio()
        {
            InitializeComponent();
            txtCodigo.KeyDown += new KeyEventHandler(tb_KeyDown);
        }

        private void AjustarPrecio_Load(object sender, EventArgs e)
        {
           
          
            objPrecios.ConfigurarPanelPrecios(ref tablePrecios,ref txtCosto,ref precios,false);
        }

        protected void textBox_TextChanged(object utilidad, EventArgs e, object precio)
        {
            // Your code here
            try
            {
                double ut = Convert.ToDouble(((TextBox)utilidad).Text);
                double cost = Convert.ToDouble(txtCosto.Text);
                ((TextBox)precio).Text = ((ut / 100 + 1) * cost) + "";
               
            }
            catch { }


        }

        private void txtCosto_TextChanged(object sender, EventArgs e)
        {
            //preciosModificados = true;

            try
            {
                (precios[0] as TextBox[])[0].Enabled = true;
                (precios[0] as TextBox[])[1].Enabled = true;
                foreach (TextBox[] precio in precios)
                {
                    string t = precio[1].Text;
                    precio[1].Text = "";
                    precio[1].Text = t;
                }
            }
            catch { }
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {

            costoOriginal = obp.ObtenerCostoProducto(txtCodigo.Text) + "";
            preciosSinModificarProducto = obp.ObtenerPreciosCostoProducto(txtCodigo.Text);

            //Checar que no haya cambiado el costo
            if (costoOriginal != txtCosto.Text)
                preciosModificados = true;

            //checar que no haya cambiado las utilidades o cantidades
            if (preciosSinModificarProducto.Count != precios.Length)
                preciosModificados = true;
            else
            {
                for (int x = 0; x < precios.Length; x++)
                {
                    if (x != 0)
                    {
                        //Para no comparar en el primero las cantidades
                        if ((precios.ElementAt(x) as TextBox[])[2].Text != (preciosSinModificarProducto.ElementAt(x)[1] + ""))
                        {
                            preciosModificados = true;
                            break;
                        }
                    }

                    if ((precios.ElementAt(x) as TextBox[])[1].Text != (preciosSinModificarProducto.ElementAt(x)[0] + ""))
                    {
                        preciosModificados = true;
                        break;
                    }

                }
            }

            if (preciosModificados)
            {
                ValleVerdeComun.Programacion.Producto ob = new ValleVerdeComun.Programacion.Producto();
                //EliminarAnteriores
                ob.EliminarPrecios(txtCodigo.Text);

                //Relacionar los nuevos precios
                objPrecios.RegistrarPrecios(ob, txtCodigo.Text, "-1");
            }

            this.Close();
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(" precios mod " + preciosModificados);
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
                    txtCosto.Enabled = true;
                    btnGuardar.Enabled = true;

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

                    objPrecios.CargarPreciosCosto(txtCodigo.Text,ref precios);
                }
                else
                {
                    MessageBox.Show("El producto no existe.");
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new ValleVerdeComun.BuscarProducto(txtCodigo, btnAceptar, false).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            objPrecios.AgregarRenglonPrecios(ref precios, false,false);
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
